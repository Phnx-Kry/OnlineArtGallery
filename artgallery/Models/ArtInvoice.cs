//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace artgallery.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ArtInvoice
    {
        public int ArtinvoiceId { get; set; }
        public string datesold { get; set; }
        public Nullable<int> customerid_FK { get; set; }
        public Nullable<int> artid_FK { get; set; }
        public string paymentmode { get; set; }
        public Nullable<int> approvedbyadminid_FK { get; set; }
    
        public virtual Adminbox Adminbox { get; set; }
        public virtual ArtGallery ArtGallery { get; set; }
        public virtual Member Member { get; set; }
    }
}
