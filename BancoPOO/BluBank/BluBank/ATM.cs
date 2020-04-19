using System;

namespace BluBank
{
    class ATM
    {
        static void Main(string[] args)
        {
            int conta;
            int senha;
            int valor;
            int menu;

            Cliente cliente = new Cliente();
            ContaCorrente cc = new ContaCorrente();
            ContaPoupanca cp = new ContaPoupanca();
            Relatorio rel = new Relatorio();

            Login(); // Solicita login

            void Login()
            {
                Console.WriteLine("Seja bem vindo ao BluBank!" +
                    "\nInforme o número da sua conta:");
                conta = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe a senha da sua conta:");
                senha = int.Parse(Console.ReadLine());

                if (cliente.Numero == conta && cliente.Senha == senha)
                {
                    Menu(); // Abre menu
                }
                else
                {
                    Console.WriteLine("\nConta ou Senha incorretas\n");
                    Login();
                }
            }

            void Menu()
            {
                Console.WriteLine("\nBem vindo " + cliente.Nome +
                "\nEscolha uma das operações" +
                "\n\n1 - Saldo: " +
                "\n2 - Depositar Conta Corrente: " +
                "\n3 - Depositar Conta Poupança: " +
                "\n4 - Sacar Conta Corrente: " +
                "\n5 - Sacar Conta Poupança: " +
                "\n6 - Encerrar Sessão \n");

                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        rel.ZeraSomar();
                        rel.Somar(cc);
                        rel.Somar(cp);
                        Console.WriteLine("\nSaldo Conta Corrente: " + cc.Saldo +
                            "\nSaldo Conta Poupança: " + cp.Saldo +
                            "\nSaldo Total: " + rel.SaldoGeral);
                        break;
                    case 2:
                        Console.WriteLine("\nValor de depósito em Conta Corrente: ");
                        valor = int.Parse(Console.ReadLine());
                        cc.Depositar(valor);
                        break;
                    case 3:
                        Console.WriteLine("\nValor de depósito em Conta Poupança: ");
                        valor = int.Parse(Console.ReadLine());
                        cp.Depositar(valor);
                        break;
                    case 4:
                        Console.WriteLine("\nSaldo atual: " + cc.Saldo +
                            "\nValor de saque em Conta Poupança: ");
                        valor = int.Parse(Console.ReadLine());
                        cc.Sacar(valor);
                        break;
                    case 5:
                        Console.WriteLine("\nSaldo atual: " + cp.Saldo +
                            "\nValor de saque em Conta Poupança: ");
                        valor = int.Parse(Console.ReadLine());
                        cp.Sacar(valor);
                        break;
                    default:
                        Console.WriteLine("Obrigado, volte sempre!");
                        Environment.Exit(0);
                        break;
                }

                Menu(); // Retorna ao menu
            }
        }
    }
}
