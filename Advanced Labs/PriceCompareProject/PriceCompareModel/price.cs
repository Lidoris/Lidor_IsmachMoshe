//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PriceCompareModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class price
    {
        public long item_code { get; set; }
        public int store_key { get; set; }
        public float price1 { get; set; }
    
        public virtual item item { get; set; }
        public virtual store store { get; set; }
    }
}
