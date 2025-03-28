using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api.Dtos.Productos
{
    public class CuentaModificacionDto
    {
        public int? NumeroCuenta { get; set; }

        public string? Division { get; set; }

        [RegularExpression("^(USD|EUR|GBP)$", ErrorMessage = "La moneda solo puede ser USD, EUR o GBP.")]
        public string? Moneda { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Saldo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaCreacion { get; set; }

        [RegularExpression("^[NAI]$", ErrorMessage = "El estado solo puede ser N, A o I.")]
        public string? Estado { get; set; }
    }
}
