using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeBanco
{
    internal class ContaNormal : ContaBancaria
    {
       
        public ContaNormal(string nomeTitular, int numeroConta, float saldo) : base(nomeTitular, numeroConta, saldo)
        {
           
        }
        public override void Sacar()
        {
            Console.Write("Digite o valor para saque: ");
            if (!float.TryParse(Console.ReadLine(), out float valor) || valor <= 0)
            {
                Console.WriteLine("Valor inválido para saque.");
                return;
            }

            saldo -= valor;
            extrato.Add(new Movimentacao("Saque", valor, saldo));
            Console.WriteLine($"Saque de {valor:c} realizado com sucesso!");
        }
       
    }
}