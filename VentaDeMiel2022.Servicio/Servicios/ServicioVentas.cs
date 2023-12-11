using System;
using System.Collections.Generic;
using VentaDeMiel2022.Datos.Repositorio.Facade;
using VentaDeMiel2022.Datos;
using VentaDeMiel2022.Entidades.Entidades;
using VentaDeMiel2022.Servicio.Servicios.Facades;
using System.Transactions;
using VentaDeMiel2022.Datos.Repositorio;
using VentaDeMiel2022.Entidades.Dtos;

namespace VentaDeMiel2022.Servicio.Servicios
{
    public class ServicioVentas : IServicioVentas
    {
        private readonly VentaDeMiel2022DbContext context;
        private readonly IRepositorioVentas repoVentas;
        private readonly IRepositorioDetalleVentas repoDetalle;
        private readonly IUnitOfWork unitOfWork;

        public ServicioVentas(VentaDeMiel2022DbContext context, RepositorioVentas Repositorioventas, IUnitOfWork unitOfWork, RepositorioDetalleVentas repositorioDetalle)
        {
            this.context = context;
            this.repoVentas = Repositorioventas;
            this.repoDetalle = repositorioDetalle;
            this.unitOfWork = unitOfWork;
        }

        public bool Existe(Venta venta)
        {
            try
            {
                return repoVentas.Existe(venta);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<DetalleVenta> GetDetalleVenta(int VentaId)
        {
            try
            {
                return repoDetalle.GetDetalleVenta(VentaId);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<VentaListDto> GetVentas()
        {
            try
            {
                return repoVentas.GetVentas();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(Venta venta)
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    Venta ventaAux = new Venta()
                    {
                        Fecha = venta.Fecha,
                        Total = venta.Total
                    };
                    repoVentas.Guardar(ventaAux);
                    unitOfWork.Save();
                    venta.VentaId = ventaAux.VentaId;
                    //context.SaveChanges();
                    foreach (var item in venta.DetalleVentas)
                    {
                        item.VentaId = venta.VentaId;
                        //repoDetalle.Guardar(item);

                    }

                    //context.SaveChanges();
                    unitOfWork.Save();
                    scope.Complete();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
