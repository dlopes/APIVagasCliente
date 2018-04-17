using APIVendasCliente.Models.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIVendasCliente.Models.Validation
{
    public class RequisitoValidator : AbstractValidator<Requisito>
    {
        public RequisitoValidator()
        {
            RuleFor(r => r.Descricao)
                .NotEmpty().WithMessage("A descricao do requisito deve ser informada.")
                .Length(10, 100).WithMessage("A descricao do requisito deve ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}