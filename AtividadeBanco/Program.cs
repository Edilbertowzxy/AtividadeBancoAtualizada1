using System;

namespace AtividadeBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
           ContaNormal conta = new ContaNormal("Edilberto", 12345, 0.00f);

            conta.Depositar();
            conta.Sacar();
            conta.Depositar();

            conta.MostrarExtrato();
            Console.WriteLine($"Saldo atual: {conta.getSaldo():c}");
            Console.ReadLine();
        }
    }
}