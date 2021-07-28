using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracebillAppApiLogic.Model
{
    public class TicketResolutionSearch : GenericResponse
    {
        public List<TicketResolution> ticketResolutions { get; set; }
    }
}
