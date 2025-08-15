using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeBanco
{
    internal class ContaEspecial : ContaBancaria
    {
        private float limite;
        public ContaEspecial(string nomeTitular, int numeroConta, float saldo) : base (nomeTitular, numeroConta, saldo)
        {
            this.limite = limite;
        }
        public override void Sacar()
        {
            Console.Write("Digite o valor para saque: ");
            if (!float.TryParse(Console.ReadLine(), out float valor) || valor <= 0)
            {
                Console.WriteLine("Valor inválido para saque.");
                return;
            }
            if (valor > saldo)
            {
                Console.WriteLine("Saldo insuficiente.");
                return;
            }
            saldo -= valor;
            extrato.Add(new Movimentacao("Saque", valor, saldo));
            Console.WriteLine($"Saque de {valor:c} realizado com sucesso!");
        }
        public void MostrarExtrato()
        {

            Console.WriteLine($"\nExtrato da conta {numeroConta} -Titular: {nomeTitular}");
            foreach (var movimentacao in extrato)
            {
                Console.WriteLine(movimentacao);
            }
        }
    }
}