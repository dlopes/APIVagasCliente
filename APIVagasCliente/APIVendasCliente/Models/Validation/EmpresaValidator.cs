using APIVendasCliente.Models.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIVendasCliente.Models.Validation
{
    public class EmpresaValidator : AbstractValidator<Empresa>
    {
        public EmpresaValidator()
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("O nome da empresa deve ser preenchido")
                .Length(3, 100).WithMessage("O nome da empresa deve ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}