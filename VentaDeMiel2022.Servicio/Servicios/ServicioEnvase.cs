using System;
using System.Collections.Generic;
using VentaDeMiel2022.Datos;
using VentaDeMiel2022.Datos.Repositorios.Facades;
using VentaDeMiel2022.Entidades.Dtos;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Servicios.Servicios.Facades;

namespace VentaDeMiel2022.Servicios.Servicios
{
    public class ServicioEnvases : IServicioEnvases
    {
        private readonly VentaDeMiel2022DbContext context;
        private readonly IRepositorioEnvases repositorio;
        private readonly IUnitOfWork unitOfWork;

        public ServicioEnvases(IRepositorioEnvases repositorio, VentaDeMiel2022DbContext context, UnitOfWork unitOfWork)
        {
            this.context = context;
            this.repositorio = repositorio;
            this.unitOfWork = unitOfWork;
        }

        public List<EnvaseListDto> GetLista()
        {
            try
            {
                return repositorio.GetLista();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Existe(Envase envase)
        {
            try
            {
                return repositorio.Existe(envase);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Guardar(Envase envase)
        {
            try
            {
                repositorio.Guardar(envase);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Envase GetEnvasePorId(int id)
        {
            try
            {
                return repositorio.GetEnvasePorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public List<EnvaseListDto> GetLista(int tipoEnvaseId)
        //{
        //    try
        //    {
        //        return repositorio.GetLista(tipoEnvaseId);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        throw;
        //    }
        //}
    }
}
