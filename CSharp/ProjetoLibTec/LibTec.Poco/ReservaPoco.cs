using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTec.Poco
{
    public class ReservaPoco
    {
        public int CodigoReserva { get; set; }
        public int CodigoUsuario { get; set; }
        public int CodigoItem { get; set; }
        public int CodigoStatus { get; set; }
        public bool? Situacao { get; set; }
        public DateTime? DataDeInsercao { get; set; }
        public DateTime? DataDeAlteracao { get; set; }
        public DateTime? DataDeExclusao { get; set; }
    }
}
