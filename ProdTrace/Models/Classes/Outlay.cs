using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdTrace.Models.Classes
{
    public class Outlay  //Giderler-Harcamalar
    {
        public int OutlayId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }  //Ne harcaması?
        public DateTime Date { get; set; }
        public decimal Price { get; set; } //Tutar
    }
}