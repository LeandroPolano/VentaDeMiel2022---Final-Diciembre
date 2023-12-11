using System.Data.Entity.ModelConfiguration;
using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Datos.EntityTypeConfiguration
{
    public class PaisEntityTypeConfiguration : EntityTypeConfiguration<Pais>
    {
        public PaisEntityTypeConfiguration()
        {
            ToTable("Paises");
        }

    }
}

   

   
