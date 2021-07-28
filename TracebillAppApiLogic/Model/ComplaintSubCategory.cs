using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracebillAppApiLogic.Model
{
    public class ComplaintSubCategory
    {
        public string SubCategoryId { get; set; }
        public string CategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string RecordDate { get; set; }
    }
}
