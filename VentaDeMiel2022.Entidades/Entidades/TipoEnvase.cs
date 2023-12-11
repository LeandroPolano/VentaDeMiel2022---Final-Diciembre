using System;
using System.Collections.Generic;
using VentaDeMiel2022.Entidades.Dtos;

namespace VentaDeMiel2022.Entidades.Entidades
{
    public class TipoEnvase : ICloneable
    {
        public int TipoEnvaseId { get; set; }

        public string Descripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public List<Envase> Envases { get; set; }

        public TipoEnvase()
        {
            Envases = new List<Envase>();
        }

        // Otros métodos y propiedades...

        //public TipoEnvaseListDto ToTipoEnvaseListDto()
        //{
        //    return new TipoEnvaseListDto()
        //    {
        //        TipoEnvaseId = TipoEnvaseId,
        //        Descripcion = Descripcion
        //    };
        //}
    }
}
