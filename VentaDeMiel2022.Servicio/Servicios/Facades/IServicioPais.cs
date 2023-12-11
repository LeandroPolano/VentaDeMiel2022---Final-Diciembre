using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Servicio.Servicios.Facades
{
   public interface IServicioPais
    {
        void Guardar(Pais pais);

        List<Pais> GetLista();

        void Borrar(int paisId);
        void BorrarPais(Pais pais);
        Pais GetPaisPorId(int id);

        bool Existe(Pais pais);
        bool EstaRelacionado(Pais pais);
    }
}
