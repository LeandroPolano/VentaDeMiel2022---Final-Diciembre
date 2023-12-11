using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VentaDeMiel2022.Web.Models.Provincia
{
    public class ProvinciaListVm
    {
        public int ProvinciaId { get; set; }

        [DisplayName("Provincia")]
        public string NombreProvincia { get; set; }

        [DisplayName("Pais")]
        public string Pais { get; set; }
    }
}