using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Datos;
using VentaDeMiel2022.Datos.Repositorio;
using VentaDeMiel2022.Datos.Repositorio.Facade;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Servicio.Servicios.Facades;

namespace VentaDeMiel2022.Servicio.Servicios
{
    public class ServicioProveedor : IServicioProveedor
    {
        private readonly IRepositorioProveedor repositorio;
        private readonly VentaDeMiel2022DbContext context;
        public ServicioProveedor()
        {
            repositorio = new RepositorioProveedor();
            context = new VentaDeMiel2022DbContext();
        }

        public void Guardar(Proveedor proveedor)
        {
            try
            {
                repositorio.Guardar(proveedor);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public List<Proveedor> GetLista()
        {
            try
            {
                return repositorio.GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(Proveedor proveedorId)
        {
            try
            {
                repositorio.Borrar(proveedorId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Proveedor GetProveedorPorId(int id)
        {
            try
            {
                return repositorio.GetProveedorPorId(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool Existe(Proveedor proveedor)
        {
            try
            {
                return repositorio.Existe(proveedor);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Proveedor proveedor)
        {
            try
            {
                return repositorio.EstaRelacionado(proveedor);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
