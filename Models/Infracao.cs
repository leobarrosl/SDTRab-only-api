using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SDTrab.Models
{

    public enum NivelInfracao
    {
        [Description("1")]
        N1 = 1,
        [Description("2")]
        N2 = 2,
        [Description("3")]
        N3 = 3,
        [Description("4")]
        N4 = 4
    }
    public enum SaudeSeguranca
    {
        [Description("Saúde")]
        Saude = 1,
        [Description("Segurança")]
        Seguranca = 2
    }
    public enum ColetivaIndividual
    {
        [Description("Saúde")]
        Coletiva = 1,
        [Description("Saúde")]
        Individual = 2
    }
    public enum NR
    {
        [Description("1")]
        NR1 = 1,
        [Description("2")]
        NR2 = 2,
        [Description("3")]
        NR3 = 3,
        [Description("4")]
        NR4 = 4,
        [Description("5")]
        NR5 = 5,
        [Description("6")]
        NR6 = 6,
        [Description("7")]
        NR7 = 7,
        [Description("8")]
        NR8 = 8,
        [Description("9")]
        NR9 = 9,
        [Description("10")]
        NR10 = 10,
        [Description("11")]
        NR11 = 11,
        [Description("12")]
        NR12 = 12,
        [Description("13")]
        NR13 = 13,
        [Description("14")]
        NR14 = 14,
        [Description("15")]
        NR15 = 15,
        [Description("16")]
        NR16 = 16,
        [Description("17")]
        NR17 = 17,
        [Description("18")]
        NR18 = 18,
        [Description("19")]
        NR19 = 19,
        [Description("20")]
        NR20 = 20,
        [Description("21")]
        NR21 = 21,
        [Description("22")]
        NR22 = 22,
        [Description("23")]
        NR23 = 23,
        [Description("24")]
        NR24 = 24,
        [Description("25")]
        NR25 = 25,
        [Description("26")]
        NR26 = 26,
        [Description("27")]
        NR27 = 27,
        [Description("28")]
        NR28 = 28,
        [Description("29")]
        NR29 = 29,
        [Description("30")]
        NR30 = 30,
        [Description("31")]
        NR31 = 31,
        [Description("32")]
        NR32 = 32,
        [Description("33")]
        NR33 = 33,
        [Description("34")]
        NR34 = 34,
        [Description("35")]
        NR35 = 35,
        [Description("36")]
        NR36 = 36,
        [Description("37")]
        NR37 = 37,
        [Description("38")]
        NR38 = 38
    }
    public class Infracao
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public string Codigo { get; set; }
        public NivelInfracao NivelInfracao { get; set; }
        public SaudeSeguranca SaudeSeguranca { get; set; }
        public ColetivaIndividual ColetivaIndividual { get; set; }
        public NR NR { get; set; }

        public bool VerificarNivel()
        {
            return (int)NivelInfracao > 0 && (int)NivelInfracao < 5;
        }
        public bool VerificarSaudeSeguranca()
        {
            return (int)SaudeSeguranca > 0 && (int)SaudeSeguranca < 3;
        }
        public bool VerificarColetivaIndividual()
        {
            return (int)ColetivaIndividual > 0 && (int)ColetivaIndividual < 3;
        }
        public bool VerificarNR()
        {
            return (int)NR > 0 && (int)NR < 38;
        }
        public bool EValido()
        {
            return VerificarNivel() && VerificarSaudeSeguranca() && VerificarColetivaIndividual() && VerificarNR();
        }
    }
}

