using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using VentaDeMiel2022.Entidades.Dtos;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Servicio.Servicios.Facades;
using VentaDeMiel2022.Web.App_Start;
using VentaDeMiel2022.Web.Models.TipoEnvase;
using VentaDeMiel2022.Web.ViewModels.TipoEnvase;

namespace VentaDeMiel2022.Web.Controllers
{
    public class TiposEnvasesController : Controller
    {
        private readonly IServicioTiposEnvases servicio;
        private readonly IMapper mapper;

        public TiposEnvasesController(IServicioTiposEnvases servicio)
        {
            this.servicio = servicio;
            mapper = AutoMapperConfig.Mapper;
        }

        public JsonResult ListarTiposEnvases()
        {
            var lista = servicio.GetLista();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            var lista = servicio.GetLista();
            var listaVm = mapper.Map<List<TipoEnvaseListDto>>(lista);
            return View(listaVm);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoEnvaseEditVm tipoEnvaseVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoEnvaseVm);
            }

            try
            {
                TipoEnvase tipoEnvase = mapper.Map<TipoEnvase>(tipoEnvaseVm);
                if (servicio.Existe(tipoEnvase))
                {
                    ModelState.AddModelError(string.Empty, "Tipo de Envase existente");
                    return View(tipoEnvaseVm);
                }

                servicio.Guardar(tipoEnvase);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoEnvaseVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoEnvase tipoEnvase = servicio.GetTipoEnvasePorId(id.Value);
            if (tipoEnvase == null)
            {
                return HttpNotFound("Código de Tipo de Envase inexistente");
            }

            TipoEnvaseEditVm tipoEnvaseVm = mapper.Map<TipoEnvaseEditVm>(tipoEnvase);
            return View(tipoEnvaseVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoEnvaseEditVm tipoEnvaseVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoEnvaseVm);
            }

            TipoEnvase tipoEnvase = mapper.Map<TipoEnvase>(tipoEnvaseVm);
            try
            {
                if (servicio.Existe(tipoEnvase))
                {
                    ModelState.AddModelError(string.Empty, "Tipo de Envase existente");
                    return View(tipoEnvaseVm);
                }
                servicio.Guardar(tipoEnvase);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoEnvaseVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEnvase tipoEnvase = servicio.GetTipoEnvasePorId(id.Value);
            if (tipoEnvase == null)
            {
                return HttpNotFound("Código de Tipo de Envase inexistente");
            }
            TipoEnvaseListVm tipoEnvaseVm = mapper.Map<TipoEnvaseListVm>(tipoEnvase);
            return View(tipoEnvaseVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            TipoEnvase tipoEnvase = servicio.GetTipoEnvasePorId(id);
            try
            {
                if (servicio.EstaRelacionado(tipoEnvase))
                {
                    TipoEnvaseEditVm tipoEnvaseVm = mapper.Map<TipoEnvaseEditVm>(tipoEnvase);
                    ModelState.AddModelError(string.Empty, "Tipo de Envase relacionado");
                    return View(tipoEnvaseVm);
                }

                servicio.Borrar(tipoEnvase);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TipoEnvaseEditVm tipoEnvaseVm = mapper.Map<TipoEnvaseEditVm>(tipoEnvase);
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoEnvaseVm);
            }
        }
    }
}
