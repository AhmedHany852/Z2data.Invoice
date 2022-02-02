using System;
using System.Collections.Generic;
using System.Text;

namespace Z2data.Invoice.Core.Entity
{
    public class ItemDetails
    {
        public int KeyID { get; set; }
        public int ItemID { get; set; }
        public string ProductName { get; set; }
        public decimal ? Price  { get; set; }
    }
}
