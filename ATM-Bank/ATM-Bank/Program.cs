using System;

namespace ATM_Bank
{
    class Program
    {
        public static void Main()
        {
            int Saldo = 2034, Deposito, Saque;
            int Menu, Pin = 0; //, X = 0;

            Console.WriteLine("Informe o número da sua conta para iniciar");
            Console.WriteLine("==========================================");
            Pin = int.Parse(Console.ReadLine());
            Console.WriteLine("==========================================\n");

            while (true)
            {
                Console.WriteLine("Bem vindo ao Banco DBZ\nEscolha uma das operações:\n");
                Console.WriteLine("1. Saldo");
                Console.WriteLine("2. Saque");
                Console.WriteLine("3. Deposito");
                Console.WriteLine("4. Encerrar Sessão\n");
                Console.WriteLine("==========================================");
                Menu = int.Parse(Console.ReadLine());
                Console.WriteLine("==========================================");

                switch (Menu)
                {
                    case 1:
                        Console.WriteLine("Saldo atual: R${0}", Saldo);
                        Console.WriteLine("==========================================\n");
                        break;
                    case 2:
                        Console.WriteLine("\n ENTER THE Saque Saldo : ");
                        Saque = int.Parse(Console.ReadLine());
                        if (Saque % 100 != 0)
                        {
                            Console.WriteLine("\n PLEASE ENTER THE Saldo IN ABOVE 100");
                        }
                        else if (Saque > (Saldo - 1000))
                        {
                            Console.WriteLine("\n SORRY! INSUFFICENT BALANCE");
                        }
                        else
                        {
                            Saldo = Saldo - Saque;
                            Console.WriteLine("\n\n PLEASE COLLECT YOUR CASH");
                            Console.WriteLine("\n CURRENT BALANCE IS Rs : {0}", Saldo);
                        }
                        break;
                    case 3:
                        Console.WriteLine("\n ENTER THE Deposito Saldo");
                        Deposito = int.Parse(Console.ReadLine());
                        Saldo = Saldo + Deposito;
                        Console.WriteLine("YOUR Saldo HAS BEEN DepositoED SUCCESSFULLY..");
                        Console.WriteLine("YOUR TOTAL BALANCE IS Rs : {0}", Saldo);
                        break;
                    case 4:
                        Console.WriteLine("\n THANK YOU…");
                        break;
                }
            }
            Console.WriteLine("\n\n Sessão encerrada");
        }
    }
}