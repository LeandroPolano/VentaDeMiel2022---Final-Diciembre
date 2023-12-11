using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Servicio.Servicios.Facades;
using VentaDeMiel2022.Servicio.Servicios;

namespace VentaDeMiel2022.Web.Controllers
{
    public class ProveedorController : Controller
    {
        private IServicioProveedor servicio;

        public ProveedorController(ServicioProveedor servicio)
        {
            this.servicio = servicio;
        }
        // GET: Proveedor
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult ListarProveedor()
        {
            var lista = servicio.GetLista();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarProveedor(string objeto)
        {
            object resultado = null;
            string mensaje = string.Empty;

            try
            {

                Proveedor ProveedorRecibido = new Proveedor();
                ProveedorRecibido = JsonConvert.DeserializeObject<Proveedor>(objeto);
                mensaje = ValidarProveedor(ProveedorRecibido);

                if (mensaje == String.Empty)
                {
                    if (!servicio.Existe(ProveedorRecibido))
                    {
                        servicio.Guardar(ProveedorRecibido);
                        resultado = ProveedorRecibido.ProveedorId;
                        mensaje = "Proveedor agregado/editado";
                    }
                    else
                    {
                        resultado = 0;
                        mensaje = "Proveedor existente";
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

        private string ValidarProveedor(Proveedor proveedor)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(proveedor.NombreEstablecimiento))
            {
                sb.AppendLine("Establecimiento del Proveedor requerido");
            }
            if (string.IsNullOrEmpty(proveedor.Nombre))
            {
                sb.AppendLine("Nombre del Proveedor requerido");
            }
            if (string.IsNullOrEmpty(proveedor.Apellido))
            {
                sb.AppendLine("Apellido del Proveedor requerido");
            }

            if ((proveedor.NroDocumento == null))
            {
                sb.AppendLine("Numero De documento del Proveedor es requerido");
            }
            if (proveedor.PaisId == 0)
            {
                sb.AppendLine("Debe seleccionar un país");
            }
            if (proveedor.ProvinciaId == 0)
            {
                sb.AppendLine("Debe seleccionar una provincia");
            }
            if (proveedor.LocalidadId == 0)
            {
                sb.AppendLine("Debe seleccionar una localidad");
            }
            if (proveedor.TipoDeDocumentoId == 0)
            {
                sb.AppendLine("Debe seleccionar una tipo de documento");
            }

            return sb.ToString();
        }


        [HttpPost]
        public JsonResult EliminarProveedor(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;
            try
            {
                Proveedor proveedor = servicio.GetProveedorPorId(id);
                if (!servicio.EstaRelacionado(proveedor))
                {
                    servicio.Borrar(proveedor);
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