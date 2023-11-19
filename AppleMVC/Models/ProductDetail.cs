﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppleMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class ProductDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductDetail()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int ProductDetailID { get; set; }
        public int ProID { get; set; }
        public int ColorID { get; set; }

        [RegularExpression(@"^[1-9]\d{0,7}(?:\.\d{1,4})?$", ErrorMessage = "Kiem Tra Lai Gia")]
        public double Price { get; set; }

        public string AppleCareName { get; set; }
        public string ProductImage { get; set; }
        public int ScreenID { get; set; }
        public int MemoryID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    
        public virtual Color Color { get; set; }
        public virtual Memory Memory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Product Product { get; set; }
        public virtual Screen Screen { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
    }
}
