using System;
using System.Collections.Generic;
using System.Linq;
using VentaDeMiel2022.Datos;
using VentaDeMiel2022.Datos.Repositorio.Facade;
using VentaDeMiel2022.Entidades.Dtos;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Servicio.Servicios.Facades;

namespace VentaDeMiel2022.Servicio.Servicios
{
    public class ServicioTiposEnvases : IServicioTiposEnvases
    {
        private readonly IRepositorioTiposEnvases repositorioTiposEnvases;
        private readonly IUnitOfWork _unitOfWork;
        private readonly VentaDeMiel2022DbContext context;

        public ServicioTiposEnvases(IRepositorioTiposEnvases repositorio, IUnitOfWork unitOfWork, VentaDeMiel2022DbContext context)
        {
            repositorioTiposEnvases = repositorio;
            _unitOfWork = unitOfWork;
            this.context = context;
        }

        public void Borrar(TipoEnvase tipoEnvase)
        {
            try
            {
                repositorioTiposEnvases.Borrar(tipoEnvase);
                _unitOfWork.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void BorrarTipoEnvase(TipoEnvase tipoEnvase)
        {
            try
            {
                repositorioTiposEnvases.Borrar(tipoEnvase);
                _unitOfWork.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Editar(TipoEnvase tipoEnvase)
        {
            try
            {
                repositorioTiposEnvases.Editar(tipoEnvase);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoEnvase tipoEnvase)
        {
            try
            {
                return repositorioTiposEnvases.EstaRelacionado(tipoEnvase);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoEnvase tipoEnvase)
        {
            try
            {
                return repositorioTiposEnvases.Existe(tipoEnvase);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TipoEnvase> GetLista()
        {
            try
            {
                return repositorioTiposEnvases.GetLista();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TipoEnvase GetTipoEnvasePorId(int id)
        {
            try
            {
                return context.TipoEnvases.SingleOrDefault(c => c.TipoEnvaseId == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Guardar(TipoEnvase tipoEnvase)
        {
            try
            {
                repositorioTiposEnvases.Guardar(tipoEnvase);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
