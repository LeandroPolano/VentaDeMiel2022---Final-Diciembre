using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VentaDeMiel2022.Web.Models.Pais
{
    public class PaisEditVm
    {
        public int PaisId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        [DisplayName("Nombre de pais")]
        public string NombrePais { get; set; }
    }
}