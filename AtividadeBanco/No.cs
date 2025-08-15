using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeBanco
{
    public class NoLista<T>
    {
        public T Dados { get; set; }
        public NoLista<T> Proximo { get; set; }
        public NoLista<T> Anterior { get; set; }

        public NoLista(T dados)
        {
            Dados = dados;
            Proximo = null;
            Anterior = null;
        }
    }

    // Lista duplamente encadeada genérica
    public class ListaDuplamenteEncadeada<T>
    {
        private NoLista<T> primeiro;
        private NoLista<T> ultimo;
        private int tamanho;

        public ListaDuplamenteEncadeada()
        {
            primeiro = null;
            ultimo = null;
            tamanho = 0;
        }

        // Propriedade para obter o tamanho da lista
        public int Tamanho => tamanho;

        // Verifica se a lista está vazia
        public bool EstaVazia => primeiro == null;

        // Adiciona um elemento no início da lista
        public void AdicionarNoInicio(T dados)
        {
            NoLista<T> novoNo = new NoLista<T>(dados);

            if (EstaVazia)
            {
                primeiro = ultimo = novoNo;
            }
            else
            {
                novoNo.Proximo = primeiro;
                primeiro.Anterior = novoNo;
                primeiro = novoNo;
            }
            tamanho++;
        }

        // Adiciona um elemento no final da lista
        public void AdicionarNoFinal(T dados)
        {
            NoLista<T> novoNo = new NoLista<T>(dados);

            if (EstaVazia)
            {
                primeiro = ultimo = novoNo;
            }
            else
            {
                ultimo.Proximo = novoNo;
                novoNo.Anterior = ultimo;
                ultimo = novoNo;
            }
            tamanho++;
        }

        // Remove o primeiro elemento
        public T RemoverDoInicio()
        {
            if (EstaVazia)
            {
                Console.WriteLine("Lista está vazia");
                return default(T);
            }

            T dados = primeiro.Dados;

            if (primeiro == ultimo)
            {
                primeiro = ultimo = null;
            }
            else
            {
                primeiro = primeiro.Proximo;
                primeiro.Anterior = null;
            }

            tamanho--;
            return dados;
        }

        // Remove o último elemento
        public T RemoverDoFinal()
        {
            if (EstaVazia)
            {
                Console.WriteLine("Lista está vazia");
                return default(T);
            }

            T dados = ultimo.Dados;

            if (primeiro == ultimo)
            {
                primeiro = ultimo = null;
            }
            else
            {
                ultimo = ultimo.Anterior;
                ultimo.Proximo = null;
            }

            tamanho--;
            return dados;
        }

        // Busca um elemento na lista por posição
        public T BuscarPorPosicao(int posicao)
        {
            if (posicao < 0 || posicao >= tamanho)
            {
                Console.WriteLine("Posição inválida");
                return default(T);
            }

            NoLista<T> atual = primeiro;
            for (int i = 0; i < posicao; i++)
            {
                atual = atual.Proximo;
            }

            return atual.Dados;
        }

        // Remove elemento por posição
        public T RemoverPorPosicao(int posicao)
        {
            if (posicao < 0 || posicao >= tamanho)
            {
                Console.WriteLine("Posição inválida");
                return default(T);
            }

            if (posicao == 0)
            {
                return RemoverDoInicio();
            }

            if (posicao == tamanho - 1)
            {
                return RemoverDoFinal();
            }

            NoLista<T> atual = primeiro;
            for (int i = 0; i < posicao; i++)
            {
                atual = atual.Proximo;
            }

            atual.Anterior.Proximo = atual.Proximo;
            atual.Proximo.Anterior = atual.Anterior;

            tamanho--;
            return atual.Dados;
        }

        // Lista todos os elementos (do início para o fim)
        public void ListarElementos()
        {
            if (EstaVazia)
            {
                Console.WriteLine("Lista vazia.");
                return;
            }

            Console.WriteLine("\n=== ELEMENTOS DA LISTA ===");
            NoLista<T> atual = primeiro;
            int posicao = 0;

            while (atual != null)
            {
                Console.WriteLine($"[{posicao}] {atual.Dados}");
                atual = atual.Proximo;
                posicao++;
            }
            Console.WriteLine($"Total de elementos: {tamanho}\n");
        }

        // Lista todos os elementos (do fim para o início)
        public void ListarElementosReverso()
        {
            if (EstaVazia)
            {
                Console.WriteLine("Lista vazia.");
                return;
            }

            Console.WriteLine("\n=== ELEMENTOS DA LISTA (REVERSO) ===");
            NoLista<T> atual = ultimo;
            int posicao = tamanho - 1;

            while (atual != null)
            {
                Console.WriteLine($"[{posicao}] {atual.Dados}");
                atual = atual.Anterior;
                posicao--;
            }
            Console.WriteLine($"Total de elementos: {tamanho}\n");
        }

        // Limpa toda a lista
        public void Limpar()
        {
            primeiro = ultimo = null;
            tamanho = 0;
            Console.WriteLine("Lista limpa.");
        }

        // Obter o primeiro elemento sem remover
        public T ObterPrimeiro()
        {
            if (EstaVazia)
            {
                return default(T);
            }
            return primeiro.Dados;
        }

        // Obter o último elemento sem remover
        public T ObterUltimo()
        {
            if (EstaVazia)
            {
                return default(T);
            }
            return ultimo.Dados;
        }

        // Converte todos os elementos para string
        public override string ToString()
        {
            if (EstaVazia)
            {
                return "Lista vazia";
            }

            string resultado = "Lista: ";
            NoLista<T> atual = primeiro;

            while (atual != null)
            {
                resultado += atual.Dados.ToString();
                if (atual.Proximo != null)
                {
                    resultado += " <-> ";
                }
                atual = atual.Proximo;
            }

            return resultado;
        }
    }
}