using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Datos.Repositorio.Facade;
using VentaDeMiel2022.Entidades.Dtos;
using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Datos.Repositorio
{
    public class RepositorioTiposEnvases : IRepositorioTiposEnvases
    {
        private readonly VentaDeMiel2022DbContext context;

        public RepositorioTiposEnvases(VentaDeMiel2022DbContext ventaDeMiel2022DbContext)
        {
            this.context = ventaDeMiel2022DbContext;
        }

        public void Borrar(TipoEnvase tipoEnvase)
        {
            try
            {
                var tipoEnvaseInDb = context.TipoEnvases.SingleOrDefault(p => p.TipoEnvaseId == tipoEnvase.TipoEnvaseId);
                context.Entry(tipoEnvaseInDb).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Editar(TipoEnvase tipoEnvase)
        {
            try
            {
                var tipoEnvaseInDb = GetTipoEnvasePorId(tipoEnvase.TipoEnvaseId);
                tipoEnvaseInDb.Descripcion = tipoEnvase.Descripcion;
                context.Entry(tipoEnvaseInDb).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EstaRelacionado(TipoEnvase tipoEnvase)
        {
            try
            {
                // Verifica si existe alguna relación con otras entidades (ajusta según tu modelo de datos)
                return context.Envases.Any(c => c.TipoEnvaseId == tipoEnvase.TipoEnvaseId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Existe(TipoEnvase tipoEnvase)
        {
            try
            {
                if (tipoEnvase.TipoEnvaseId == 0)
                {
                    return context.TipoEnvases.Any(p => p.Descripcion == tipoEnvase.Descripcion);
                }
                return context.TipoEnvases.Any(p => p.Descripcion == tipoEnvase.Descripcion && p.TipoEnvaseId != tipoEnvase.TipoEnvaseId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TipoEnvase> GetLista()
        {
            return context.TipoEnvases
                    .AsNoTracking()
                    .ToList();
        }

        public TipoEnvase GetTipoEnvasePorId(int id)
        {
            try
            {
                var tipoEnvaseInDb = context.TipoEnvases
                    .AsNoTracking()
                    .SingleOrDefault(p => p.TipoEnvaseId == id);
                return tipoEnvaseInDb;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Guardar(TipoEnvase tipoEnvase)
        {
            try
            {
                if (tipoEnvase.TipoEnvaseId == 0)
                {
                    context.TipoEnvases.Add(tipoEnvase);
                }
                else
                {
                    var tipoEnvaseInDb = context.TipoEnvases.SingleOrDefault(c => c.TipoEnvaseId == tipoEnvase.TipoEnvaseId);
                    tipoEnvaseInDb.TipoEnvaseId = tipoEnvase.TipoEnvaseId;
                    tipoEnvaseInDb.Descripcion = tipoEnvase.Descripcion;
                    context.Entry(tipoEnvaseInDb).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
