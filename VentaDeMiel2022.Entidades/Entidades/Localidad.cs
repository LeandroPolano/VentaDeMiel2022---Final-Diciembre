using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel2022.Entidades.Entidades
{
    public class Localidad : ICloneable

    {
        public int LocalidadId { get; set; }

        public string NombreLocalidad { get; set; }

        public int ProvinciaId { get; set; }

        public Provincia NombreProvincia { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
