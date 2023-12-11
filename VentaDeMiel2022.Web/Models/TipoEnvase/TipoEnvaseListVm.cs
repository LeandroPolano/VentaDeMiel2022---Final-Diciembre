using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace VentaDeMiel2022.Web.ViewModels.TipoEnvase
{
    public class TipoEnvaseListVm
    {
        [DisplayName("Tipo de Envase Nro.")]
        public int TipoEnvaseId { get; set; }

        [DisplayName("Descripción de Tipo de Envase")]
        public string Descripcion { get; set; }
    }
}
