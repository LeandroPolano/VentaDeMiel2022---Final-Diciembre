using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Servicio.Servicios.Facades
{
    public interface IServicioProveedor
    {
        void Guardar(Proveedor proveedor);

        List<Proveedor> GetLista();


        void Borrar(Proveedor proveedorId);

        Proveedor GetProveedorPorId(int id);

        bool Existe(Proveedor proveedor);
        bool EstaRelacionado(Proveedor proveedor);
    }
}
