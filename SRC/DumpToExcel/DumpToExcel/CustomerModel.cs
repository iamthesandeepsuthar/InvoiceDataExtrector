using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumpToExcel
{
    public class CustomerModel
    {
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string RecipientAddress { get; set; }
        public string EmailId { get; set; }
        public string Pincode { get; set; }
        public string PageContent { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class PostOffice
    {
        public string Name { get; set; }
        public object Description { get; set; }
        public string BranchType { get; set; }
        public string DeliveryStatus { get; set; }
        public string Circle { get; set; }
        public string District { get; set; }
        public string Division { get; set; }
        public string Region { get; set; }
        public string Block { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
    }

    public class PincodeDataModel
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public List<PostOffice> PostOffice { get; set; }
    }


}
