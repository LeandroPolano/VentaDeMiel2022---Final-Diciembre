using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using VentaDeMiel2022.Entidades.Dtos;
using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Web.Models.Envase
{
    public class EnvaseEditVm
    {
        public int EnvaseId { get; set; }

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string Descripcion { get; set; }

        [DisplayName("Tipo de Envase")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de envase")]
        public int TipoEnvaseId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public int Stock { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public decimal Precio { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Imagen { get; set; }
        public string ImagenActual { get; set; }


        //public List<Entidades.Entidades.TipoEnvase> TiposEnvase { get; set; }
        public List<Entidades.Entidades.TipoEnvase> TiposEnvase { get; set; }
        public HttpPostedFileBase ImagenFile { get; set; }
    }
}
