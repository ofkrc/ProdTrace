using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdTrace.Models.Classes
{
    public class InvoiceColumn  //Fatura kalemleri
    {   
        [Key]
        public int InvoiceColumnId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string Description { get; set; }
        public decimal Amount { get; set; } //Miktar
        public decimal UnitPrice { get; set; } //Birim Fiyatı
        public decimal TotalPrice { get; set; } //Toplam Fiyatı - Tutar       

        //Relationships
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}