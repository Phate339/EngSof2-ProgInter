﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.Models
{
    public class Diseases
    {
        public int DiseasesID { get; set; }
        public string DiseasesName { get; set; }
        public string Description { get; set; }
        public string Care { get; set; }

        public List<Sur_Dis>  Sur_Dis { get; set; }
    }
}
