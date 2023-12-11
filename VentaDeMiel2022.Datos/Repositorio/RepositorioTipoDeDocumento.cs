using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Datos.Repositorio.Facade;
using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Datos.Repositorio
{
    public class RepositorioTipoDeDocumento:IRepositorioTipoDeDocumento
    {
        private readonly VentaDeMiel2022DbContext context;
        public RepositorioTipoDeDocumento()
        {
            context = new VentaDeMiel2022DbContext();
        }
        public void Guardar(TipoDeDocumento tipoDeDocumento)
        {
            try
            {

                if (tipoDeDocumento.TipoDeDocumentoId == 0)
                {
                    context.TipoDeDocumentos.Add(tipoDeDocumento);
                }
                else
                {
                    var tipoDeDocumentoInDb = context.TipoDeDocumentos.SingleOrDefault(p => p.TipoDeDocumentoId == tipoDeDocumento.TipoDeDocumentoId);
                    if (tipoDeDocumentoInDb == null)
                    {
                        throw new Exception("Código de Tipo Documento inexistente");
                    }

                    tipoDeDocumentoInDb.Descripcion = tipoDeDocumento.Descripcion;


                    context.Entry(tipoDeDocumentoInDb).State = EntityState.Modified;

                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TipoDeDocumento> GetLista()
        {
            try
            {
                return context.TipoDeDocumentos
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Borrar(int tipoDeDocumentoId)
        {
            try
            {
                var tdInDb = context.TipoDeDocumentos.SingleOrDefault(t => t
                    .TipoDeDocumentoId == tipoDeDocumentoId);
                if (tdInDb == null)
                {
                    throw new Exception("Tipo de Documento no encontrado");
                }

                context.Entry(tdInDb).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
        }

        public TipoDeDocumento GetTipoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(TipoDeDocumento tipoDeDocumento)
        {
            try
            {
                if (tipoDeDocumento.TipoDeDocumentoId == 0)
                {
                    return context.TipoDeDocumentos
                        .Any(tp => tp.Descripcion == tipoDeDocumento.Descripcion);
                }
                return context.TipoDeDocumentos.Any(tp => tp.Descripcion == tipoDeDocumento.Descripcion &&
                                                      tp.TipoDeDocumentoId != tipoDeDocumento.TipoDeDocumentoId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoDeDocumento tipoDeDocumento)
        {
            try
            {
                if (context.Clientes.Any(p => p.TipoDeDocumentoId == tipoDeDocumento.TipoDeDocumentoId))
                {
                    return context.Clientes.Any();

                }
                if (context.Proveedores.Any(p => p.TipoDeDocumentoId == tipoDeDocumento.TipoDeDocumentoId))
                {
                    return context.Proveedores.Any();
                }

                return false;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message); 
            }
            
            
        }
    }
}
