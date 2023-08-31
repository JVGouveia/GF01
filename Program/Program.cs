using System;
using System.Collections.Generic;
using Program.UI;

class Principal
{
    static void Main()
    {
        try {
            Console.Clear();
            int choice;

            do
            {
                Console.WriteLine("Loja de roupas GMV");
                Console.WriteLine("1. Gerenciar Categorias");
                Console.WriteLine("2. Gerenciar Produtos");
                Console.WriteLine("3. Gerenciar Clientes");
                Console.WriteLine("4. Gerenciar Vendas");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha a operação: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            CategoriaUI.Run();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            ProdutoUI.Run();
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            ClienteUI.Run();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            VendaUI.Run();
                            Console.Clear();
                            break;
                        case 5:
                            Console.WriteLine("Saindo do programa.");
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }

            } while (choice != 5);
        } catch (Exception e) {
            Console.WriteLine("Erro: " + e.Message);
        }
    }
}