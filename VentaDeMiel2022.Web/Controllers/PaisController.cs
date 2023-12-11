
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Servicio.Servicios;
using VentaDeMiel2022.Servicio.Servicios.Facades;
using VentaDeMiel2022.Web.App_Start;
using VentaDeMiel2022.Web.Models.Pais;

namespace VentaDeMiel2022.Web.Controllers
{
    public class PaisController : Controller
    {
        private readonly IServicioPais servicio;
        private readonly IMapper mapper;

       
        public PaisController(ServicioPaises servicio)
        {
            this.servicio =servicio;
            mapper = AutoMapperConfig.Mapper;
        }
        // GET: Pais

        public JsonResult ListarPais()
        {
            var lista = servicio.GetLista();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            var lista = servicio.GetLista();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaisEditVm paisVm)
        {
            if (!ModelState.IsValid)
            {
                return View(paisVm);
            }

            try
            {
                Pais pais = mapper.Map<Pais>(paisVm);
                if (servicio.Existe(pais))
                {
                    ModelState.AddModelError(string.Empty, "Pais existente");
                    return View(paisVm);
                }

                servicio.Guardar(pais);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(paisVm);
            }

            //servicio.Guardar(pais);
            //return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Pais pais = servicio.GetPaisPorId(id.Value);
            if (pais == null)
            {
                return HttpNotFound("Código de Pais inexistente");
            }

            PaisEditVm paisVm = mapper.Map<PaisEditVm>(pais);
            return View(paisVm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PaisEditVm paisVm)
        {
            if (!ModelState.IsValid)
            {
                return View(paisVm);
            }

            Pais pais = mapper.Map<Pais>(paisVm);
            try
            {
                if (servicio.Existe(pais))
                {
                    ModelState.AddModelError(string.Empty, "Pais existente");
                    return View(paisVm);
                }
                servicio.Guardar(pais);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(paisVm);
            }
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            Pais pais = servicio.GetPaisPorId(id.Value);
            if (pais == null)
            {
                return HttpNotFound("Código de marca inexistente!!!");
            }

            PaisEditVm paisVm = mapper.Map<PaisEditVm>(pais);
            return View(paisVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            Pais pais = servicio.GetPaisPorId(id);
            try
            {
                if (servicio.EstaRelacionado(pais))
                {
                    PaisEditVm paisVm = mapper.Map<PaisEditVm>(pais);
                    ModelState.AddModelError(string.Empty, "Pais relacionado");
                    return View(paisVm);
                }
                
                servicio.BorrarPais(pais);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                PaisEditVm paisVm = mapper.Map<PaisEditVm>(pais);
                ModelState.AddModelError(string.Empty, e.Message);
                return View(paisVm);
            }
        }

    }


    
}