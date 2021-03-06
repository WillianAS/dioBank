using System;

namespace dioBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "Willian");
            minhaConta.statusConta();
        }
    }
}
