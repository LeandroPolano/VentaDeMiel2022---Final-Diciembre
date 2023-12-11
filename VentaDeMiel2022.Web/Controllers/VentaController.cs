using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentaDeMiel2022.Servicio.Servicios;
using VentaDeMiel2022.Servicio.Servicios.Facades;
using VentaDeMiel2022.Web.App_Start;
using VentaDeMiel2022.Web.ViewModels.Venta;

namespace VentaDeMiel2022.Web.Controllers
{
    public class VentaController : Controller
    {
        private readonly IServicioVentas servicioVenta;
        private readonly IMapper _mapper;

        public VentaController(ServicioVentas servicio)
        {
            servicioVenta = servicio;
            _mapper = AutoMapperConfig.Mapper;
        }
        // GET: Venta
        public ActionResult Index()
        {
            var lista = servicioVenta.GetVentas();
            //var listaVm = _mapper.Map<List<VentaListVm>>(lista);
            return View(lista);
        }
    }
}