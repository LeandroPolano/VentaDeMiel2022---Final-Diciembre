using System.ComponentModel;

namespace VentaDeMiel2022.Web.Models.Envase
{
    public class EnvaseListVm
    {
        public int EnvaseId { get; set; }
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }
        [DisplayName("Tipo de Envase")]
        public string TipoEnvase { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public string Imagen { get; set; }
    }
}
