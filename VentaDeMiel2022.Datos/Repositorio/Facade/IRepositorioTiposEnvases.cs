using System;
using System.Collections.Generic;
using VentaDeMiel2022.Entidades.Dtos;
using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Datos.Repositorio.Facade
{
    public interface IRepositorioTiposEnvases
    {
        void Guardar(TipoEnvase tipoEnvase);

        List<TipoEnvase> GetLista();


        void Borrar(TipoEnvase tipoEnvase);

        TipoEnvase GetTipoEnvasePorId(int id);

        void Editar(TipoEnvase tipoEnvase);

        bool Existe(TipoEnvase tipoEnvase);

        bool EstaRelacionado(TipoEnvase tipoEnvase);
    }
}
