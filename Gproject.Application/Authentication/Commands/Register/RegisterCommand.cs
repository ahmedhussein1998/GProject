﻿using ErrorOr;
using Gproject.Application.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gproject.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
         string? FirstName,
         string? SecondName,
         string? ThirdName,
         string? LastName,
         string Email,
         string? Number,
         string? CountryPrefix,
         string? GenderCode,
         string? GenderDescriptionAr,
         string? GenderDescriptionEn,
         string? NationalityCode,
         string? NationalityDescriptionAr,
         string? NationalityDescriptionEn,
         string? PictureFileName,
         string Password) :IRequest<ErrorOr<AuthenticationResult>>;


    

   
}
