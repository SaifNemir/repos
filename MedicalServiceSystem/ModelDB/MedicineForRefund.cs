﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ModelDB
{
   
    public class MedicineForReclaim
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Generic_name { get; set; }
        public decimal UnitCost { get; set; }
        public bool InContract { get; set; }
        public int Activated { get; set; }
    }
}
