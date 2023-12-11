using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel2022.Entidades.Entidades
{
    public class Proveedor : ICloneable
    {
        public int ProveedorId { get; set; }
        public string NombreEstablecimiento { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int TipoDeDocumentoId { get; set; }
        public string NroDocumento { get; set; }

        public string Direccion { get; set; }

        public int LocalidadId { get; set; }
        public int ProvinciaId { get; set; }

        public int PaisId { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }



        public virtual TipoDeDocumento TipoDeDocumento { get; set; }
        public virtual Localidad Localidad { get; set; }
        public virtual Provincia Provincia { get; set; }
        public virtual Pais Pais { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
