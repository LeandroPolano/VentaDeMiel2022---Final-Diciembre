using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel2022.Entidades.Dtos
{
    public class VentaListDto
    {
        public int VentaId { get; set; }

        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
    }
}
