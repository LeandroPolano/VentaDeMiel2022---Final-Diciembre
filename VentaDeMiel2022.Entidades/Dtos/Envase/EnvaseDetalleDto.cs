namespace EComm2022.Entidades.Dtos.Envase
{
    public class EnvaseDetalleDto
    {
        public int EnvaseId { get; set; }
        public string Descripcion { get; set; }
        public int TipoEnvaseId { get; set; }
        public decimal Precio { get; set; }
        public decimal Stock { get; set; }
        public string base64 { get; set; }
        public string extensionArchivo { get; set; }
        public string Imagen { get; set; }
    }
}
