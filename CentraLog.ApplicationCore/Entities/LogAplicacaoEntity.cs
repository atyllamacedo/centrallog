using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentraLog.ApplicationCore.Entities
{
    [Table("LogAplicacao", Schema = "dbo")]
    public class LogAplicacaoEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdCentralLog { get; set; }
        public Nullable<int> IdAplicacao { get; set; }
        public string Aplicacao { get; set; }
        public Nullable<int> SessaoUsuarioId { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string IODetails { get; set; }
        public string Type { get; set; }
        public string Metodo { get; set; }
        public DateTime DataCriacao { get; set; }
        public string ClienteIP { get; set; }
        public string ClienteUserAgent { get; set; }
        public string ClienteHostName { get; set; }
        public string LogControlVersion { get; set; }
        public int Ativo { get; set; }
        public string Descricao { get; set; }
        public LogAplicacaoEntity()
        {
            DataCriacao = DateTime.Now;
        }
    }
}
