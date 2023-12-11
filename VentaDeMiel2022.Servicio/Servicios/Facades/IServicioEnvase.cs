using System.Collections.Generic;
using VentaDeMiel2022.Entidades.Dtos;
using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Servicios.Servicios.Facades
{
    public interface IServicioEnvases
    {
        List<EnvaseListDto> GetLista();
        bool Existe(Envase envase);
        void Guardar(Envase envase);
        Envase GetEnvasePorId(int id);
        //List<EnvaseListDto> GetLista(int tipoEnvaseId);
    }
}
