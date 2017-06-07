using System;
using System.Collections.Generic;

namespace IceBox.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Consignee = new HashSet<Consignee>();
        }

        public int ObjId { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public int? TheCustomerType { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string OfficePhone { get; set; }
        public string HomePhone { get; set; }
        public string QqNumber { get; set; }
        public DateTime? RegistDate { get; set; }

        public virtual ICollection<Consignee> Consignee { get; set; }
    }
}
