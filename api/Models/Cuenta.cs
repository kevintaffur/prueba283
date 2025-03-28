using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public partial class Cuenta
    {
        [Key]
        public int Id { get; set; }
        public int NumeroCuenta { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Division { get; set; } = null!;
        [StringLength(3)]
        [Unicode(false)]
        public string Moneda { get; set; } = null!;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Saldo { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaCreacion { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string Estado { get; set; } = null!;
    }
}
