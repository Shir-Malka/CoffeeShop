//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace coffeeshop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ShoopingCart
    {
        [Key]
        public int CartID { get; set; }
        public int Qty { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}
