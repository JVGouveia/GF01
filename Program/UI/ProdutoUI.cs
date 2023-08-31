using System;
using Program.Model;

namespace Program.UI
{
    public class ProdutoUI
    {
        internal static List<Produto> produtos = new List<Produto>();

        public static void Run()
        {
            int choice;
            do
            {
                Console.WriteLine("Gerenciar Produtos:");
                Console.WriteLine("1. Listar Produtos");
                Console.WriteLine("2. Adicionar Produto");
                Console.WriteLine("3. Atualizar Produto");
                Console.WriteLine("4. Remover Produto");
                Console.WriteLine("5. Voltar ao Menu Principal");
                Console.Write("Escolha a operação: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            ListarProdutos();
                            break;
                        case 2:
                            if (CategoriaUI.ListarCategorias() > 0)
                                AdicionarProduto();
                            else
                                Console.WriteLine("Crie ao menos uma categoria");
                            break;
                        case 3:
                            AtualizarProduto();
                            break;
                        case 4:
                            RemoverProduto();
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

        internal static int ListarProdutos()
        {
            int contador = 0;
            Console.WriteLine("\nLista de Produtos:");
            foreach (var produto in produtos)
            {
                Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Descrição: {produto.Descricao}, " +
                    $"Preço: {produto.Preco:C}, Categoria: {produto.Categoria.Nome}");
                contador++;
            }
            return contador;
        }

        internal static void AdicionarProduto()
        {
            Console.WriteLine("\nAdicionar Produto:");
            Console.Write("Nome: ");
            string? nome = Console.ReadLine();
            Console.Write("Descrição: ");
            string? descricao = Console.ReadLine();
            Console.Write("Preço: ");
            if (float.TryParse(Console.ReadLine(), out float preco))
            {
                Categoria? categoria = null;
                do
                {
                    Console.Write("Informe o id da categoria: ");
                    CategoriaUI.ListarCategorias();
                    if (int.TryParse(Console.ReadLine(), out int categoriaId))
                    {
                        categoria = CategoriaUI.categorias.Find(c => c.Id == categoriaId);
                        if (categoria == null)
                        {
                            Console.WriteLine("Categoria não encontrada. Tente novamente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID de categoria inválido. Tente novamente.");
                    }
                } while (categoria == null);

                Produto produto = new Produto(nome, descricao, preco, categoria);
                produtos.Add(produto);

                Console.WriteLine("Produto adicionado com sucesso.\n");
            }
            else
            {
                Console.WriteLine("Preço inválido. Tente novamente.");
            }
        }

        internal static void AtualizarProduto()
        {
            Console.WriteLine("\nAtualizar Produto:");
            ListarProdutos();
            Console.Write("Informe o ID do produto que deseja atualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Produto? produto = produtos.Find(p => p.Id == id);
                if (produto != null)
                {
                    Console.Write("Novo Nome: ");
                    string? novoNome = Console.ReadLine();
                    Console.Write("Nova Descrição: ");
                    string? novaDescricao = Console.ReadLine();
                    Console.Write("Novo Preço: ");
                    if (float.TryParse(Console.ReadLine(), out float novoPreco))
                    {
                        Categoria? novaCategoria = null;
                        do
                        {
                            Console.Write("Nova categoria: ");

                            if (int.TryParse(Console.ReadLine(), out int categoriaId))
                            {
                                novaCategoria = CategoriaUI.categorias.Find(c => c.Id == categoriaId);
                                if (novaCategoria == null)
                                {
                                    Console.WriteLine("Categoria não encontrada. Tente novamente.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("ID de categoria inválido. Tente novamente.");
                            }
                        } while (novaCategoria == null);

                        produto.Nome = novoNome;
                        produto.Descricao = novaDescricao;
                        produto.Preco = novoPreco;
                        produto.Categoria = novaCategoria;
                        Console.WriteLine("Produto adicionado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Preço inválido. Tente novamente.");
                    }
                }
                else
                {
                    Console.WriteLine("Produto não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }

        internal static void RemoverProduto()
        {
            Console.WriteLine("\nRemover Produto:");
            ListarProdutos();
            Console.Write("Informe o ID do produto que deseja remover: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Produto? produto = produtos.Find(p => p.Id == id);
                if (produto != null)
                {
                    produtos.Remove(produto);
                    Console.WriteLine("Produto removido com sucesso.");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }
    }
}