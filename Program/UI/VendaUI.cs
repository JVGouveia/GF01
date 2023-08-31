using System;
using Program.Model;

namespace Program.UI
{
    public class VendaUI
    {
        private static List<Venda> vendas = new List<Venda>();
        public static void Run()
        {
            int choice;
            do
            {
                Console.WriteLine("Gerenciar Vendas:");
                Console.WriteLine("1. Listar Vendas");
                Console.WriteLine("2. Registrar Venda");
                Console.WriteLine("3. Detalhes da Venda");
                Console.WriteLine("4. Voltar ao Menu Principal");
                Console.Write("Escolha a operação: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            ListarVendas();
                            break;
                        case 2:
                            if(ClienteUI.ListarClientes() > 0 && ProdutoUI.ListarProdutos() > 0)
                                RegistrarVenda();
                            else 
                                Console.WriteLine("Crie ao menos um cliente e ou produto");
                            break;
                        case 3:
                            ExibirDetalhesVenda();
                            break;
                        case 4:
                            RemoverProdutoVenda();
                            break;
                        case 5:
                            Console.WriteLine("Voltando ao Menu Principal.");
                            return;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }

            } while (true);
        }

        internal static void ListarVendas()
        {
            Console.WriteLine("\nLista de Vendas:");
            foreach (var venda in vendas)
            {
                Console.WriteLine($"ID: {venda.Id}, Cliente: {venda.Cliente.Nome}, Data: {venda.DataDaVenda}, Valor Total: {venda.ValorTotal:C}");
            }
        }

        internal static void RegistrarVenda()
        {
            Console.WriteLine("\nRegistrar Venda:");

            Cliente cliente = SelecionarCliente();
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            Venda venda = new Venda(cliente);

            List<Produto> produtosVendidos = SelecionarProdutos(venda);
            if (produtosVendidos.Count == 0)
            {
                Console.WriteLine("Nenhum produto selecionado. Venda cancelada.");
                return;
            }

            vendas.Add(venda);



            Console.WriteLine("Venda registrada com sucesso.\n");
        }

        internal static Cliente SelecionarCliente()
        {
            Console.Write("Informe o ID do cliente: ");
            ClienteUI.ListarClientes();
            if (int.TryParse(Console.ReadLine(), out int clienteId))
            {
                Cliente? cliente = ClienteUI.clientes.Find(c => c.Id == clienteId);
                return cliente;
            }
            return null;
        }

        private static List<Produto> SelecionarProdutos(Venda venda)
        {
            List<Produto> produtosSelecionados = new List<Produto>();

            int produtoId;
            do
            {
                Console.Write("Informe o ID do produto (0 para sair): ");
                ProdutoUI.ListarProdutos();
                if (int.TryParse(Console.ReadLine(), out produtoId))
                {
                    if (produtoId == 0)
                        break;

                    Produto produto = ProdutoUI.produtos.Find(p => p.Id == produtoId);
                    if (produto != null)
                    {
                        produtosSelecionados.Add(produto);
                        venda.AdicionarProduto(produto);
                        Console.WriteLine($"{produto.Nome} adicionado ao carrinho.");
                    }
                    else
                    {
                        Console.WriteLine("Produto não encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("ID de produto inválido. Tente novamente.");
                }
            } while (true);

            return produtosSelecionados;
        }

        private static void ExibirDetalhesVenda()
        {
            Console.Write("Informe o ID da venda que deseja ver os detalhes: ");
            ListarVendas();
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Venda? venda = vendas.Find(v => v.Id == id);
                if (venda != null)
                {
                    Console.WriteLine($"Detalhes da Venda ID {venda.Id}:");
                    Console.WriteLine($"Cliente: {venda.Cliente.Nome}");
                    Console.WriteLine($"Data: {venda.DataDaVenda}");
                    Console.WriteLine("Produtos Vendidos:");
                    foreach (var produto in venda.Produtos)
                    {
                        Console.WriteLine($"  - {produto.Nome}");
                    }
                    Console.WriteLine($"Valor Total: {venda.ValorTotal:C}");
                }
                else
                {
                    Console.WriteLine("Venda não encontrada.");
                }
            }
            else
            {
                Console.WriteLine("ID de venda inválido.");
            }
        }

        private static void RemoverProdutoVenda()
        {
        Console.Write("Informe o ID da venda da qual deseja remover um produto: ");
        ListarVendas();
        if (int.TryParse(Console.ReadLine(), out int vendaId))
        {
            Venda venda = vendas.Find(v => v.Id == vendaId);
            if (venda != null)
            {
                Console.WriteLine("Informe o ID do produto que deseja remover da venda: ");
                foreach (var produto in venda.Produtos)
                {
                    Console.WriteLine($"{produto.Id} - {produto.Nome}");
                }
                if (int.TryParse(Console.ReadLine(), out int produtoId))
                {
                    Produto produto = venda.Produtos.Find(p => p.Id == produtoId);
                    if (produto != null)
                    {
                        try
                        {
                            venda.RemoverProduto(produto); // Chamando a função RemoverProduto da venda
                            Console.WriteLine("Produto removido da venda com sucesso.");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Produto não encontrado na venda.");
                    }
                }
                else
                {
                    Console.WriteLine("ID de produto inválido.");
                }
            }
            else
            {
                Console.WriteLine("Venda não encontrada.");
            }
        }
        else
        {
            Console.WriteLine("ID de venda inválido.");
        }
    }

    }
}