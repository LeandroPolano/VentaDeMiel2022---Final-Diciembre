using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentaDeMiel2022.Servicio.Servicios;
using VentaDeMiel2022.Servicio.Servicios.Facades;

namespace VentaDeMiel2022.Web.Controllers
{
    public class TipoDeDocumentoController : Controller
    {
        private readonly IServicioTipoDeDocumentos servicio;

        public TipoDeDocumentoController(ServicioTipoDeDocumento servicio)
        {

            this.servicio = servicio;

        }
        // GET: TipoDocumento
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ListarTipoDocumento()
        {
            var lista = servicio.GetLista();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
    }
}