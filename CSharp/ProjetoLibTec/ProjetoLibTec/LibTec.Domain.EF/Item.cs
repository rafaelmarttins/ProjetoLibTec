using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibTec.Domain.EF
{
    [Table("Item", Schema = "dbo")]
    public partial class Item
    {
        [Key]
        [Column(name: "Codigo")]
        public int CodigoItem { get; set; }

        [Column(name: "Descricao")]
        [Unicode(false)]
        public string Descricao { get; set; } = null!;

        [Column(name: "ISBN")]
        [Unicode(false)]
        [StringLength(255)]
        public string ISBN { get; set; } = null!;

        [Column(name: "Observacoes")]
        [Unicode(false)]
        public string Observacoes { get; set; } = null!;

        [Column(name: "CodigoTipoItem")]
        public int CodigoTipoItem { get; set; }

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
