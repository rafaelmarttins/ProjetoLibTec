using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTec.Domain.EF
{
    [Table("Emprestimo", Schema = "dbo")]
    public partial class Emprestimo
    {
        [Key]
        [Column(name: "Codigo")]
        public int CodigoEmprestimo { get; set; }

        [Column(name: "CodigoUsuario")]
        public int CodigoUsuario { get; set; }

        [Column(name: "CodigoItem")]
        public int CodigoItem { get; set; }

        [Column(name: "QtdRenovado")]
        public int? QuantidadeRenovado { get; set; }

        [Column(name: "DataSaida", TypeName = "datetime")]
        public DateTime DataSaida { get; set; }

        [Column(name: "DataExpiracao", TypeName = "datetime")]
        public DateTime DataExpiracao { get; set; }

        [Column(name: "DataRetorno", TypeName = "datetime")]
        public DateTime? DataRetorno { get; set; }

        [Column(name: "CodigoStatus")]
        public int CodigoStatus { get; set; }

        [Column(name: "Ativo")]
        public bool? Situacao { get; set; }

        [Column(name: "DataInclusao", TypeName = "datetime")]
        public DateTime? DataDeInsercao { get; set; }

        [Column(name: "DataAlteracao", TypeName = "datetime")]
        public DateTime? DataDeAlteracao { get; set; }

        [Column(name: "DataExclusao", TypeName = "datetime")]
        public DateTime? DataDeExclusao { get; set; }
    }
}
