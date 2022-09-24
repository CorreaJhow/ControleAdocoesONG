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
                CabecalhoONG();
                Console.WriteLine("Bem vindo ao sistema de Adoções da nossa ONG");
                Console.WriteLine("O que deseja realizar: \n[0]Sair\n[1]Registrar \n[2]Atualizar \n[3]Consultar"); //pensar sobre o delete
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
                            Console.WriteLine("O que voce deseja Registrar: \n[0]Voltar \n[1]Pessoa (cliente) \n[2]Animal ");
                            int op1 = int.Parse(Console.ReadLine());
                            while (op1 != 1 || op1 != 2)
                            {
                                Console.WriteLine("Valor inválido informado, tente novamente: ");
                                op1 = int.Parse(Console.ReadLine());
                            }
                            switch (op1)
                            {
                                case 0:
                                    volta = true;
                                    //voltar
                                    break;
                                case 1:
                                    //inserir pessoas
                                    break;
                                case 2:
                                    //insert into animal
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
                            Console.WriteLine("O que voce deseja Atualizar: \n[0]Voltar\n[1]Pessoa (cliente) \n[2]Animal ");
                            int op2 = int.Parse(Console.ReadLine());
                            while (op2 < 0 || op2 > 2)
                            {
                                Console.WriteLine("Valor inválido informado, tente novamente: ");
                                op2 = int.Parse(Console.ReadLine());
                            }
                            switch (op2)
                            {
                                case 0:
                                    volta2 = true;
                                    //voltar
                                    break;
                                case 1:
                                    //update Pessoa
                                    break;
                                case 2:
                                    //update into animal
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
                            Console.WriteLine("O que voce deseja Consultar: \n[0]Voltar\n[1]Pessoa (cliente) \n[2]Animal ");
                            int op3 = int.Parse(Console.ReadLine());
                            while (op3 < 0 || op3 > 2)
                            {
                                Console.WriteLine("Valor inválido informado, tente novamente: ");
                                op3 = int.Parse(Console.ReadLine());
                            }
                            switch (op3)
                            {
                                case 0:
                                    volta3 = true;
                                    //voltar
                                    break;
                                case 1:
                                    //select Pessoa
                                    break;
                                case 2:
                                    //select into animal
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

        private static void CabecalhoONG()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                                  ONG - Paraíso dos Animais");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        }
    }
}
