using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Entidades.Dtos;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Entidades.Enum;

namespace VentaDeMiel2022.Servicio.Servicios.Facades
{
    public interface IServicioProvincia
    {
        void Guardar(Provincia provincia);

        List<ProvinciaListDto> GetLista();
        void Borrar(Provincia provincia);

        List<Provincia> GetListaAJAX();
        Provincia GetProvinciaPorId(int id);

        bool Existe(Provincia provincia);
        bool EstaRelacionado(Provincia provincia);
        void BorrarProvincia(Provincia provincia);
    }
}
