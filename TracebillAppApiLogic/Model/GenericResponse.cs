﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracebillAppApiLogic.Model
{
    public class GenericResponse
    {
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }
    }
}
