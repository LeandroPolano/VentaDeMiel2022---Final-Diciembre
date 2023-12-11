using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VentaDeMiel2022.Web.Models.Provincia
{
    public class ProvinciaEditVm
    {
        public int ProvinciaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        [DisplayName("Nombre de provincia")]
        public string NombreProvincia { get; set; }  

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DisplayName("Pais")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Pais")]
        public int PaisId { get; set; }

        public List<Entidades.Entidades.Pais> Paises { get; set; }
    }
}