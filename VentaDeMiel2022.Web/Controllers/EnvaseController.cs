using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Servicio.Servicios;
using VentaDeMiel2022.Servicio.Servicios.Facades;
using VentaDeMiel2022.Servicios.Servicios.Facades;
using VentaDeMiel2022.Web.App_Start;
using VentaDeMiel2022.Web.Helpers;
using VentaDeMiel2022.Web.Models.Envase;

namespace VentaDeMiel2022.Web.Controllers
{
    public class EnvaseController : Controller
    {
        private readonly IServicioEnvases servicio;
        private readonly IServicioTiposEnvases servicioTiposEnvase;
        private readonly IMapper mapper;
        private string file = "";
        private readonly string folder = "~/Content/Imagenes/Envases/";

        public EnvaseController(IServicioEnvases servicio, IServicioTiposEnvases servicioTiposEnvase)
        {
            this.servicio = servicio;
            this.servicioTiposEnvase = servicioTiposEnvase;
            mapper = AutoMapperConfig.Mapper;
        }

        // GET: Envase
        public ActionResult Index()
        {
            var lista = servicio.GetLista();
            var listaVm = mapper.Map<List<EnvaseListVm>>(lista);
            return View(listaVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            EnvaseEditVm envaseVm = new EnvaseEditVm()
            {
                TiposEnvase = servicioTiposEnvase.GetLista(),
            };
            return View(envaseVm);
        }

        [HttpPost]
        public ActionResult Create(EnvaseEditVm envaseVm)
        {
            if (!ModelState.IsValid)
            {
                envaseVm.TiposEnvase = servicioTiposEnvase.GetLista();
                return View(envaseVm);
            }

            try
            {
                var envase = mapper.Map<Envase>(envaseVm);

                if (!servicio.Existe(envase))
                {
                    servicio.Guardar(envase);
                    // Pregunto si el modelo viene con archivo de imagen
                    if (envaseVm.ImagenFile != null)
                    {
                        // Le pongo como nombre del archivo el id del envase
                        string nombreImagen = envase.EnvaseId.ToString();
                        // Tomo la extensión del archivo que viene en el modelo
                        string extensionImagen = Path.GetExtension(envaseVm.ImagenFile.FileName);
                        // Concateno el nombre del archivo con su extensión
                        file = $"{nombreImagen}{extensionImagen}";
                        // Uso el Helper para subir el archivo al servidor y traigo una respuesta
                        var response = HelperFile.UploadPhoto(envaseVm.ImagenFile, folder, file);
                        // Si no se pudo subir, asigno "SinImagenDisponible.jpg" al archivo
                        if (!response)
                        {
                            file = "imagenNoDisponible.jpg";
                        }
                    }
                    else
                    {
                        // Si viene sin imagen, asigno "SinImagenDisponible.jpg" al archivo
                        file = "imagenNoDisponible.jpg";
                    }
                    // Asigno el contenido al atributo imagen de la clase envase
                    envase.Imagen = $"{folder}{file}";
                    // Actualizo el envase con los datos de la imagen
                    servicio.Guardar(envase);

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Envase existente!!!");
                    envaseVm.TiposEnvase = servicioTiposEnvase.GetLista();
                    return View(envaseVm);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                envaseVm.TiposEnvase = servicioTiposEnvase.GetLista();
                return View(envaseVm);
            }
        }

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    Envase envase = servicio.GetEnvasePorId(id);

        //    if (envase == null)
        //    {
        //        return HttpNotFound("Código de envase inexistente!!!");
        //    }

        //    EnvaseEditVm envaseVm = mapper.Map<EnvaseEditVm>(envase);
        //    envaseVm.TiposEnvase = servicioTiposEnvase.GetLista();
        //    return View(envaseVm);
        //}

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Envase envase = servicio.GetEnvasePorId(id);

            if (envase == null)
            {
                return HttpNotFound("Código de envase inexistente!!!");
            }

            EnvaseEditVm envaseVm = mapper.Map<EnvaseEditVm>(envase);

            // Verificar si el envase no tiene imagen asignada
            if (string.IsNullOrEmpty(envaseVm.Imagen))
            {
                // Asignar la ruta de la imagen predeterminada
                envaseVm.Imagen = "~/Content/Imagenes/Envases/SinImagenDisponible.jpg";
            }

            // Asignar la ruta de la imagen actual
            envaseVm.ImagenActual = envase.Imagen;

            envaseVm.TiposEnvase = servicioTiposEnvase.GetLista();
            return View(envaseVm);
        }

        [HttpPost]
        public ActionResult Edit(EnvaseEditVm envaseVm)
        {
            if (!ModelState.IsValid)
            {
                envaseVm.TiposEnvase = servicioTiposEnvase.GetLista();
                return View(envaseVm);
            }

            try
            {
                var envase = mapper.Map<Envase>(envaseVm);

                if (servicio.Existe(envase))
                {
                    ModelState.AddModelError(string.Empty, "Envase existente!!!");
                    envaseVm.TiposEnvase = servicioTiposEnvase.GetLista();
                    return View(envaseVm);
                }

                // Verificar si se proporciona un nuevo archivo de imagen
                if (envaseVm.ImagenFile != null)
                {
                    // Le pongo como nombre del archivo el id del envase
                    string nombreImagen = envase.EnvaseId.ToString();
                    // Tomo la extensión del archivo que viene en el modelo
                    string extensionImagen = Path.GetExtension(envaseVm.ImagenFile.FileName);
                    // Concateno el nombre del archivo con su extensión
                    string file = $"{nombreImagen}{extensionImagen}";
                    // Uso el Helper para subir el archivo al servidor y traigo una respuesta
                    var response = HelperFile.UploadPhoto(envaseVm.ImagenFile, folder, file);
                    // Si no se pudo subir, asigno "SinImagenDisponible.jpg" al archivo
                    if (!response)
                    {
                        file = "SinImagenDisponible.jpg";
                    }

                    // Actualizar la propiedad Imagen con los datos de la nueva imagen
                    envase.Imagen = $"{folder}{file}";
                }
                else
                {
                    // Si no se proporciona un nuevo archivo, mantener la imagen actual
                    envase.Imagen = envaseVm.ImagenActual;
                }

                // Resto del código para guardar el envase...
                servicio.Guardar(envase);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                envaseVm.TiposEnvase = servicioTiposEnvase.GetLista();
                return View(envaseVm);
            }
        }



        // Resto del código sigue igual...

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Envase envase = servicio.GetEnvasePorId(id.Value);
            if (envase == null)
            {
                return HttpNotFound("Código de envase inexistente!!!");
            }

            EnvaseListVm envaseVm = mapper.Map<EnvaseListVm>(envase);
            return View(envaseVm);
        }
    }
}
