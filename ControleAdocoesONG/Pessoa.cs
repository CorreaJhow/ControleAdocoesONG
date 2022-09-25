using System;

namespace ControleAdocoesONG
{
    internal class Pessoa
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public string DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string SiglaEstado { get; set; }
        public string Numero { get; set; }
        public Pessoa()
        {

        }
        public Pessoa(string nome, string cPF, string sexo, string dataNascimento, string telefone, string rua, string bairro, string cidade, string siglaEstado, string numero)
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

        public Pessoa CadastroPessoa()
        {
            Console.Write("Insira seu nome: ");
            string nome = Console.ReadLine();
            Console.Write("Insira seu CPF (XXX.XXX.XXX-XX): ");
            string cpf = Console.ReadLine();
            Console.Write("Insira seu Sexo (M ou F): ");
            string sexo = Console.ReadLine().ToUpper();
            while(sexo != "M" && sexo != "F")
            {
                Console.Write("Valor incorreto informado, informe novamente: ");
                sexo = Console.ReadLine().ToUpper();
            }
            Console.Write("Insira sua data de nascimento (dd/mm/aaaa): ");
            string dataNascimento = Console.ReadLine();
            Console.Write("Insira seu telefone ((xx) xxxxx-xxxx): ");
            string telefone = Console.ReadLine();
            Console.Write("Insira sua rua: ");
            string rua = Console.ReadLine();
            Console.Write("Insira seu bairro: ");
            string bairro = Console.ReadLine();
            Console.Write("Insira sua cidade: ");
            string cidade = Console.ReadLine();
            Console.Write("Insira a sigla do estado em que reside: ");
            string siglaEstado = Console.ReadLine();
            Console.Write("Insira o numero da casa: ");
            string numero = Console.ReadLine();

            Pessoa novaPessoa = new Pessoa(nome, cpf, sexo, dataNascimento, telefone, rua, bairro, cidade, siglaEstado, numero);
            return novaPessoa;
        }
    }
}
