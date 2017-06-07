using System;
using System.Collections.Generic;

namespace IceBox.Models
{
    public partial class Order
    {
        public Order()
        {
            Receipt = new HashSet<Receipt>();
        }

        public int ObjId { get; set; }
        public int? TheCustomer { get; set; }
        public DateTime? OrderTime { get; set; }
        public int? TheProduct { get; set; }
        public double? Amt { get; set; }
        public int? ThePayment { get; set; }
        public int? TheConsignee { get; set; }
        public int? TheClerk { get; set; }
        public int? TheDeliverer { get; set; }
        public int? OrderState { get; set; }

        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}
