using System;
using System.Collections.Generic;

namespace IceBox.Models
{
    public partial class CustomerType
    {
        public int ObjId { get; set; }
        public string TypeName { get; set; }
        public double? MinSpending { get; set; }
    }
}
