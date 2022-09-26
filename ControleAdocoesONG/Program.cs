using System;
using System.Threading;

namespace ControleAdocoesONG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {
            do
            {
                ConBancoDados conexaoBD = new ConBancoDados();
                Console.Clear();
                CabecalhoONG();
                Console.WriteLine("Bem vindo ao sistema de Adoções da nossa ONG");
                Console.WriteLine("O que deseja realizar: \n[0]Sair\n[1]Registrar \n[2]Atualizar \n[3]Consultar"); 
                int opcao = int.Parse(Console.ReadLine());
                while (opcao < 0 || opcao > 3)
                {
                    Console.WriteLine("Opção inválida informada, por favor digite novemente!");
                    opcao = int.Parse(Console.ReadLine());
                }
                switch (opcao)
                {
                    case 0:
                        Console.Clear();
                        CabecalhoONG();
                        Console.WriteLine("Obrigado pela visita!");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                    case 1:
                        bool volta = false;
                        do
                        {
                            Console.Clear();
                            CabecalhoONG();
                            Console.WriteLine("O que voce deseja Registrar: \n[0]Voltar \n[1]Pessoa (cliente) \n[2]Animal \n[3]Adoção ");
                            int op1 = int.Parse(Console.ReadLine());
                            while (op1 < 0 || op1 > 3)
                            {
                                Console.WriteLine("Valor inválido informado, tente novamente: ");
                                op1 = int.Parse(Console.ReadLine());
                            }
                            switch (op1)
                            {
                                case 0:
                                    volta = true;
                                    break;
                                case 1:
                                    #region inserir pessoa             
                                    Console.Clear();
                                    CabecalhoONG();
                                    Pessoa pessoa = new Pessoa();
                                    pessoa = pessoa.CadastroPessoa();
                                    conexaoBD.InserirPessoa(pessoa);
                                    #endregion  
                                    break;
                                case 2:
                                    #region Inserir Animal
                                    Console.Clear();
                                    CabecalhoONG();
                                    Animal animal = new Animal();
                                    animal = animal.CadastroAnimal();
                                    conexaoBD.InserirAnimal(animal);
                                    #endregion                                  
                                    break;
                                case 3:
                                    #region Inserir Registro Adoçao
                                    Console.Clear();
                                    CabecalhoONG();
                                    conexaoBD.InserirAdocao();
                                    #endregion
                                    break;
                                default:
                                    Console.WriteLine("Opção inválida informada");
                                    break;
                            }
                        } while (!volta);
                        break;
                    case 2:
                        bool volta2 = false;
                        do
                        {
                            Console.Clear();
                            CabecalhoONG();
                            Console.WriteLine("O que voce deseja Atualizar: \n[0]Voltar\n[1]Pessoa (cliente) \n[2]Animal \n[3]Adocoes ");
                            int op2 = int.Parse(Console.ReadLine());
                            while (op2 < 0 || op2 > 3)
                            {
                                Console.WriteLine("Valor inválido informado, tente novamente: ");
                                op2 = int.Parse(Console.ReadLine());
                            }
                            switch (op2)
                            {
                                case 0:
                                    volta2 = true;
                                    break;
                                case 1:
                                    #region Atualiza Cliente
                                    Console.Clear();
                                    CabecalhoONG();
                                    Console.WriteLine("Informe o CPF que do cliente que deseja alterar: ");
                                    string Cpf = Console.ReadLine(); //verificar se o cpf existe no banco de dados.
                                    Console.WriteLine("O que você deseja alterar do Cliente: \n[1]Nome \n[2]Sexo \n[3]Telefone \n[4]SiglaEstado");
                                    int opc = int.Parse(Console.ReadLine());
                                    while (opc < 1 || opc > 4)
                                    {
                                        Console.WriteLine("Opção inválida, informe novamente: ");
                                        opc = int.Parse(Console.ReadLine());
                                    }
                                    switch (opc)
                                    {
                                        case 1:
                                            #region Atualiza Nome
                                            Console.WriteLine("Informe o novo nome: ");
                                            string nome = Console.ReadLine();
                                            string sql = "update Pessoa set Nome = '" + nome + "' where CPF = '" + Cpf + "';";
                                            conexaoBD.AtualizarTabela(sql);
                                            PressioneParaProsseguir();
                                            #endregion
                                            break;
                                        case 2:
                                            #region Atualiza Sexo
                                            Console.Write("Insira seu Sexo (M ou F): ");
                                            string sexo = Console.ReadLine().ToUpper();
                                            while (sexo != "M" && sexo != "F")
                                            {
                                                Console.Write("Valor incorreto informado, informe novamente: ");
                                                sexo = Console.ReadLine().ToUpper();
                                            }
                                            sql = "update Pessoa set Sexo = '" + sexo + "' where CPF = '" + Cpf + "';";
                                            conexaoBD.AtualizarTabela(sql);
                                            PressioneParaProsseguir();
                                            #endregion 
                                            break;
                                        case 3:
                                            #region Atualiza Telefone
                                            Console.WriteLine("Informe o novo numero de Telefone: ");
                                            string telefone = Console.ReadLine();
                                            sql = "update Pessoa set Telefone = '" + telefone + "' where CPF = '" + Cpf + "';";
                                            conexaoBD.AtualizarTabela(sql);
                                            PressioneParaProsseguir();
                                            #endregion
                                            break;
                                        case 4:
                                            #region atualiza estado
                                            Console.WriteLine("Informe o nova sigla do estado: ");
                                            string siglaEstado = Console.ReadLine();
                                            sql = "update Pessoa set siglaEstado = '" + siglaEstado + "' where CPF = '" + Cpf + "';";
                                            conexaoBD.AtualizarTabela(sql);
                                            PressioneParaProsseguir();
                                            #endregion
                                            break;
                                        default:
                                            Console.WriteLine("Erro de swicht!!");
                                            break;
                                    }
                                    #endregion
                                    break;
                                case 2:
                                    #region Atualiza Animal 
                                    Console.Clear();
                                    CabecalhoONG();
                                    Console.WriteLine("Informe o CHIP que do animal que deseja alterar o registro: ");
                                    string Chip = Console.ReadLine(); //verificar se o chip existe no banco de dados.
                                    Console.WriteLine("O que você deseja alterar do Animal: \n[1]Familia \n[2]Raca \n[3]Sexo \n[4]Nome");
                                    int opcAnimal = int.Parse(Console.ReadLine());
                                    while (opcAnimal < 1 || opcAnimal > 4)
                                    {
                                        Console.WriteLine("Opção inválida, informe novamente: ");
                                        opcAnimal = int.Parse(Console.ReadLine());
                                    }
                                    switch (opcAnimal)
                                    {
                                        case 1:
                                            #region Atualiza Familia Animal
                                            Console.WriteLine("Informe a nova familia do animal: ");
                                            string familia = Console.ReadLine();
                                            string sql = "update Animal set Familia = '" + familia + "' where CHIP = '" + Chip + "';";
                                            conexaoBD.AtualizarTabela(sql);
                                            PressioneParaProsseguir();
                                            #endregion
                                            break;
                                        case 2:
                                            #region Atualiza Raca Animal 
                                            Console.WriteLine("Informe a nova raça do animal: ");
                                            string raca = Console.ReadLine();
                                            sql = "update Animal set Raca = '" + raca + "' where CHIP = '" + Chip + "';";
                                            conexaoBD.AtualizarTabela(sql);
                                            PressioneParaProsseguir();
                                            #endregion  
                                            break;
                                        case 3:
                                            #region Atualiza Sexo Animal 
                                            Console.Write("Insira o novo Sexo (M ou F): ");
                                            string sexo = Console.ReadLine().ToUpper();
                                            while (sexo != "M" && sexo != "F")
                                            {
                                                Console.Write("Valor incorreto informado, informe novamente: ");
                                                sexo = Console.ReadLine().ToUpper();
                                            }
                                            sql = "update Animal set Sexo = '" + sexo + "' where CHIP = '" + sexo + "';";
                                            conexaoBD.AtualizarTabela(sql);
                                            PressioneParaProsseguir();
                                            #endregion
                                            break;
                                        case 4:
                                            #region Atualiza Nome Animal
                                            Console.WriteLine("Informe o novo nome do animal: ");
                                            string nome = Console.ReadLine();
                                            sql = "update Animal set Nome = '" + nome + "' where CHIP = '" + Chip + "';";
                                            conexaoBD.AtualizarTabela(sql);
                                            PressioneParaProsseguir();
                                            #endregion
                                            break;
                                        default:
                                            Console.WriteLine("Erro de swicht!!");
                                            break;
                                    }
                                    #endregion 
                                    break;
                                case 3:
                                    #region Atualiza Registro Adocao
                                    Console.Clear();
                                    CabecalhoONG();
                                    Console.WriteLine("Informe o numero de Registro que deseja alterar: ");
                                    int numRegistro = int.Parse(Console.ReadLine());
                                    Console.WriteLine("O que deseja alterar do registro de adocoes: \n[1]Adotante (Pessoa) \n[2]Adotado (Animal)");
                                    int op = int.Parse(Console.ReadLine());
                                    while (op < 1 || op > 2)
                                    {
                                        Console.WriteLine("Opção inválida, informe novamente: ");
                                        op = int.Parse(Console.ReadLine());
                                    }
                                    switch (op)
                                    {
                                        case 1:
                                            Console.WriteLine("Insira o CPF do novo Adotante: ");
                                            string novocpf = Console.ReadLine();
                                            string sql = "update RegistroAdocao set Adotante = '" + novocpf + "' where NumeroRegistro = " + numRegistro;
                                            conexaoBD.AtualizarTabela(sql);
                                            PressioneParaProsseguir();
                                            break;
                                        case 2:
                                            Console.WriteLine("Insira o CHIP do novo Adotado: ");
                                            int novochip = int.Parse(Console.ReadLine());
                                            sql = "update RegistroAdocao set Adotado = " + novochip + " where NumeroRegistro = " + numRegistro;
                                            conexaoBD.AtualizarTabela(sql);
                                            PressioneParaProsseguir();
                                            break;
                                        default:
                                            break;
                                    }
                                    #endregion
                                    break;
                                default:
                                    Console.WriteLine("Opção inválida informada");
                                    break;
                            }
                        } while (!volta2);
                        break;
                    case 3:
                        bool volta3 = false;
                        do
                        {
                            Console.Clear();
                            CabecalhoONG();
                            Console.WriteLine("O que voce deseja Consultar: \n[0]Voltar\n[1]Pessoa (cliente) \n[2]Animal \n[3]Adocoes ");
                            int op3 = int.Parse(Console.ReadLine());
                            while (op3 < 0 || op3 > 3)
                            {
                                Console.WriteLine("Valor inválido informado, tente novamente: ");
                                op3 = int.Parse(Console.ReadLine());
                            }
                            switch (op3)
                            {
                                case 0:
                                    volta3 = true;
                                    break;
                                case 1:
                                    #region Select Tabela Pessoas
                                    Console.Clear();
                                    CabecalhoONG();
                                    Console.WriteLine("Buscando registros...");
                                    Thread.Sleep(1000);
                                    string sql = "select Nome, Cpf, Sexo, Telefone, SiglaEstado, dataNascimento from pessoa;";
                                    conexaoBD.SelectPessoa(sql);
                                    #endregion
                                    break;
                                case 2:
                                    #region Select Tabela Animal
                                    Console.Clear();
                                    CabecalhoONG();
                                    Console.WriteLine("Buscando registros...");
                                    Thread.Sleep(1000);
                                    sql = "select CHIP, Familia, Raca, Sexo, Nome from Animal;";
                                    conexaoBD.SelectAnimal(sql);
                                    #endregion
                                    break;
                                case 3:
                                    #region Select Tabela RegistroAdocao
                                    Console.Clear();
                                    CabecalhoONG();
                                    Console.WriteLine("Buscando registros...");
                                    Thread.Sleep(1000);
                                    sql = "select NumeroRegistro, Adotante, Adotado from RegistroAdocao;";
                                    conexaoBD.SelectAdocoes(sql);
                                    #endregion
                                    break;
                                default:
                                    Console.WriteLine("Opção inválida informada");
                                    break;
                            }
                        } while (!volta3);
                        break;
                    default:
                        Console.WriteLine("Opção inválida informada");
                        break;
                }
            } while (true);
        }
        public static void PressioneParaProsseguir()
        {
            Console.WriteLine("Pressione enter para continuar...");
            Console.ReadKey();
        }
        private static void CabecalhoONG()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                                  ONG - Paraíso dos Animais");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        }
    }
}
