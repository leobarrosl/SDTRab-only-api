using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDTrab.Models
{
    public class Conta
    {
        public int QuantidadeFuncionarios { get; set; }
        public int? Categoria { get; set; }
        public List<decimal?> ValorMultaAtual { get; set; } = [0, 0];
        public ICollection<Lancamento> Lancamentos { get; set; }

        public void RecalcularMulta()
        {
            ValorMultaAtual[0] = Lancamentos.Sum(x => x.ValorMin);
            ValorMultaAtual[1] = Lancamentos.Sum(x => x.ValorMax);
        }

        public bool VerificarFuncionarios()
        {
            if (QuantidadeFuncionarios <= 0)
            {
                return false;
            }
            return true;
        }

        public void DefinirCategoria()
        {
            if (QuantidadeFuncionarios > 1000)
            {
                Categoria = 8;
            } else if (QuantidadeFuncionarios > 500)
            {
                Categoria = 7;
            } else if (QuantidadeFuncionarios > 250) 
            {
                Categoria = 6;
            } else if (QuantidadeFuncionarios > 100)
            {
                Categoria = 5;
            } else if(QuantidadeFuncionarios > 50)
            {
                Categoria= 4;
            }else if (QuantidadeFuncionarios > 25)
            {
                Categoria = 3;
            } else if (QuantidadeFuncionarios > 10)
            {
                Categoria = 2;
            } else if (QuantidadeFuncionarios > 0)
            {
                Categoria = 1;
            }
        }
    }

}