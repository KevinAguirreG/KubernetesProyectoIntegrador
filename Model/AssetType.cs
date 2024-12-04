﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsip_Rentas.Model
{
    public class AssetType 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string AbreviationName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        
       


    }
}
