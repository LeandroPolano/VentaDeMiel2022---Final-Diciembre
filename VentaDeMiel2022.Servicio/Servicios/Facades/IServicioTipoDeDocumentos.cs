using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Servicio.Servicios.Facades
{
    public  interface IServicioTipoDeDocumentos
    {
        void Guardar(TipoDeDocumento tipoDeDocumento);
        List<TipoDeDocumento> GetLista();
        void Borrar(int tipoDeDocumentoId);
        TipoDeDocumento GetTipoPorId(int id);
        bool Existe(TipoDeDocumento tipoDeDocumento);
        bool EstaRelacionado(TipoDeDocumento tipoDeDocumento);
    }
}
