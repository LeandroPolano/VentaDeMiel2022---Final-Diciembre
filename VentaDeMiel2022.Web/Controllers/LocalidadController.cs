using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VentaDeMiel2022.Entidades.Dtos;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Servicio.Servicios;
using VentaDeMiel2022.Servicio.Servicios.Facades;
using VentaDeMiel2022.Web.App_Start;
using VentaDeMiel2022.Web.Models.Localidad;
using VentaDeMiel2022.Web.Models.Provincia;

namespace VentaDeMiel2022.Web.Controllers
{
    public class LocalidadController : Controller
    {
        private readonly IServicioLocalidad servicio;
        private readonly IServicioProvincia servicioProvincia;

        private readonly IMapper mapper;

        public LocalidadController(ServicioProvincia servicioProvincia, ServicioLocalidad servicio)
        {

            this.servicioProvincia = servicioProvincia;
            this.servicio = servicio;
            mapper = AutoMapperConfig.Mapper;
        }

        // GET: Localidad
        public ActionResult Index()
        {
            var lista = servicio.GetLista2();
            var listaVm = mapper.Map<List<LocalidadListVm>>(lista);
            return View(listaVm);
        }
        public ActionResult Create()
        {
            LocalidadEditVm localidadVm = new LocalidadEditVm()
            {

                ProvinciasDto = servicioProvincia.GetLista()

            };
            return View(localidadVm);
        }
        public JsonResult ListarLocalidad()
        {
            var lista = servicio.GetLista2();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(LocalidadEditVm localidadVm)
        {
            if (!ModelState.IsValid)
            {
                localidadVm.ProvinciasDto = servicioProvincia.GetLista();

                return View(localidadVm);
            }

            try
            {

                var localidad = mapper.Map<Localidad>(localidadVm);

                if (!servicio.Existe(localidad))
                {
                    servicio.Guardar(localidad);

                    return RedirectToAction("Index");
                }


                ModelState.AddModelError(string.Empty, "Localidad existente");
                localidadVm.ProvinciasDto = servicioProvincia.GetLista();
                return View(localidadVm);




            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                localidadVm.ProvinciasDto = servicioProvincia.GetLista();
                return View(localidadVm);
            }
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidad localidad = servicio.GetLocalidadPorId(id.Value);
            if (localidad == null)
            {
                return HttpNotFound("Código de producto no encontrado");
            }
            LocalidadEditVm localidadVm = mapper.Map<LocalidadEditVm>(localidad);
            localidadVm.ProvinciasDto = servicioProvincia.GetLista();

            //localidadVm.Provincias = mapper.Map<List<Provincia>>(servicioProvincia.GetLista());
            return View(localidadVm);
        }

        [HttpPost]
        public ActionResult Edit(LocalidadEditVm localidadVm)
        {
            if (!ModelState.IsValid)
            {
                localidadVm.ProvinciasDto = servicioProvincia.GetLista();

                return View(localidadVm);
            }
            Localidad localidad = mapper.Map<Localidad>(localidadVm);
            try
            {
                if (!servicio.Existe(localidad))
                {
                    servicio.Guardar(localidad);

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Localidad existente!!!");
                    localidadVm.ProvinciasDto = servicioProvincia.GetLista();
                    return View(localidadVm);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(localidadVm);
            }

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            Localidad localidad = servicio.GetLocalidadPorId(id.Value);
            if (localidad == null)
            {
                return HttpNotFound("Provincia inexistente");
            }

            LocalidadEditVm localidadVm = mapper.Map<LocalidadEditVm>(localidad);
            return View(localidadVm);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            Localidad localidad = servicio.GetLocalidadPorId(id);
            try
            {
                if (servicio.EstaRelacionado(localidad))
                {
                    LocalidadEditVm localidadVm = mapper.Map<LocalidadEditVm>(localidad);
                    ModelState.AddModelError(string.Empty, "Localidad relacionada");
                    return View(localidadVm);
                }

                servicio.BorrarLocalidad(localidad);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                LocalidadEditVm localidadVm = mapper.Map<LocalidadEditVm>(localidad);
                ModelState.AddModelError(string.Empty, e.Message);
                return View(localidadVm);
            }
        }
    }
}