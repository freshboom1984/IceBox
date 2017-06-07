using System;
using System.Collections.Generic;

namespace IceBox.Models
{
    public partial class User
    {
        public int ObjId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? TheDivision { get; set; }
        public int? TheRole { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string OfficePhone { get; set; }
        public string HomePhone { get; set; }
        public string QqNumber { get; set; }
        public int? UserState { get; set; }

        public virtual Division TheDivisionNavigation { get; set; }
        public virtual Role TheRoleNavigation { get; set; }
    }
}
