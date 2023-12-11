using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Datos.Repositorio.Facade;
using VentaDeMiel2022.Entidades.Dtos;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Entidades.Enum;
using EntityState = System.Data.Entity.EntityState;

namespace VentaDeMiel2022.Datos.Repositorio
{
    public class RepositorioLocalidades : IRepositorioLocalidad
    {
        private readonly VentaDeMiel2022DbContext context;

        public RepositorioLocalidades(VentaDeMiel2022DbContext ventaDeMiel2022DbContext)
        {
            this.context = ventaDeMiel2022DbContext;
        }

        public void Guardar(Localidad localidad)
        {

            try
            {
                if (localidad.NombreProvincia != null)
                {
                    context.Provincias.Attach(localidad.NombreProvincia);
                }
                if (localidad.LocalidadId == 0)
                {
                    context.Localidades.Add(localidad);


                }
                else
                {
                    var LocalidadesInDb = context.Localidades.SingleOrDefault(p => p.LocalidadId == localidad.LocalidadId);
                    if (LocalidadesInDb == null)
                    {
                        throw new Exception("Código de localidad inexistente");
                    }

                    LocalidadesInDb.NombreLocalidad = localidad.NombreLocalidad;
                    LocalidadesInDb.ProvinciaId = localidad.ProvinciaId;


                    context.Entry(LocalidadesInDb).State = EntityState.Modified;

                }


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<Localidad> GetLista(Provincia p = null, Orden orden = Orden.BD)
        {
            try
            {
                IQueryable<Localidad> query = context.Localidades
                    .Include(p => p.NombreProvincia);
                if (p != null)
                {
                    query = query.Where(p => p.ProvinciaId == p.ProvinciaId);
                }

                switch (orden)
                {
                    case Orden.BD:
                        break;
                    case Orden.AZ:
                        query = query.OrderBy(p => p.NombreLocalidad);
                        break;
                    case Orden.ZA:
                        query = query.OrderByDescending(p => p.NombreLocalidad);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(orden), orden, null);
                }
                return query
                    //.AsNoTracking()
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(int localidadID)
        {
            try
            {
                var localidadInDb = context.Localidades.SingleOrDefault(p => p.LocalidadId == localidadID);
                if (localidadInDb == null)
                {
                    throw new Exception("Código de localidad inexistente");
                }

                context.Entry(localidadInDb).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Localidad GetLocalidadPorId(int id)
        {
            try
            {
                return context.Localidades
                    .Include(p => p.NombreProvincia)
                    .SingleOrDefault(p => p.LocalidadId == id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool Existe(Localidad localidad)
        {
            try
            {
                if (localidad.LocalidadId == 0)
                {
                    return context.Localidades
                        .Any(p => p.NombreLocalidad == localidad.NombreLocalidad && p.ProvinciaId == localidad.ProvinciaId);
                }
                return context.Localidades.Any(p => p.NombreLocalidad == localidad.NombreLocalidad &&
                                                   p.LocalidadId != localidad.LocalidadId &&
                                                   p.ProvinciaId == localidad.ProvinciaId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Localidad localidad)
        {
            try
            {
                return context.Clientes
                    .Any(dt => dt.LocalidadId == localidad.LocalidadId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<LocalidadListDto> GetLista2()
        {
            try
            {
                return context.Localidades
                    .Include(p => p.NombreProvincia)
                    .Select(p => new LocalidadListDto()
                    {
                        LocalidadId = p.LocalidadId,
                        NombreLocalidad = p.NombreLocalidad,
                        Provincia = p.NombreProvincia.NombreProvincia,


                    }).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void BorrarLocalidad(Localidad localidad)
        {
            try
            {
                context.Entry(localidad).State = EntityState.Deleted;
                context.SaveChanges();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
