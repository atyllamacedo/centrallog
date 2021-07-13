# Central Log 

Depois perceber algumas necessidades referente a log, desenvolvi uma API que registra qualquer tipo de log, trazendo uma visão geral de cada ferramenta e melhorando as análises.
Com esses dados salvos, será possivel criar indicadores usando alguma ferramenta com o Power BI. A ideia é que qualquer aplicação consuma esse serviço.

Para consumir o serviço é preciso preencher uma entitdade (LogAplicacaoEntity) e enviar via post.

Entity: LogAplicacaoEntity

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
     }

O projeto segue arquitetura de software e consiste em 3 camadas:

- Presentation
- Application
- Infra

Foi utilizado:

- SqlServer(banco de dados)
- FluentValidator
- Swagger Documentation
- Entity Framework
- Autenticação JWT


