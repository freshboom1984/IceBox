using System;
using System.Collections.Generic;

namespace IceBox.Models
{
    public partial class CustomerType
    {
        public CustomerType()
        {
            Customer = new HashSet<Customer>();
        }

        public int ObjId { get; set; }
        public string TypeName { get; set; }
        public double? MinSpending { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        
    }
}
