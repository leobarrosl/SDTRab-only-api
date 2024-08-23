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
    public class PenalidadeController(SDTrabContext context) : ControllerBase
    {
        private readonly SDTrabContext _context = context;

        [HttpGet]
        public IActionResult PuxarTodasAsPenalidades()
        {
            var penalidades = _context.Penalidades;

            return Ok(penalidades);
        }

        [HttpPost]
        public IActionResult AdicionarPenalidade(Penalidade penalidade)
        {
            if (penalidade.EValido())
            {
            _context.Penalidades.Add(penalidade);
            _context.SaveChanges();

            return Ok(penalidade);
            } else {
                return BadRequest("Problema com os valores informados.");
            }
        }

        [HttpPost("AdicionarListaPenalidades")]
        public IActionResult AdicionarListaPenalidades(List<Penalidade> penalidades)
        {
            foreach(Penalidade penalidade in penalidades)
            {
                AdicionarPenalidade(penalidade);
            }

            _context.SaveChanges();

            return Ok("Tudo adicionado corretamente. Exceto os com erro.");
        }

        [HttpPut("{idPenalidade}")]
        public IActionResult AtualizarPenalidade(Penalidade penalidade, int idPenalidade)
        {
            Penalidade penalidadeDB = _context.Penalidades.Find(idPenalidade);
            if (penalidade.EValido() && penalidadeDB != null)
            {
                penalidadeDB.CategoriaEmpresa = penalidade.CategoriaEmpresa;
                penalidadeDB.LevelInfringido = penalidade.LevelInfringido;
                penalidadeDB.ValorMaximo = penalidade.ValorMaximo;
                penalidadeDB.ValorMinimo = penalidade.ValorMinimo;

                _context.Penalidades.Update(penalidadeDB);
                _context.SaveChanges();

                return Ok(penalidadeDB);
            } else {
                return BadRequest("Problema com os valores informados.");
            }
        }

        [HttpDelete("{idPenalidade}")]
        public IActionResult DeletarPenalidade(int idPenalidade)
        {
            Penalidade penalidadeDB = _context.Penalidades.Find(idPenalidade);
            if (penalidadeDB != null)
            {
                _context.Penalidades.Remove(penalidadeDB);
                _context.SaveChanges();

                return Ok("Excluída com sucesso.");
            } else {
                return BadRequest("Penalidade não encontrada.");
            }
        }
    }
}