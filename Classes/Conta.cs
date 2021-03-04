using System;

namespace dioBank {

    public class Conta {

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome) {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito {get; set; }
        private string Nome { get; set; }

        public bool Sacar(double valorSaque) {
            if (valorSaque > 0) {
                if (this.Saldo + this.Credito > valorSaque) {
                    this.Saldo -= valorSaque;
                    Console.WriteLine("Saldo atual da conta de {0} é {1}.", this.Nome, this.Saldo);
                    return true;
                }
                else {
                    Console.WriteLine("Saldo insuficiente!");
                    return false;
                }
            }
            else {
                return false;
            }
        }

        public void Depositar(double valorDeposito) {
            if (valorDeposito > 0) {
                this.Saldo += valorDeposito;
                Console.WriteLine("Saldo atual da conta de {0} é {1}.", this.Nome, this.Saldo);
            }
        }
    }
}