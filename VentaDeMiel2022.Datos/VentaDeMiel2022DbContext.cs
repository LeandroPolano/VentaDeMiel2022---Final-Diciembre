using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Datos
{
    public class VentaDeMiel2022DbContext:DbContext
    {
        public VentaDeMiel2022DbContext() : base("name=MiConexion")
        {
            Database.CommandTimeout = 45; //Establezco el tiempo de espera de respuesta de la BD
            Configuration.UseDatabaseNullSemantics = true; // Acelera el tiempo de respuesta de las queries
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<VentaDeMiel2022DbContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //evita el borrado en cascada
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());//le digo que tome las configuraciones del  mismo assembly

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<TipoDeDocumento> TipoDeDocumentos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<TipoEnvase> TipoEnvases { get; set; }

        public DbSet<Envase> Envases { get; set; }

    }
}



