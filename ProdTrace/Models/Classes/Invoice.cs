using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdTrace.Models.Classes
{
    public class Invoice        //Fatura
    {
        [Key]
        public int InvoiceId { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceSerialNo { get; set; }  //Fatura seri no

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string InvoiceSequenceNo { get; set; } //Fatura Sıra no

        public DateTime InvoiceDate { get; set; }
        public DateTime InvoiceHour { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string InvoiceTaxAuthority { get; set; }  //Vergi Dairesi

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DeliveryFrom { get; set; }  //Teslim eden

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DeliveryTo { get; set; } //Teslim alan

        //Relationships
        public ICollection<InvoiceColumn> InvoiceColumns { get; set; }
    }
}