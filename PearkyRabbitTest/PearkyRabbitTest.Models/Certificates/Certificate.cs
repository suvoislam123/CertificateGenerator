﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearkyRabbitTest.Models.Certificates
{
    public class Certificate 
    {
        public Guid Id {  get; set; }   
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public string ApplicationUserId { get; set; }

    }
}
