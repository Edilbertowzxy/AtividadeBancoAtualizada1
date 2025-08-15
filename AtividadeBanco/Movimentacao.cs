using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeBanco
{
    internal class Movimentacao
    {
        private string Tipo;
        private float Valor;
        private DateTime Data;
        private float SaldoAposMovimentacao;

        public Movimentacao(string tipo, float valor, float saldoAposMovimentacao)
        {
            this.Tipo = tipo;
            this.Valor = valor;
            this.Data = DateTime.Now;
            this.SaldoAposMovimentacao = saldoAposMovimentacao;
        }

        public override string ToString()
        {
            return $"{Data:dd/MM/yyyy HH:mm} | {Tipo} | Valor: {Valor:c} | Saldo após: {SaldoAposMovimentacao:c}";
        }
    }
}
