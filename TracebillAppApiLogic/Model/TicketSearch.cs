using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracebillAppApiLogic.Model
{
    public class TicketSearch : GenericResponse
    {
        public List<Ticket> tickets { get; set; }
    }
}
