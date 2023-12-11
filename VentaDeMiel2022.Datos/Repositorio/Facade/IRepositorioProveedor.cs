using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Datos.Repositorio.Facade
{
    public interface IRepositorioProveedor
    {
        void Guardar(Entidades.Entidades.Proveedor proveedor);

        List<Entidades.Entidades.Proveedor> GetLista();
        //List<Entidades.Dtos.Cliente.ClienteListDto> GetLista2();
        void Borrar(Proveedor proveedorId);

        Entidades.Entidades.Proveedor GetProveedorPorId(int id);

        bool Existe(Entidades.Entidades.Proveedor proveedor);
        bool EstaRelacionado(Entidades.Entidades.Proveedor proveedor);

    }
}
