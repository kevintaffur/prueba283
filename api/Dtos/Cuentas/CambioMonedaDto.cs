using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Cuentas
{
    public class CambioMonedaDto
    {

        [Required(ErrorMessage = "La moneda es requerida.")]
        [RegularExpression("^(USD|EUR|GBP)$", ErrorMessage = "La moneda solo puede ser USD, EUR o GBP.")]
        public string Moneda { get; set; } = null!;
    }
}
