﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Entities.Product.PDbTable
{
    public class PDbTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PDbDetail Details { get; set; }
      
    }
}
