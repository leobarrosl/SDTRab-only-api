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
    public class InfracaoController(SDTrabContext context) : ControllerBase
    {
        private readonly SDTrabContext _context = context;

        [HttpGet]
        public IActionResult PuxarTodasAsInfracoes()
        {
            var infracoes = _context.Infracoes;

            return Ok(infracoes);
        }

        [HttpPost]
        public IActionResult AdicionarInfracao(Infracao infracao)
        {
            if (infracao.EValido())
            {
                _context.Infracoes.Add(infracao);
                _context.SaveChanges();

                return Ok(infracao);
            }
            else
            {
                return BadRequest("Problema com os valores informados.");
            }
        }

        [HttpPost("AdicionarListaInfracoes")]
        public IActionResult AdicionarListaInfracoes(List<Infracao> infracoes)
        {
            foreach (Infracao infracao in infracoes)
            {
                AdicionarInfracao(infracao);
            }

            _context.SaveChanges();

            return Ok("Tudo adicionado corretamente. Exceto os com erro.");
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarInfracao(Infracao infracao, int id)
        {
            Infracao infracaoDB = _context.Infracoes.Find(id);
            if (infracao.EValido() && infracaoDB != null)
            {
                infracaoDB.Codigo = infracao.Codigo;
                infracaoDB.ColetivaIndividual = infracao.ColetivaIndividual;
                infracaoDB.Item = infracao.Item;
                infracaoDB.NivelInfracao = infracao.NivelInfracao;
                infracaoDB.NR = infracao.NR;
                infracaoDB.SaudeSeguranca = infracao.SaudeSeguranca;

                _context.Infracoes.Update(infracaoDB);
                _context.SaveChanges();

                return Ok(infracaoDB);
            }
            else
            {
                return BadRequest("Problema com os valores informados.");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeletarInfracao(int id)
        {
            Infracao infracaoDB = _context.Infracoes.Find(id);

            if (infracaoDB != null)
            {
                _context.Infracoes.Remove(infracaoDB);
                _context.SaveChanges();

                return Ok(infracaoDB);
            }
            else
            {
                return BadRequest("Infração não encontrada.");
            }
        }
    }
}