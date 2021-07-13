using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracebillAppApiLogic.Model
{
    public class RegisterNewCustomer
    {
        public string custRef { get; set; }
        public string firstNam { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set;}
        public string telephone { get; set; }
    }

    public class Login
    {
        public string custRef { get; set; }
        public string password { get; set; }
    }

    public class ElectronicBill
    {
        public string custRef { get; set; }
        public string period { get; set; }
    }

    public class Payments
    {
        public string custRef { get; set; } 
    }

    public class AccountStatement
    {
        public string custRef { get; set; }
        public string startDate { get; set; }
    }

    public class HistoricalReadings
    {
        public string custRef { get; set; }
    }

    public class CustomerRelationshipManagement
    {
        public string custRef { get; set; }
        public string description { get; set; }
        public string priority { get; set; }
        public string subject { get; set; }
        public string ticketSource { get; set; }//Source of info
        public string emailID { get; set; }//email address
        public string attachment { get; set; }//empty
    }

    public class RetrieveComplaintStatus
    {
        public string ticketID { get; set; }
    }

    public class TrackNewConnection
    {
        public string newConnectionID { get; set; }
    }
}
