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
    
    public partial class ShopTable
    {
        [Key]
        public int TableID { get; set; }

        public int TableSize { get; set; }
        public string InsideOutside { get; set; }
        public string AvilableNotAvilable { get; set; }
        public string Image { get; set; }
    }
}