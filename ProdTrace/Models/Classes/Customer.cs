using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdTrace.Models.Classes
{
    public class Customer           //Cari
    {
        [Key]
        public int CustomerId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string CustomerName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string CustomerSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string CustomerCountry { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string CustomerMail { get; set; }

        //Relationships
        public ICollection<SalesMovement> SalesMovements { get; set; }
    }
}