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
    public class ServicioPaises : IServicioPais
    {
        private readonly IRepositorioPais repositorio;
        private readonly IUnitOfWork unitOfWork;

        private readonly VentaDeMiel2022DbContext context;

        public ServicioPaises(UnitOfWork unitOfWork, VentaDeMiel2022DbContext context, RepositorioPaises paises)
        {
            this.unitOfWork = unitOfWork;
            this.context = context;
            this.repositorio = paises;
        }
        void IServicioPais.Guardar(Pais pais)
        {
            try
            {
                repositorio.Guardar(pais);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<Pais> GetLista()
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

        public void Borrar(int paisId)
        {
            try
            {
                repositorio.Borrar(paisId);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
       

        public Pais GetPaisPorId(int id)
        {
            try
            {
                return context.Paises.SingleOrDefault(c => c.PaisId == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Existe(Pais pais)
        {
            try
            {
                return repositorio.Existe(pais);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Pais pais)
        {
            try
            {
                return repositorio.EstaRelacionado(pais);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void BorrarPais(Pais pais)
        {
            try
            {
                repositorio.BorrarPais(pais);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
