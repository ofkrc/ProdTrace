using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProdTrace.Models.Classes
{
    public class SalesMovement  //Satış Hareketleri
    {
        [Key]
        public int SalesId { get; set; }
        //ürün
        //customer
        //personel
        public DateTime Date { get; set; }
        public int Piece { get; set; }  //Adet
        public decimal Price { get; set; } //Fiyat
        public decimal TotalPrice { get; set; } //Toplam Tutar

        //Relationships
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int StaffId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Staff Staff { get; set; }
    }
}