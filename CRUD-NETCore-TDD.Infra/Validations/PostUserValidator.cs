﻿using System;
using System.Collections.Generic;
using System.Text;
using CRUD_NETCore_TDD.Infra.Models;
using FluentValidation;

namespace CRUD_NETCore_TDD.Infra.Validations
{
    public class PostUserValidator : AbstractValidator<User>
    {
        public PostUserValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithErrorCode("100")
                .MaximumLength(80)
                .WithErrorCode("101");

            RuleFor(x => x.Age)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .GreaterThan(33)
            .WithErrorCode("102");
        }
    }
}
