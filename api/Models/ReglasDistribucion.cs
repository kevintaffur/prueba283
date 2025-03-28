using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Table("ReglasDistribucion")]
    public partial class ReglasDistribucion
    {
        [Key]
        public int Id { get; set; }
        [StringLength(5)]
        [Unicode(false)]
        public string Division { get; set; } = null!;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Porcentaje { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string Estado { get; set; } = null!;
    }
}
