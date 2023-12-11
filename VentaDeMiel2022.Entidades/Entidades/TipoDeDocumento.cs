using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel2022.Entidades.Entidades
{
   public class TipoDeDocumento:ICloneable
    {
        public int TipoDeDocumentoId { get; set; }

        public string Descripcion { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();

        }
    }
}
