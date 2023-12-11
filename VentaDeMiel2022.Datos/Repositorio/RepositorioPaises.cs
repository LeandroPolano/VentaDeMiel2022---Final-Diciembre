using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VentaDeMiel2022.Datos.Repositorio.Facade;
using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Datos.Repositorio
{
    public class RepositorioPaises : IRepositorioPais
    {
        private readonly VentaDeMiel2022DbContext context;


        public RepositorioPaises(VentaDeMiel2022DbContext ventaDeMiel2022DbContext)
        {
            this.context = ventaDeMiel2022DbContext;
        }
        public void Guardar(Pais pais)
        {
            
            try
            {
                if (pais.PaisId == 0)
                {
                    context.Paises.Add(pais);
                }
                else
                {
                    var PaisInDb = context.Paises
                        .SingleOrDefault(c => c.PaisId == pais.PaisId);

                    PaisInDb.PaisId = pais.PaisId;
                    PaisInDb.NombrePais = pais.NombrePais;
                    context.Entry(PaisInDb).State = EntityState.Modified;

                }
                context.SaveChanges();
            }
            catch (Exception e)
            {       
                throw e;
            }
        }

        public List<Pais> GetLista()
        {
            try
            {
                return context.Paises
                    .AsNoTracking()
                    .ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                
            }
        }

        public void Borrar(int paisId)
        {
            try
            {
                var pInDb = context.Paises.SingleOrDefault(p => p.PaisId == paisId);
                if (pInDb == null)
                {
                    throw new Exception("Pais no encontrado");
                }

                context.Entry(pInDb).State = EntityState.Deleted;
               
            }
            catch (Exception e)
            {
                //if (e.InnerException!=null && e.InnerException.InnerException.Message.Contains("REFERENCE"))
                //{
                //    throw new Exception("El registro esta relacionado...");
                //}
                throw new Exception(e.Message);
            }
        }
       

        public Pais GetPaisPorId(int id)
        {
            try
            {
                return context.Paises.SingleOrDefault(c => c.PaisId == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Existe(Pais pais)
        {
            try
            {
                if (pais.PaisId == 0)
                {
                    return context.Paises.Any(m => m.NombrePais == pais.NombrePais);
                }

                return context.Paises.Any(m => m.NombrePais == pais.NombrePais
                                                   && m.PaisId != pais.PaisId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool EstaRelacionado(Pais pais)
        {
            try
            {
                return context.Provincias
                    .Any(p => p.PaisId == pais.PaisId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void BorrarPais(Pais pais)
        {
            try
            {
                context.Entry(pais).State = EntityState.Deleted;
                context.SaveChanges();
              
            }
            catch (Exception e)
            {
                throw e;
            }
        }

      
    }
}
