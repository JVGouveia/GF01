using System;
using System.Collections.Generic;


namespace Program.Model
{
    public class Venda
    {
        private static int proximoId = 1;
        private int id;
        private Cliente cliente;
        private List<Produto> produtos;
        private DateTime dataDaVenda;
        private float valorTotal;

        public Venda(Cliente cliente)
        {
            this.id = proximoId++;
            this.cliente = cliente;
            this.produtos = new List<Produto>();
            this.dataDaVenda = DateTime.Now;
            this.valorTotal = 0;
        }

        public void AdicionarProduto(Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");

            produtos.Add(produto);
            valorTotal += produto.Preco;
        }

        public void RemoverProduto(Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");

            if (!produtos.Contains(produto))
                throw new InvalidOperationException("O produto não está na lista de produtos vendidos.");

            produtos.Remove(produto);
            valorTotal -= produto.Preco;
        }

        public int Id
        {
            get { return id; }
        }

        public Cliente Cliente
        {
            get { return cliente; }
        }

        public List<Produto> Produtos
        {
            get { return produtos; }
        }

        public DateTime DataDaVenda
        {
            get { return dataDaVenda; }
        }

        public float ValorTotal
        {
            get { return valorTotal; }
        }
    }
}