using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VentaDeMiel2022.Web.Models.Pais
{
    public class PaisListVm
    {
        public int PaisId { get; set; }

        [DisplayName("Pais")]
        public string NombrePais { get; set; }
    }
}