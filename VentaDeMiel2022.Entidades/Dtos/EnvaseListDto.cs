using VentaDeMiel2022.Entidades.Entidades;

namespace VentaDeMiel2022.Entidades.Dtos
{
    public class EnvaseListDto
    {
        public int EnvaseId { get; set; }
        public string Descripcion { get; set; }
        public string TipoEnvase { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public string Imagen { get; set; }

        //public EnvaseListDto(Envase envase)
        //{
        //    EnvaseId = envase.EnvaseId;
        //    Descripcion = envase.Descripcion;
        //    TipoEnvaseId = envase.TipoEnvaseId;
        //    Precio = envase.Precio;
        //    Stock = envase.Stock;
        //    Imagen = envase.Imagen;
        //}
    }
}
