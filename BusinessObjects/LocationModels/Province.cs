﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.LocationModels
{
    public class Province
    {

        public string Name { get; set; }
        public string Code { get; set; }
        public List<City> Cities { get; set; } = new List<City>();
    }
}
