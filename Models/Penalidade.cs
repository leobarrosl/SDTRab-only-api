using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDTrab.Models
{
    public class Penalidade
    {
        public int Id { get; set; }
        public int CategoriaEmpresa { get; set; }
        public int LevelInfringido { get; set; }
        public decimal ValorMinimo { get; set; }
        public decimal ValorMaximo { get; set; }

        public bool VerificarValores()
        {
            return ValorMaximo >= ValorMinimo;
        }
        public bool VerificarCategoria()
        {
            return CategoriaEmpresa > 0 && CategoriaEmpresa < 9;
        }
        public bool VerificarLevel()
        {
            return LevelInfringido > 0 && LevelInfringido < 5;
        }
        public bool EValido()
        {
            return VerificarCategoria() && VerificarLevel() && VerificarValores();
        }
    }
}
