using System;
using System.Collections.Generic;

namespace dioBank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            string opcaoSelecionada = menu.showMenu();

            while(opcaoSelecionada != "X") {
                switch(opcaoSelecionada) {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        break;
                    default:
                        Console.WriteLine("Por favor, selecione uma opção válida.");
                        break;
                }
                opcaoSelecionada = menu.showMenu();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }




        #region Métodos privados
        private static void Transferir()
        {
            if(listaContas.Count > 0) {
                Console.Write("Digite o número da conta origem: ");
                int numeroContaOrigem = int.Parse(Console.ReadLine());

                Console.Write("Digite o número da conta origem: ");
                int numeroContaDestino = int.Parse(Console.ReadLine());
            
                Console.Write("Digite o valor da trasferência: ");
                double valorTransferencia = double.Parse(Console.ReadLine());

                if(numeroContaOrigem >= listaContas.Count) {
                    Console.WriteLine("Conta Origem não encontrada.");
                    return;
                }

                if(numeroContaDestino >= listaContas.Count) {
                    Console.WriteLine("Conta Destino não encontrada.");
                    return;
                }

                listaContas[numeroContaOrigem].Transferir(valorTransferencia: valorTransferencia, contaDestino: listaContas[numeroContaDestino]);
            }
            else {
                Console.WriteLine("Existe apenas uma conta cadastrada.");
                return;
            }
        }

        private static void Depositar()
        {
            if(listaContas.Count != 0) {
                Console.Write("Digite o número da conta: ");
                int numeroConta = int.Parse(Console.ReadLine());
            
                Console.Write("Digite o valor do depósito: ");
                double valorDeposito = double.Parse(Console.ReadLine());

                if(numeroConta >= listaContas.Count) {
                    Console.WriteLine("Conta não encontrada.");
                    return;
                }

                listaContas[numeroConta].Depositar(valorDeposito: valorDeposito);
            }
            else {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
        }
        
        private static void Sacar()
        {
            if(listaContas.Count != 0) {
                Console.Write("Digite o número da conta: ");
                int numeroConta = int.Parse(Console.ReadLine());
            
                Console.Write("Digite o valor do saque: ");
                double valorSaque = double.Parse(Console.ReadLine());

                if(numeroConta >= listaContas.Count) {
                    Console.WriteLine("Conta não encontrada.");
                    return;
                }

                listaContas[numeroConta].Sacar(valorSaque: valorSaque);
            }
            else {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if(listaContas.Count == 0) {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            foreach (Conta conta in listaContas) {
                conta.statusConta();
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para conta pessoa fisica ou 2 para pessoa juridica: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double saldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double credito = double.Parse(Console.ReadLine());

            Conta conta = new Conta(tipoConta: (TipoConta)tipoConta, 
                                                saldo: saldo, 
                                                credito: credito, 
                                                nome: nomeCliente);

            listaContas.Add(conta);
        }
        #endregion
    }
}
