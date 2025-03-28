using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Dtos.Cuentas
{
    public class CuentaCreacionDto
    {
        [Required(ErrorMessage = "El número de cuenta es requerido.")]
        public int NumeroCuenta { get; set; }

        [Required(ErrorMessage = "La división es requerida.")]
        [RegularExpression("^(AHORROS|INVERSIONES|GASTOS)$", ErrorMessage = "Solo puede ser AHORROS, INVERSIONES o GASTOS.")]
        public string Division { get; set; } = null!;

        [Required(ErrorMessage = "La moneda es requerida.")]
        [RegularExpression("^(USD|EUR|GBP)$", ErrorMessage = "La moneda solo puede ser USD, EUR o GBP.")]
        public string Moneda { get; set; } = null!;

        [Required(ErrorMessage = "El saldo es requerido.")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Saldo { get; set; }

        [Required(ErrorMessage = "La fecha de creación es requerida.")]
        [Column(TypeName = "date")]
        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "El estado es requerido.")]
        [RegularExpression("^[NAI]$", ErrorMessage = "El estado solo puede ser N, A o I.")]
        public string Estado { get; set; } = null!;
    }
}
