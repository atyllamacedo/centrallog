using CentraLog.ApplicationCore.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Central.Log.API.Help.Validation
{
    public class LogManagerValidator : AbstractValidator<LogAplicacaoEntity>
    {
        public LogManagerValidator()
        {
            RuleFor(x => x.Message)
                 .NotEmpty().WithMessage("Campo obrigatorio.");
            RuleFor(y => y.Type)
                .NotEmpty().WithMessage("Campo obrigatorio.");
            RuleFor(y => y.StackTrace)
            .NotEmpty().WithMessage("Campo obrigatorio.");

        }
    }
}
