using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdTrace.Models.Classes
{
    public class Product  //Ürün
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName="Varchar")]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Brand { get; set; }  //marka
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; } //Alış fiyatı
        public decimal SalesPrice { get; set; } //Satış Fiyatı
        public bool Status { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string ProductImage { get; set; }

        //Relationships
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<SalesMovement> SalesMovements { get; set; }

    }
}