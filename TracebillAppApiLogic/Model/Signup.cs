using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracebillAppApiLogic.Model
{
    public class NewConnection
    {
        public double applicationID { get; set; }
        public string applicationNumber { get; set; }
        public string firstNam { get; set; }
        public string lastName { get; set; }
        public string otherName { get; set; }
        public string physicalAddress { get; set; }
        public string emailAddress { get; set; }
        public string ocupation { get; set; }
        public string workPlace { get; set; }
        public string telephone { get; set; }
        public int countryId { get; set; }
        public string state { get; set; }
        public string constituency { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string village { get; set; }
        public string zipCode { get; set; }
        public string division { get; set; }
        public string IdNumber { get; set; }
        public int IdTypeID { get; set; }
        public string customerType { get; set; }
        public int connectionType { get; set; }
        public int optionID { get; set; }
        public int serviceID { get; set; }
        public int classID { get; set; }
        public int statusID { get; set; }
        public int capturedBy { get; set; }
        public DateTime applicationDate { get; set; }
        public int areaId { get; set; }
        public int branchId { get; set; }
    }
}
