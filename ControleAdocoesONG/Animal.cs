using System;

namespace ControleAdocoesONG
{
    internal class Animal
    {
        public int Chip { get; set; }
        public string Familia { get; set; }
        public string Raca { get; set; }
        public string  Sexo { get; set; }
        public string Nome { get; set; }
        public Pessoa Adotante { get; set; }
        public Animal()
        {

        }
        public Animal(int chip, string familia, string raca, string sexo, string nome, Pessoa adotante)
        {
            Chip = chip;
            Familia = familia;
            Raca = raca;
            Sexo = sexo;
            Nome = nome;
            Adotante = adotante;
        }
    }
}
