﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Models
{
    public class Student : BaseEntity
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public byte Age { get; set; }
        public string Phone {  get; set; }
        public Group Group { get; set; }
    }
}
