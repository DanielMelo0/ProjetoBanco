using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

    namespace ProjetoBanco
    {
        class Pessoa
        {
            public string Nome { get; set; }
            public int Idade { get; set; }
            public string RG { get; set; }
            public string CPF { get; set; }
            public string Endereco { get; set; }
            public int Telefone { get; set; }
        }

        class Cliente : Pessoa
        {
            public bool Prioritario { get; set; }
        }

        class Program
        {
            static Cliente[] fila = new Cliente[10];
            static int quantidadeClientes = 0;

            static void Main(string[] args)
            {
                string opcao;

                do
                {
                    Console.WriteLine("\n=== MENU ===");
                    Console.WriteLine("1 - Cadastrar e Inserir Cliente");
                    Console.WriteLine("2 - Listar Fila");
                    Console.WriteLine("3 - Atender Cliente");
                    Console.WriteLine("q - Sair");
                    Console.Write("Opção: ");
                    opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            CadastrarCliente();
                            break;
                        case "2":
                            ListarFila();
                            break;
                        case "3":
                            AtenderCliente();
                            break;
                        case "q":
                            Console.WriteLine("Saindo...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }

                } while (opcao != "q");
            }

            static void CadastrarCliente()
            {
                if (quantidadeClientes >= 10)
                {
                    Console.WriteLine("Fila cheia! Não é possível adicionar mais clientes.");
                    return;
                }

                Cliente novoCliente = new Cliente();

                Console.Write("Nome do cliente: ");
                novoCliente.Nome = Console.ReadLine();

                Console.Write("Idade do cliente: ");
                novoCliente.Idade = int.Parse(Console.ReadLine());

                Console.Write("RG do cliente: ");
                novoCliente.RG = Console.ReadLine();

                Console.Write("CPF do cliente: ");
                novoCliente.CPF = Console.ReadLine();

                Console.Write("Endereço do cliente: ");
                novoCliente.Endereco = Console.ReadLine();

                Console.Write("Telefone do Cliente: ");
                novoCliente.Telefone = int.Parse(Console.ReadLine());

            // Definir se é prioritário
            if (novoCliente.Idade >= 60)
                {
                    novoCliente.Prioritario = true;
                    Console.WriteLine("Cliente classificado como prioritário (idade >= 60 anos).");
                }
                else
                {
                    Console.Write("O cliente é prioritário? (s/n): ");
                    string resposta = Console.ReadLine();
                    novoCliente.Prioritario = resposta.ToLower() == "s";
                }

                InserirNaFila(novoCliente);
            }

            static void InserirNaFila(Cliente cliente)
            {
   
                if (quantidadeClientes >= 10)
                {
                    Console.WriteLine("Fila cheia! Não é possível adicionar mais clientes.");
                    return;
                }

                if (cliente.Prioritario)
                {
                    int posicao = 0;

                    // Encontra o último prioritário
                    for (int i = 0; i < quantidadeClientes; i++)
                    {
                        if (fila[i].Prioritario)
                            posicao = i + 1;
                        else
                            break;
                    }

                    // Move os outros clientes para abrir espaço
                    for (int i = quantidadeClientes; i > posicao; i--)
                    {
                        fila[i] = fila[i - 1];
                    }

                    fila[posicao] = cliente;
                }
                else
                {
                    fila[quantidadeClientes] = cliente;
                }

                quantidadeClientes++;
                Console.WriteLine("Cliente inserido na fila com sucesso!");
            }

            static void ListarFila()
            {
                if (quantidadeClientes == 0)
                {
                    Console.WriteLine("Fila vazia.");
                    return;
                }

                Console.WriteLine("\n=== FILA DE CLIENTES ===");
                for (int i = 0; i < quantidadeClientes; i++)
                {
                Console.WriteLine($"{i + 1}. Nome: {fila[i].Nome} - Idade: {fila[i].Idade} - RG: {fila[i].RG} - CPF: {fila[i].CPF} - Endereço: {fila[i].Endereco} - Telefone: {fila[i].Telefone} - Prioritário: {(fila[i].Prioritario ? "Sim" : "Não")}");
            }
            }

            static void AtenderCliente()
            {
                if (quantidadeClientes == 0)
                {
                    Console.WriteLine("Fila vazia. Nenhum cliente para atender.");
                    return;
                }

                Console.WriteLine($"Atendendo cliente: {fila[0].Nome}");

                // Move todos uma posição para a esquerda
                for (int i = 0; i < quantidadeClientes - 1; i++)
                {
                    fila[i] = fila[i + 1];
                }
                fila[quantidadeClientes - 1] = null; // Remove referência
                quantidadeClientes--;

                Console.WriteLine("Cliente atendido com sucesso!");
            }
        }
    }
