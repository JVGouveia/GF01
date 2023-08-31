using System;
using System.Collections.Generic;
using Program.Model;

namespace Program.UI
{
    public class ClienteUI
    {
        internal static List<Cliente> clientes = new List<Cliente>();

        public static void Run()
        {
            int choice;
            do
            {
                Console.WriteLine("Gerenciar Clientes:");
                Console.WriteLine("1. Listar Clientes");
                Console.WriteLine("2. Adicionar Cliente");
                Console.WriteLine("3. Atualizar Cliente");
                Console.WriteLine("4. Remover Cliente");
                Console.WriteLine("5. Voltar ao Menu Principal");
                Console.Write("Escolha a operação: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            ListarClientes();
                            break;
                        case 2:
                            AdicionarCliente();
                            break;
                        case 3:
                            AtualizarCliente();
                            break;
                        case 4:
                            RemoverCliente();
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

        internal static int  ListarClientes()
        {
            int contador = 0;
            Console.WriteLine("\nLista de Clientes:");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.Id}, Nome completo: {cliente.Nome + ' ' + cliente.Sobrenome}");
                contador++;
            }
            return contador;
        }

        internal static void AdicionarCliente()
        {
            Console.WriteLine("\nAdicionar Cliente:");
            Console.Write("Nome: ");
            string? nome = Console.ReadLine();
            Console.Write("Sobrenome: ");
            string? sobrenome = Console.ReadLine();
            Console.Write("Endereço: ");
            string? endereco = Console.ReadLine();
            Console.Write("Número de Telefone: ");
            string? telefone = Console.ReadLine();

            Cliente cliente = new Cliente(nome, sobrenome, endereco, telefone);
            clientes.Add(cliente);

            Console.WriteLine("Cliente adicionado com sucesso.\n");
        }

        internal static void AtualizarCliente()
        {
            Console.WriteLine("\nAtualizar Cliente:");
            ListarClientes();
            Console.Write("Informe o ID do cliente que deseja atualizar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Cliente? cliente = clientes.Find(c => c.Id == id);
                if (cliente != null)
                {
                    Console.Write("Novo Nome: ");
                    string? novoNome = Console.ReadLine();
                    Console.Write("Novo Sobrenome: ");
                    string? novoSobrenome = Console.ReadLine();
                    Console.Write("Novo Endereço: ");
                    string? novoEndereco = Console.ReadLine();
                    Console.Write("Novo Número de Telefone: ");
                    string? novoTelefone = Console.ReadLine();

                    cliente.Nome = novoNome;
                    cliente.Sobrenome = novoSobrenome;
                    cliente.Endereco = novoEndereco;
                    cliente.NumeroTelefone = novoTelefone;

                    Console.WriteLine("Cliente atualizado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }

        internal static void RemoverCliente()
        {
            Console.WriteLine("\nRemover Cliente:");
            ListarClientes();
            Console.Write("Informe o ID do cliente que deseja remover: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Cliente? cliente = clientes.Find(c => c.Id == id);
                if (cliente != null)
                {
                    clientes.Remove(cliente);
                    Console.WriteLine("Cliente removido com sucesso.");
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }
    }
}