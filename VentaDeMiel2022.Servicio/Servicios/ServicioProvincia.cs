using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Datos;
using VentaDeMiel2022.Datos.Repositorio;
using VentaDeMiel2022.Datos.Repositorio.Facade;
using VentaDeMiel2022.Entidades.Dtos;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Entidades.Enum;
using VentaDeMiel2022.Servicio.Servicios.Facades;

namespace VentaDeMiel2022.Servicio.Servicios
{
    public class ServicioProvincia:IServicioProvincia
    {
        private readonly IRepositorioProvincia repositorio;
        private readonly IUnitOfWork unitOfWork;
        private readonly VentaDeMiel2022DbContext context;
        public ServicioProvincia(RepositorioProvincia repositorio, VentaDeMiel2022DbContext context, UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repositorio = repositorio;
            this.context = context;
        }

        

        public void Guardar(Provincia provincia)
        {
            try
            {
                repositorio.Guardar(provincia);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(Provincia provincia)
        {
            try
            {
                repositorio.Borrar(provincia);
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Provincia GetProvinciaPorId(int id)
        {
            try
            {
                return repositorio.GetProvinciaPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Provincia provincia)
        {
            try
            {
                return repositorio.Existe(provincia);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ProvinciaListDto> GetLista()
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
     
        public bool EstaRelacionado(Provincia provincia)
        {
            try
            {
                return repositorio.EstaRelacionado(provincia);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void BorrarProvincia(Provincia provincia)
        {
            try
            {
                repositorio.BorrarProvincia(provincia);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        List<Provincia> IServicioProvincia.GetListaAJAX()
        {

            try
            {
                return repositorio.GetListaAJAX();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Pais p;
        public Orden orden;



    }
}
