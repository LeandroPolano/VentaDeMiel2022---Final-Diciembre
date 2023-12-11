using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VentaDeMiel2022.Entidades.Dtos;

namespace VentaDeMiel2022.Web.Models.Localidad
{
    public class LocalidadEditVm
    {
        public int LocalidadId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        [DisplayName("Nombre de localidad")]
        public string NombreLocalidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DisplayName("Provincia")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una provincia")]
        public int ProvinciaId { get; set; }

        public List<ProvinciaListDto> ProvinciasDto { get; set; }

        public List<Entidades.Entidades.Pais> Paises { get; set; }
    }
}