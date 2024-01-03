using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CRUD.Services.Validator
{
    public class EstimatesValidator : AbstractValidator<Estimates>
    {
        private readonly ProductContext context;
      


    }
}
