﻿using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SautinSoft;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.NetworkInformation;

namespace DumpToExcel
{
    public partial class Form1 : Form
    {
        DataTable dtCustomerData = new DataTable();
        string[] fileNames;
        string messageBoxTitle = "Invoice Extractor";
        public Form1()
        {
            InitializeComponent();

            lblAssemblyVersion.Text = $"Version:{Application.ProductVersion}";
        }

        private void BtnExtractData_Click(object sender, EventArgs e)
        {
            ExtractData();
        }
        private void BtnExporttoExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void dgData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
                {
                    e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in dgData_RowPostPaint:{ex.Message}", "Error");
            }
        }
        private void ExportToExcel()
        {
            try
            {
                if (dtCustomerData.Rows.Count > 0)
                {
                    pbLoading.Visible = true;
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var exceloutputFilePath = saveFileDialog.FileName;// + DateTime.Now.ToString("yyyy-MM-dd");
                        WriteDataTableToExcel(dtCustomerData, exceloutputFilePath);

                        MessageBox.Show("Data successfully exported to excel", messageBoxTitle);
                    }

                }
                else
                    MessageBox.Show("Extract data first from PDF file", messageBoxTitle);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in BtnExporttoExcel_Click:{ex.Message}", "Error");
            }
            pbLoading.Visible = false;
        }
        private void ExtractData()
        {
            try
            {
                ControlEnable(false);
                if (!string.IsNullOrEmpty(txtFilePath.Text))
                {
                    bool isInternetAvailable = IsInternetConnectionAvailable();

                    if (isInternetAvailable)
                    {
                        BtnExtractData.Enabled = false;
                        pbLoading.Visible = true;
                        GetData();
                    }
                    else
                    {
                        MessageBox.Show("Internet connection is not available.", messageBoxTitle);
                        ControlEnable(true);
                    }
                }
                else
                    MessageBox.Show("Select PDF file first", messageBoxTitle);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in GetData:{ex.Message}", "Error");
            }
        }
        private async void GetData()
        {
            string pageText = string.Empty;
            try
            {
                List<CustomerModel> customerModel = new List<CustomerModel>();

                foreach (var item in fileNames)
                {
                    using (PdfReader pdfReader = new PdfReader(item.Trim()))
                    {
                        for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                        {
                            CustomerModel customer = new CustomerModel();
                            // Extract text from the current page
                            pageText = PdfTextExtractor.GetTextFromPage(pdfReader, page);
                            customer.PageContent = pageText;
                            //Customer Name
                            int pFrom = pageText.IndexOf("Recipient Address:") + "Recipient Address:".Length;
                            int pTo = pageText.IndexOf("Ship From Address");
                            customer.CustomerName = pageText.Substring(pFrom, pTo - pFrom).Trim();

                            // Use a regular expression to find email addresses in the text
                            // Add matching email addresses to the list
                            string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b";
                            MatchCollection matches = Regex.Matches(pageText, pattern);
                            customer.EmailId = matches != null && matches.Count > 0 && matches[0].Success && matches.Count > 0 ? matches[0].Value : "";

                            // Add matching contact numbers to the list
                            string patternContact = @"\b\d{3}[-.\s]?\d{3}[-.\s]?\d{4}\b";
                            MatchCollection matchesContact = Regex.Matches(pageText, patternContact);

                            customer.MobileNo = matchesContact != null && matchesContact.Count > 0 && matchesContact[0].Success && matchesContact.Count > 0 ? matchesContact[0].Value : "";


                            //Pincode                  
                            string patternPincode = @"\b\d{6}\b";
                            MatchCollection matchesPincode = Regex.Matches(pageText, patternPincode);

                            if (matchesPincode != null && matchesPincode.Count > 0)
                            {

                                foreach (Match matchPincode in matchesPincode)
                                {
                                    if (!matchPincode.Value.Contains("302017") &&
                                        !matchPincode.Value.Contains("302003") &&
                                        !matchPincode.Value.Contains("560025"))
                                    {
                                        customer.Pincode = matchPincode.Value;
                                    }
                                }
                            }
                            customer.RecipientAddress = await GetAreaNameFromPincode(customer);


                            //Customer Name
                            int oFrom = pageText.IndexOf("ORDER NUMBER:") + "ORDER NUMBER:".Length;
                            int oTo = pageText.IndexOf("Mode Of Payment:");
                            customer.OrderNumber = pageText.Substring(oFrom, oTo - oFrom).Trim() ?? "";
                            if (customer.CustomerName.Contains("Divakar Dommaraju"))
                            {
                                var k = string.Empty;
                            }
                            string skuPattern = @"[A-Z]{3,4}\d{3,4}[A-Z,0-9]+(_[A-Z]{1,}|-([A-Z]{1,})|--([A-Z]{1,})|--)";
                            string ptext = Regex.Replace(pageText, @"\t|\n|\r", "");
                            MatchCollection SKUmatches = Regex.Matches(ptext, skuPattern);
                            if (SKUmatches != null && SKUmatches.Count > 0)
                            {
                                if (SKUmatches.Count == 1)
                                {
                                    customer.SKUId = SKUmatches[0].Success && SKUmatches.Count > 0 ? SKUmatches[0].Value : "";
                                }
                                else
                                {
                                    for (int i = 0; i < SKUmatches.Count; i++)
                                    {
                                        customer.SKUId += SKUmatches[i].Success && SKUmatches.Count > 0 ? $"{(i > 0 ? "," : string.Empty)}{SKUmatches[i].Value}" : "";
                                    }
                                }
                            }


                            customerModel.Add(customer);
                        }
                    }
                }

                if (customerModel.Count() > 0)
                {
                    dtCustomerData = GetDataTable(customerModel);
                    dgData.DataSource = dtCustomerData.DefaultView;
                    dgData.AutoGenerateColumns = true;
                    BtnExporttoExcel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in GetData:{ex.Message}", "Error");
            }
            pbLoading.Visible = false;
            ControlEnable(true);

        }

        private DataTable GetDataTable(List<CustomerModel> model)
        {
            DataTable dtData = new DataTable();
            try
            {
                dtData.Columns.Add("CustomerName", typeof(string));
                dtData.Columns.Add("OrderNumber", typeof(string));
                dtData.Columns.Add("SKUNumber", typeof(string));

                //dtData.Columns.Add("Email", typeof(string));
                dtData.Columns.Add("ContactNo", typeof(string));
                dtData.Columns.Add("Pincode", typeof(string));
                dtData.Columns.Add("CustomerAddress", typeof(string));

                foreach (var item in model)
                {
                    dtData.Rows.Add(item.CustomerName, item.OrderNumber, item.SKUId, item.MobileNo, item.Pincode, item.RecipientAddress);
                }
            }
            catch (Exception ex)
            {
                dtData = null;
                MessageBox.Show($"Error in GetDataTable:{ex.Message}", "Error");
            }
            return dtData;
        }

        private void WriteDataTableToExcel(DataTable dataTable, string excelFilePath)
        {
            try
            {
                using (var spreadsheetDocument = SpreadsheetDocument.Create(excelFilePath, SpreadsheetDocumentType.Workbook))
                {
                    var workbookPart = spreadsheetDocument.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();
                    var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());
                    var sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
                    var sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                    sheets.Append(sheet);
                    var columns = dataTable.Columns.Cast<DataColumn>().ToList();
                    var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                    // Create header row
                    var headerRow = new Row();
                    foreach (var column in columns)
                    {
                        var cell = new Cell { DataType = CellValues.String, CellValue = new CellValue(column.ColumnName) };
                        headerRow.Append(cell);
                    }
                    sheetData.Append(headerRow);
                    // Add data rows
                    foreach (DataRow row in dataTable.Rows)
                    {
                        var dataRow = new Row();
                        foreach (var column in columns)
                        {
                            var cell = new Cell { DataType = CellValues.String, CellValue = new CellValue(row[column].ToString()) };
                            dataRow.Append(cell);
                        }
                        sheetData.Append(dataRow);
                    }
                    workbookPart.Workbook.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in WriteDataTableToExcel:{ex.Message}", "Error");
            }
        }

        private void BtnPdf_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileNames = openFileDialog.FileNames;
                    txtFilePath.Text = fileNames.Length > 1 ? $"{fileNames.Length} files selected...!" : openFileDialog.FileName;
                    BtnExtractData.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in BtnPdf_Click:{ex.Message}", "Error");
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                BtnExtractData.Enabled = false;
                BtnExporttoExcel.Enabled = false;
                pbLoading.Visible = false;
                dgData.DataSource = null;
                fileNames = null;
                txtFilePath.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in BtnReset_Click :{ex.Message}", "Error");
            }
        }

        private async Task<string> GetAreaNameFromPincode(CustomerModel model)
        {
            try
            {
                if (model != null && !string.IsNullOrEmpty(model.Pincode))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        string apiUrl = $"https://api.postalpincode.in/pincode/{model.Pincode}";
                        HttpResponseMessage response = await client.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();
                            PincodeDataModel data = new PincodeDataModel();
                            var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PincodeDataModel>>(responseBody);
                            data = responseData.FirstOrDefault();
                            string address = string.Empty;
                            if (!string.IsNullOrEmpty(model.PageContent) && data.PostOffice != null)
                            {
                                foreach (var item in data.PostOffice)
                                {
                                    if (model.PageContent.Contains(item.Name))
                                    {
                                        address = $"{item.Name},";
                                    }
                                }

                                if (data.Status == "Success")
                                {
                                    address = $"{address}{data.PostOffice[0].District}, {data.PostOffice[0].State}-{model.Pincode}";
                                }
                            }

                            return address;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in GetAreaNameFromPincode :{ex.Message}", "Error");
            }
            return string.Empty;
        }

        private bool IsInternetConnectionAvailable()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (PingException)
            {
                return false;
            }
        }

        private void ControlEnable(bool isEnable = true)
        {
            try
            {
                BtnExtractData.Enabled = isEnable;
                BtnReset.Enabled = isEnable;
                //BtnPdf.Enabled = isEnable;
                if (isEnable && txtFilePath.Text.Length > 0)
                {
                    BtnExporttoExcel.Enabled = isEnable;
                }
                else
                {
                    BtnExtractData.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in ControlEnable :{ex.Message}", "Error");
            }
        }
        bool isClosed = false;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                if (dgData.Rows.Count > 0 || pbLoading.Visible == true)
                {
                    if (!isClosed)
                    {
                        DialogResult dialogResult = MessageBox.Show("Please make sure to save data in excel, Before close software.", "Data Exctractor", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            isClosed = true;
                            Application.Exit();
                        }
                        else
                        {
                            e.Cancel = true;
                            isClosed = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in ControlEnable :{ex.Message}", "Error");
            }
        }

        private void CheckApplicationLicence()
        {
            try
            {
                DateTime dtExpiredOn = new DateTime(2024, 10, 31);
                DateTime dtToday = DateTime.Now;
                DateTime dtExpiredOnWithoutTime = dtExpiredOn.Date;
                DateTime dtTodayWithoutTime = dtToday.Date;
                TimeSpan difference = dtExpiredOnWithoutTime - dtTodayWithoutTime;
                int daysDifference = (int)difference.TotalDays;
                if (dtExpiredOnWithoutTime == dtTodayWithoutTime)
                {
                    MessageBox.Show($"Software licence has been expired,{Environment.NewLine} Please contact Administrator", messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
                else if (daysDifference <= 10)
                {
                    MessageBox.Show($"Software licence will expiried in {daysDifference}.{Environment.NewLine} Please contact Administrator before stop the software", messageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in CheckApplicationLicence :{ex.Message}", "Error");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckApplicationLicence();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi");
        }
    }
}