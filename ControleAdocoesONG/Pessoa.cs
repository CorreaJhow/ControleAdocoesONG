using System;

namespace ControleAdocoesONG
{
    internal class Pessoa
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public char Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string SiglaEstado { get; set; }
        public string Numero { get; set; }
        public Pessoa()
        {

        }
        public Pessoa(string nome, string cPF, char sexo, DateTime dataNascimento, string telefone, string rua, string bairro, string cidade, string siglaEstado, string numero)
        {
            Nome = nome;
            CPF = cPF;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            SiglaEstado = siglaEstado;
            Numero = numero;
        }   
    }
}
