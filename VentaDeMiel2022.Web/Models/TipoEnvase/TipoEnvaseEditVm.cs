using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace VentaDeMiel2022.Web.Models.TipoEnvase
{
    public class TipoEnvaseEditVm
    {
        public int TipoEnvaseId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        [DisplayName("Nombre de Tipo de Envase")]
        public string Descripcion { get; set; }
    }
}
