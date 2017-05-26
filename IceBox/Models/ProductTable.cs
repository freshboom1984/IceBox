using System;
using System.Collections.Generic;

namespace IceBox.Models
{
    public partial class ProductTable
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string Name { get; set; }
        public string Ename { get; set; }
        public double Discount { get; set; }
        public double Price { get; set; }
        public string Hpicture { get; set; }
        public string Spicture1 { get; set; }
        public string Spicture2 { get; set; }
        public string Hdiscribe { get; set; }
        public string Sdisvribe { get; set; }
        public string Svideo { get; set; }
        public string Clow { get; set; }
        public string Chigh { get; set; }
        public int? Typeid { get; set; }
    }
}
