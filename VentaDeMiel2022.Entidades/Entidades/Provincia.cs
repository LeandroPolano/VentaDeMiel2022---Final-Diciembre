using System;

namespace VentaDeMiel2022.Entidades.Entidades
{
    public class Provincia : ICloneable
    {
        public int ProvinciaId { get; set; }

        public string NombreProvincia { get; set; }

        public int PaisId { get; set; }

        public Pais Pais { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();

        }

    }
}
