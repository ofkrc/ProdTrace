using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProdTrace.Models.Classes
{
    public class Staff          //Personel
    {
        public int StaffId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string StaffName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string StaffSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string StaffImage { get; set; }

        //Relationships
        public ICollection<SalesMovement> SalesMovements { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}