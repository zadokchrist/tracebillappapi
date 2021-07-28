using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracebillAppApiLogic.Model
{
    public class Ticket
    {
        public string ticket_id { get; set; }
        public string ComplainantType { get; set; }
        public string CustRef { get; set; }
        public string CustName { get; set; }
        public string ComplaintSource { get; set; }
        public string ComplaintCategory { get; set; }
        public string ComplaintSubCategory { get; set; }
        public string CustContact { get; set; }
        public string TicketDetails { get; set; }
        public string email_id { get; set; }
        public string prioprity { get; set; }
        public string attachment { get; set; }
        public string status { get; set; }
        public string admin_remark { get; set; }
        public string posting_date { get; set; }
        public string admin_remark_date { get; set; }
        public string AssignedTo { get; set; }
        public string resolvedby { get; set; }
    }
}
