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
    
    public partial class store
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public store()
        {
            this.prices = new HashSet<price>();
        }
    
        public int store_id { get; set; }
        public long chain_id { get; set; }
        public Nullable<int> store_type { get; set; }
        public string store_name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public int store_key { get; set; }
    
        public virtual chain chain { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<price> prices { get; set; }
    }
}
