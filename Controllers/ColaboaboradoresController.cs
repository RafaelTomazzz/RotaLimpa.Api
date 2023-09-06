using System;
using RotaLimpa.Api.Data;
using RotaLimpa.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace RotaLimpa.Api.Controllers 
{
    [ApiController]
    [Route("[Controller]")]
    public class ColaboaboradoresController : ControllerBase
    {
        private readonly DataContext _context;

        public ColaboaboradoresController(DataContext context)
        {
            _context = context;
        }
    }
}