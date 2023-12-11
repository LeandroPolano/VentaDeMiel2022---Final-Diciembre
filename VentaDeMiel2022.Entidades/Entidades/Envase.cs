using System;
using System.Collections.Generic;
using System.Linq;
using VentaDeMiel2022.Entidades.Dtos;

namespace VentaDeMiel2022.Entidades.Entidades
{
    public class Envase : ICloneable
    {
        public int EnvaseId { get; set; }

        public string Descripcion { get; set; }
        public int TipoEnvaseId { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public string Imagen { get; set; }

        public TipoEnvase TipoEnvase { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
