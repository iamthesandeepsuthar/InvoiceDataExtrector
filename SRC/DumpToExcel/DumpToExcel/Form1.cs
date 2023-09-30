using DocumentFormat.OpenXml;
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

namespace DumpToExcel
{
    public partial class Form1 : Form
    {
        //private string exceloutputFilePath = @"E:\SandeepSuthar\File\output.xlsx";
        DataTable dtCustomerData = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnExtractData_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilePath.Text))
            {
                BtnExtractData.Enabled = false;
                List<string> emailList = new List<string>();
                var PDFFilePath = txtFilePath.Text.Trim();// @"E:\SandeepSuthar\File\SamplePdf.pdf";
                getData(PDFFilePath);
                //PDFToHTML(PDFFilePath);
            }
            else
                MessageBox.Show("Select PDF file first", "Validate");
        }

        private async void getData(string fileName)
        {
            string pdfFilePath = fileName;
            string pageText = string.Empty;

            List<CustomerModel> customerModel = new List<CustomerModel>();

            using (PdfReader pdfReader = new PdfReader(pdfFilePath))
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
                    customer.EmailId = matches[0].Success && matches.Count == 1 ? matches[0].Value : "";

                    // Add matching contact numbers to the list
                    string patternContact = @"\b\d{3}[-.\s]?\d{3}[-.\s]?\d{4}\b";
                    MatchCollection matchesContact = Regex.Matches(pageText, patternContact);
                    customer.MobileNo = matchesContact[0].Success && matchesContact.Count == 1 ? matchesContact[0].Value : "";

                    //Pincode                  
                    string patternPincode = @"\b\d{6}\b";
                    MatchCollection matchesPincode = Regex.Matches(pageText, patternPincode);

                    foreach (Match matchPincode in matchesPincode)
                    {
                        if (!matchPincode.Value.Contains("302017") &&
                            !matchPincode.Value.Contains("302003") &&
                            !matchPincode.Value.Contains("560025"))
                        {
                            customer.Pincode = matchPincode.Value;
                        }
                    }

                    customer.RecipientAddress = await GetAreaNameFromPincode(customer);
                    customerModel.Add(customer);

                }


            }


            if (customerModel.Count() > 0)
            {
                dgData.DataSource = GetDataTable(customerModel); ;
                dgData.AutoGenerateColumns = true;
                BtnExporttoExcel.Enabled = true;
            }

            //dtCustomerData = GetFinaldata(customerEmail, customerContactNo, customerNames, customerPincode, pageText);
            //if (dtCustomerData.Rows.Count > 0)
            //{
            //    //WriteDataTableToExcel(dtCustomerData, exceloutputFilePath);
            //    dgData.DataSource = dtCustomerData.DefaultView;
            //    dgData.AutoGenerateColumns = true;
            //    BtnExporttoExcel.Enabled = true;
            //}
        }
        private void BtnExporttoExcel_Click(object sender, EventArgs e)
        {
            if (dtCustomerData.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"; // Specify file filters
                //saveFileDialog.FilterIndex = 1; // Set the default filter

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var exceloutputFilePath = saveFileDialog.FileName;
                    WriteDataTableToExcel(dtCustomerData, exceloutputFilePath);
                    MessageBox.Show("Data successfully exported to excel", "Export Data");
                }
            }
            else
                MessageBox.Show("Extract data first from PDF file", "Data Extraction");
        }

        private void dgData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //var grid = sender as DataGridView;
            //var rowIdx = (e.RowIndex + 1).ToString();
            //row.HeaderCell.Value = String.Format("{0}", rowIdx);

            using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private DataTable GetDataTable(List<CustomerModel> model)
        {
            DataTable dtData = new DataTable();
            dtData.Columns.Add("CustomerName", typeof(string));
            dtData.Columns.Add("Email", typeof(string));
            dtData.Columns.Add("ContactNo", typeof(string));
            dtData.Columns.Add("Pincode", typeof(string));
            dtData.Columns.Add("CustomerAddress", typeof(string));

            foreach (var item in model)
            {
                dtData.Rows.Add(item.CustomerName, item.EmailId, item.MobileNo, item.Pincode, item.RecipientAddress);

            }


            return dtData;
        }

        private void WriteDataTableToExcel(DataTable dataTable, string excelFilePath)
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

        private void BtnPdf_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf"; // Specify file filters
            //openFileDialog.FilterIndex = 1; // Set the default filter

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            BtnExtractData.Enabled = true;
            txtFilePath.Clear();
            dgData.DataSource = null;

        }

        //PDF to Html
        private void PDFToHTML(string pdffile)
        {
            string pdfFilePath = pdffile;// "input.pdf"; // Replace with the path to your PDF file
            string outputHtmlPath = @"E:\SandeepSuthar\File\output.xls"; // Specify the output HTML file path
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            f.OpenPdf(pdfFilePath);

            if (f.PageCount > 0)
            {
                var result = f.ToExcel(outputHtmlPath);
            }
        }

        public string ExtractSpecificTextFromPdf(string pdfFilePath, string specificTextToExtract)
        {
            string extractedText = string.Empty;

            using (PdfReader pdfReader = new PdfReader(pdfFilePath))
            {
                for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string pageText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

                    // Check if the specific text is present on the page
                    if (pageText.Contains(specificTextToExtract))
                    {
                        extractedText += pageText;
                    }
                }
            }

            return extractedText;
        }

        private async Task<string> GetAreaNameFromPincode(CustomerModel model)
        {
            try
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
                        if (!string.IsNullOrEmpty(model.PageContent))
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
            catch (Exception ex)
            {
                //MessageBox.Show($"An error occurred: {ex.Message}");
            }

            return string.Empty;
        }

        //static async Task<string> GetAddressFromPincode(string pincode)
        //{
        //    try
        //    {
        //        using (HttpClient client = new HttpClient())
        //        {
        //            // Define the API endpoint URL
        //            string apiUrl = $"https://api.postalpincode.in/pincode/{pincode}";

        //            // Make the GET request to the API
        //            HttpResponseMessage response = await client.GetAsync(apiUrl);

        //            // Check if the request was successful
        //            if (response.IsSuccessStatusCode)
        //            {
        //                // Read the response content as a string
        //                string responseBody = await response.Content.ReadAsStringAsync();

        //                // Parse the JSON response to get the address
        //                // The API returns an array, so you may need to handle multiple results
        //                // For simplicity, this example takes the first result
        //                dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);
        //                string address = data[0].PostOffice[0].Name + ", " +
        //                                data[0].PostOffice[0].District + ", " +
        //                                data[0].PostOffice[0].State;

        //                return address;
        //            }
        //            else
        //            {
        //                Console.WriteLine($"API request failed with status code {response.StatusCode}");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //    }

        //    return string.Empty;
        //}
    }

}