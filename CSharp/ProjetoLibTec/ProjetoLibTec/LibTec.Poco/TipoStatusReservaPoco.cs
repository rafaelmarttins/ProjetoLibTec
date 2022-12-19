using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTec.Poco
{
    public class TipoStatusReservaPoco
    {
        public int CodigoTipoStatusReserva { get; set; }
        public string Descricao { get; set; } = null!;
        public bool? Situacao { get; set; }
        public DateTime? DataDeInsercao { get; set; }
        public DateTime? DataDeAlteracao { get; set; }
        public DateTime? DataDeExclusao { get; set; }
    }
}
