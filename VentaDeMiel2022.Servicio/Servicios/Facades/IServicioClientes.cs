using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Entidades.Enum;

namespace VentaDeMiel2022.Servicio.Servicios.Facades
{
    public interface IServicioClientes
    {
        void Guardar(Cliente cliente);

        List<Cliente> GetLista();


        void Borrar(Cliente clienteId);

        Cliente GetClientePorId(int id);

        bool Existe(Cliente cliente);
        bool EstaRelacionado(Cliente cliente);
    }
}
