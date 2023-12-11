using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Datos;
using VentaDeMiel2022.Datos.Repositorio;
using VentaDeMiel2022.Datos.Repositorio.Facade;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Entidades.Enum;
using VentaDeMiel2022.Servicio.Servicios.Facades;

namespace VentaDeMiel2022.Servicio.Servicios
{
    public class ServicioCliente : IServicioClientes
    {
        private readonly IRepositorioCliente repositorio;
        private readonly VentaDeMiel2022DbContext context;


        public ServicioCliente()
        {
            repositorio = new RepositorioClientes();
            context = new VentaDeMiel2022DbContext();
        }
        public void Guardar(Cliente cliente)
        {
            try
            {
                repositorio.Guardar(cliente);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public List<Cliente> GetLista()
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

        public void Borrar(Cliente clienteId)
        {
            try
            {
                repositorio.Borrar(clienteId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Cliente GetClientePorId(int id)
        {
            try
            {
                return repositorio.GetClientePorId(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool Existe(Cliente cliente)
        {
            try
            {
                return repositorio.Existe(cliente);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Cliente cliente)
        {
            try
            {
                return repositorio.EstaRelacionado(cliente);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
