using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Servicio.Servicios;
using VentaDeMiel2022.Servicio.Servicios.Facades;

namespace VentaDeMiel2022.Web.Controllers
{
    public class ClienteController : Controller
    {
        private IServicioClientes servicio;

        public ClienteController(ServicioCliente servicio)
        {
            this.servicio = servicio;
        }
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult ListarClientes()
        {
            var lista = servicio.GetLista();
            return Json(new { data = lista}, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarCliente(string objeto)
        {
            object resultado = null;
            string mensaje = string.Empty;
           
            try
            {
               
                Cliente clienteRecibido = new Cliente();
                clienteRecibido = JsonConvert.DeserializeObject<Cliente>(objeto);
                mensaje = ValidarCliente(clienteRecibido);

                if (mensaje == String.Empty)
                {
                    if (!servicio.Existe(clienteRecibido))
                    {
                        servicio.Guardar(clienteRecibido);
                        resultado = clienteRecibido.ClienteId;
                        mensaje = "Cliente agregado/editado";
                    }
                    else
                    {
                        resultado = 0;
                        mensaje = "Cliente existente";
                    }
                }
                else
                {
                    resultado = 0;
                }
            }
            catch (Exception e)
            {
                resultado = 0;
                mensaje = e.Message;

            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        private string ValidarCliente(Cliente cliente)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(cliente.Nombre))
            {
                sb.AppendLine("Nombre del cliente requerido");
            }
            if (string.IsNullOrEmpty(cliente.Apellido))
            {
                sb.AppendLine("Apellido del cliente requerido");
            }
        
            if ((cliente.NroDocumento == null ))
            {
                sb.AppendLine("Numero De documento del cliente es requerido" );
            }
            if (cliente.PaisId == 0)
            {
                sb.AppendLine("Debe seleccionar un país");
            }
            if (cliente.ProvinciaId == 0)
            {
                sb.AppendLine("Debe seleccionar una provincia");
            }
            if (cliente.LocalidadId == 0)
            {
                sb.AppendLine("Debe seleccionar una localidad");
            }
            if (cliente.TipoDeDocumentoId == 0)
            {
                sb.AppendLine("Debe seleccionar una tipo de documento");
            }

            return sb.ToString();
        }


        [HttpPost]
        public JsonResult EliminarCliente(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            try
            {
                Cliente cliente = servicio.GetClientePorId(id);
                if (!servicio.EstaRelacionado(cliente))
                {
                    servicio.Borrar(cliente);
                    respuesta = true;
                    mensaje = "Registro eliminado";
                }
                else
                {
                    respuesta = false;
                    mensaje = "Registro relacionado... Baja denegada";
                }
            }
            catch (Exception e)
            {
                respuesta = false;
                mensaje = e.Message;
            }

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


    }
}