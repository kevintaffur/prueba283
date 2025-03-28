using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Table("TasasCambio")]
    public partial class TasasCambio
    {
        [Key]
        public int Id { get; set; }
        [StringLength(3)]
        [Unicode(false)]
        public string MonedaOrigen { get; set; } = null!;
        [StringLength(3)]
        [Unicode(false)]
        public string MonedaDestino { get; set; } = null!;
        public int TasaCambio { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaActualizacion { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string Estado { get; set; } = null!;
    }
}
