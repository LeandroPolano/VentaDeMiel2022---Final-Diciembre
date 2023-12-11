using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Datos.Repositorio;
using VentaDeMiel2022.Datos.Repositorio.Facade;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Servicio.Servicios.Facades;

namespace VentaDeMiel2022.Servicio.Servicios
{
    public class ServicioTipoDeDocumento:IServicioTipoDeDocumentos
    {
        private readonly IRepositorioTipoDeDocumento repositorio;

        public ServicioTipoDeDocumento()
        {
            repositorio = new RepositorioTipoDeDocumento();
        }
        public void Guardar(TipoDeDocumento tipoDeDocumento)
        {
            try
            {
                repositorio.Guardar(tipoDeDocumento);
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
                return repositorio.GetLista();
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
                repositorio.Borrar(tipoDeDocumentoId);
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
                return repositorio.Existe(tipoDeDocumento);
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
                return repositorio.EstaRelacionado(tipoDeDocumento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
