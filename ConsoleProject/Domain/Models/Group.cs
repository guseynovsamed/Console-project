using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Models
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public  int Capacity { get; set; }
    }
}
