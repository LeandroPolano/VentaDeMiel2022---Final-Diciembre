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
using VentaDeMiel2022.Web.Models.Provincia;

namespace VentaDeMiel2022.Web.Controllers
{
    public class ProvinciaController : Controller
    {
        private readonly IServicioProvincia servicio;
        private readonly IServicioPais servicioPais;


        private readonly IMapper mapper;

        public JsonResult ListarProvincias()
        {
            var lista = servicio.GetLista();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }
        public ProvinciaController(ServicioProvincia servicio, ServicioPaises servicioPais)
        {
            this.servicioPais = servicioPais;
            this.servicio = servicio;
            mapper = AutoMapperConfig.Mapper;
        }
        // GET: Provincia

        public ActionResult Index()
        {
            var lista = servicio.GetLista();
            var listaVm = mapper.Map<List<ProvinciaListVm>>(lista);
            return View(listaVm);
        }
        
        [HttpGet]
        public ActionResult Create() 
        {
            ProvinciaEditVm provinciaVm = new ProvinciaEditVm()
            {
                Paises = servicioPais.GetLista(),
               
            };
            return View(provinciaVm);
        }

        [HttpPost]
        public ActionResult Create(ProvinciaEditVm provinciaVm)
        {
            if (!ModelState.IsValid)
            {
                provinciaVm.Paises = servicioPais.GetLista();
                return View(provinciaVm);
            }

            try
            {
                var provincia = mapper.Map<Provincia>(provinciaVm);

                if (!servicio.Existe(provincia))
                {
                    servicio.Guardar(provincia);

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Provincia existente");
                    provinciaVm.Paises = servicioPais.GetLista();

                    return View(provinciaVm);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                provinciaVm.Paises = servicioPais.GetLista();

                return View(provinciaVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = servicio.GetProvinciaPorId(id.Value);
            if (provincia == null)
            {
                return HttpNotFound("Código de producto no encontrado");
            }
            ProvinciaEditVm provinciaVm = mapper.Map<ProvinciaEditVm>(provincia);
            provinciaVm.Paises = servicioPais.GetLista();
            return View(provinciaVm);
        }

        [HttpPost]
        public ActionResult Edit(ProvinciaEditVm provinciaVm)
        {
            if (!ModelState.IsValid)
            {
                provinciaVm.Paises = servicioPais.GetLista();

                return View(provinciaVm);
            }
            Provincia provincia = mapper.Map<Provincia>(provinciaVm);
            try
            {
                if (!servicio.Existe(provincia))
                {
                    servicio.Guardar(provincia);
                  
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Provincia existente!!!");
                    provinciaVm.Paises = servicioPais.GetLista();

                    return View(provinciaVm);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                provinciaVm.Paises = servicioPais.GetLista();

                return View(provinciaVm);
            }

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                }

                Provincia provincia = servicio.GetProvinciaPorId(id.Value);
                if (provincia == null)
                {
                    return HttpNotFound("Código de provincia inexistente");
                }
                ProvinciaEditVm provinciaVm = mapper.Map<ProvinciaEditVm>(provincia);
                return View(provinciaVm);

            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            Provincia provincia = servicio.GetProvinciaPorId(id);
            try
            {
                if (servicio.EstaRelacionado(provincia))
                {
                    ProvinciaEditVm marcaVm = mapper.Map<ProvinciaEditVm>(provincia);
                    ModelState.AddModelError(string.Empty, "provincia relacionada");
                    return View(marcaVm);
                }

                servicio.BorrarProvincia(provincia);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ProvinciaEditVm marcaVm = mapper.Map<ProvinciaEditVm>(provincia);
                ModelState.AddModelError(string.Empty, e.Message);
                return View(marcaVm);
            }
        }

    }
}