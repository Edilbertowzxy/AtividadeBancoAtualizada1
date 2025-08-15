using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeBanco
{
    internal abstract class ContaBancaria
    {
        protected string nomeTitular;
        protected int numeroConta;
        protected float saldo;
        protected List<Movimentacao> extrato = new List<Movimentacao>();


        public ContaBancaria(string nomeTitular, int numeroConta, float saldoInicial)
        {
            this.nomeTitular = nomeTitular;
            this.numeroConta = numeroConta;
            this.saldo = saldoInicial;
            extrato.Add(new Movimentacao("Aberto", saldoInicial, saldoInicial));
            

        }
        public string getNomeTitular()
        {
            return this.nomeTitular;
        }
        public int getNumeroConta()
        {
            return this.numeroConta;
        }
        public float getSaldo() 
        { 
            return this.saldo;
        }
        public void setNomeTitular(string nomeTitular)
        {
            this.nomeTitular = nomeTitular;
        }
        public void setNumeroConta(int numeroConta)
        {
            this.numeroConta = numeroConta;
        }
        public void setSaldo(float saldo)
        {
            this.saldo = saldo;
        }
        public virtual void Depositar()
        {
            Console.Write("Digite o valor do depósito: ");
            if (!float.TryParse(Console.ReadLine(), out float valor) || valor <= 0)
            {
                Console.WriteLine("Valor inválido para depósito.");
                return;
            }

            saldo += valor;
            extrato.Add(new Movimentacao("Depósito", valor, saldo));
            Console.WriteLine($"Depósito de {valor:c} realisado com sucesso!");
        }
        public abstract void Sacar ();

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