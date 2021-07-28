using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracebillAppApiLogic.Model
{
    public class ComplaintSubCategories : GenericResponse
    {
        public List<ComplaintSubCategory> complaintSubCategories { get; set; }
    }
}
