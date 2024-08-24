using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SDTrab.Context;
using SDTrab.Models;

namespace SDTrab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController(SDTrabContext context) : ControllerBase
    {
        private readonly SDTrabContext _context = context;

        [HttpGet]
        public IActionResult GerarConta(Conta conta, ICollection<Lancamento> lancamentos)
        {
            conta.DefinirCategoria();
            conta.Lancamentos = lancamentos;
            conta.RecalcularMulta();

            return Ok(conta);
        }
    }
}