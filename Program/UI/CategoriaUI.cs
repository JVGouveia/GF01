using System;
using Program.Model;

namespace Program.UI
{
    public class CategoriaUI
    {
        internal static List<Categoria> categorias = new List<Categoria>();
        public static void Run()
        {
            int choice;
            do
            {
                Console.WriteLine("Gerenciar Categorias:");
                Console.WriteLine("1. Listar Categorias");
                Console.WriteLine("2. Adicionar Categoria");
                Console.WriteLine("3. Atualizar Categoria");
                Console.WriteLine("4. Remover Categoria");
                Console.WriteLine("5. Voltar ao Menu Principal");
                Console.Write("Escolha a operação: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            ListarCategorias();
                            break;
                        case 2:
                            AdicionarCategoria();
                            break;
                        case 3:
                            AtualizarCategoria();
                            break;
                        case 4:
                            RemoverCategoria();
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

        internal static int ListarCategorias()
        {
            int contador = 0;
            Console.WriteLine("\nLista de Categorias:");
            foreach (var categoria in categorias)
            {
                Console.WriteLine($"ID: {categoria.Id}, Nome: {categoria.Nome}, Descrição: {categoria.Descricao}");
                contador++;
            }
            return contador;
        }

        internal static void AdicionarCategoria()
        {
            Console.WriteLine("\nAdicionar Categoria:");
            Console.Write("Nome: ");
            string? nome = Console.ReadLine();
            Console.Write("Descrição: ");
            string? descricao = Console.ReadLine();

            Categoria categoria = new Categoria(nome, descricao);
            categorias.Add(categoria);

            Console.WriteLine("Categoria adicionada com sucesso.\n");
        }

        internal static void AtualizarCategoria()
        {
            Console.WriteLine("\nAtualizar Categoria:");
            ListarCategorias();
            Console.Write("Informe o ID da categoria que deseja atualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Categoria? categoria = categorias.Find(c => c.Id == id);
                if (categoria != null)
                {
                    Console.Write("Novo Nome: ");
                    string? novoNome = Console.ReadLine();
                    Console.Write("Nova Descrição: ");
                    string? novaDescricao = Console.ReadLine();

                    categoria.Nome = novoNome;
                    categoria.Descricao = novaDescricao;

                    Console.WriteLine("Categoria atualizada com sucesso.");
                }
                else
                {
                    Console.WriteLine("Categoria não encontrada.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }

        internal static void RemoverCategoria()
        {
            Console.WriteLine("\nRemover Categoria:");
            ListarCategorias();
            Console.Write("Informe o ID da categoria que deseja remover: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Categoria? categoria = categorias.Find(c => c.Id == id);
                if (categoria != null)
                {
                    categorias.Remove(categoria);
                    Console.WriteLine("Categoria removida com sucesso.");
                }
                else
                {
                    Console.WriteLine("Categoria não encontrada.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }
    }
}