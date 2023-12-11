using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VentaDeMiel2022.Datos.Repositorio.Facade;
using VentaDeMiel2022.Entidades.Dtos;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Entidades.Enum;

namespace VentaDeMiel2022.Datos.Repositorio
{
    public class RepositorioProvincia:IRepositorioProvincia
    {
        private readonly VentaDeMiel2022DbContext context;

        public RepositorioProvincia(VentaDeMiel2022DbContext ventaDeMiel2022DbContext)
        {
           this. context = ventaDeMiel2022DbContext;
        }

        public void Guardar(Provincia provincia)
        {
            try
            {
                if (provincia.Pais != null)
                {
                    provincia.Pais = null;

                }
                if (provincia.ProvinciaId == 0)
                {
                    context.Provincias.Add(provincia);
                }

                else
                {
                    var provinciasInDb = context.Provincias.SingleOrDefault(p => p.ProvinciaId == provincia.ProvinciaId );
                    provinciasInDb.ProvinciaId = provincia.ProvinciaId;
                    provinciasInDb.NombreProvincia = provincia.NombreProvincia;
                    provinciasInDb.PaisId = provincia.PaisId;
                    


                    context.Entry(provinciasInDb).State = EntityState.Modified;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }

      

       

        public void Borrar(Provincia provincia)
        {
            try
            {
                context.Entry(provincia).State = EntityState.Deleted;
                context.SaveChanges();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Provincia GetProvinciaPorId(int id)
        {
            try
            {
                return context.Provincias
                    .Include(p => p.Pais)
                    .SingleOrDefault(p => p.ProvinciaId == id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool Existe(Provincia provincia)
        {
            try
            {
                if (provincia.ProvinciaId == 0)
                {
                    return context.Provincias
                        .Any(p => p.NombreProvincia == provincia.NombreProvincia && p.PaisId==provincia.PaisId);
                }
                return context.Provincias.Any(p => p.NombreProvincia == provincia.NombreProvincia &&
                                                  p.PaisId == provincia.PaisId  && p.ProvinciaId!=provincia.ProvinciaId);
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
                return context.Provincias
                    .Include(p => p.Pais)
                    .Select(p => new ProvinciaListDto()
                    {
                        ProvinciaId = p.ProvinciaId,
                        NombreProvincia = p.NombreProvincia,
                        Pais = p.Pais.NombrePais


                    }).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Provincia> GetListaAJAX()
        {

            try
            {
                return context.Provincias
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EstaRelacionado(Provincia provincia)
        {
            try
            {
                return context.Localidades
                    .Any(dt => dt.ProvinciaId == provincia.ProvinciaId);
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
                context.Entry(provincia).State = EntityState.Deleted;
                context.SaveChanges();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

   
}
