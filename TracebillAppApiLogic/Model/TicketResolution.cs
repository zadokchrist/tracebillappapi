using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracebillAppApiLogic.Model
{
    public class TicketResolution
    {
        public string RecordId { get; set; }
        public string Ticket_id { get; set; }
        public string Status { get; set; }
        public string ResolutionDetails { get; set; }
        public string EscalatedTo { get; set; }
        public string RecordedBy { get; set; }
        public string RecordDate { get; set; }
    }
}
