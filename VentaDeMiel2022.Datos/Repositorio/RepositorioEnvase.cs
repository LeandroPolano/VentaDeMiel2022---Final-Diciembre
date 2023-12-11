using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VentaDeMiel2022.Datos.Repositorios.Facades;
using VentaDeMiel2022.Entidades.Dtos;
using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Datos.Repositorios
{
    public class RepositorioEnvases : IRepositorioEnvases
    {

        private VentaDeMiel2022DbContext context;

        public RepositorioEnvases(VentaDeMiel2022DbContext context)
        {
            this.context = context;
        }

        public List<EnvaseListDto> GetLista()
        {
            try
            {
                return context.Envases
                    .Include(e => e.TipoEnvase)
                    .Select(e => new EnvaseListDto()
                    {
                        EnvaseId = e.EnvaseId,
                        Descripcion = e.Descripcion,
                        TipoEnvase = e.TipoEnvase.Descripcion,
                        Precio = e.Precio,
                        Stock = e.Stock,
                        Imagen = e.Imagen
                    }).ToList();
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
                if (envase.EnvaseId == 0)
                {
                    return context.Envases
                        .Any(e => e.Descripcion == envase.Descripcion &&
                        e.TipoEnvaseId == envase.TipoEnvaseId); 
                    ;
                }

                return context.Envases
                    .Any(e => e.Descripcion == envase.Descripcion
                              && e.EnvaseId != envase.EnvaseId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Guardar(Envase envase)
        {
            try
            {
                if (envase.EnvaseId == 0)
                {
                    context.Envases.Add(envase);
                }
                else
                {
                    var envaseInDb = context.Envases.SingleOrDefault(e => e.EnvaseId == envase.EnvaseId);
                    if (envaseInDb != null)
                    {
                        envaseInDb.EnvaseId = envase.EnvaseId;
                        envaseInDb.Descripcion = envase.Descripcion;
                        envaseInDb.TipoEnvaseId = envase.TipoEnvaseId;
                        envaseInDb.Precio = envase.Precio;
                        envaseInDb.Stock = envase.Stock;

                        // Verificar si la columna Imagen ha cambiado antes de actualizarla
                        if (envaseInDb.Imagen != envase.Imagen)
                        {
                            // Actualizar la imagen solo si ha cambiado
                            envaseInDb.Imagen = envase.Imagen;

                            // También puedes agregar lógica para eliminar la imagen anterior si es necesario
                            // HelperFile.DeletePhoto(envaseInDb.Imagen);
                        }

                        context.Entry(envaseInDb).State = EntityState.Modified;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Envase GetEnvasePorId(int id)
        {
            try
            {
                return context.Envases
                    .Include(e => e.TipoEnvase)
                    .SingleOrDefault(e => e.EnvaseId == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //public List<EnvaseListDto> GetLista(int tipoEnvaseId)
        //{
        //    try
        //    {
        //        IQueryable<Envase> query = context.Envases;
        //        if (tipoEnvaseId > 0)
        //        {
        //            query = query.Where(e => e.TipoEnvaseId == tipoEnvaseId);
        //        }

        //        query = query.Include(e => e.TipoEnvase);
        //        var lista = query.Select(e => new EnvaseListDto()
        //        {
        //            EnvaseId = e.EnvaseId,
        //            Descripcion = e.Descripcion,
        //            TipoEnvase = e.Descripcion,
        //            Precio = e.Precio,
        //            Stock = e.Stock,
        //            Imagen = e.Imagen
        //        }).ToList();
        //        return lista;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        public void ActualizarStock(int envaseId, int cantidad, bool suma)
        {
            try
            {
                var envaseInDb = context.Envases.SingleOrDefault(e => e.EnvaseId == envaseId);
                if (envaseInDb != null)
                {
                    if (suma)
                    {
                        envaseInDb.Stock += cantidad;
                    }
                    else
                    {
                        envaseInDb.Stock -= cantidad;
                    }

                    context.Entry(envaseInDb).State = EntityState.Modified;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
