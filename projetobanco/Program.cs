using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

    namespace ProjetoBanco
    {
        class Pessoa // Definição Classe Pessoa
        {
            public string Nome { get; set; }
            public int Idade { get; set; }
            public string RG { get; set; }
            public string CPF { get; set; }
            public string Endereco { get; set; }
            public int Telefone { get; set; }

            // Definição Propriedades Classe Pessoa e Inserção dos Metodos Getters e Setters
        }

        class Cliente : Pessoa // Definição Classe Cliente que Estende Classe Pessoa
        {
            public bool Prioritario { get; set; }
        }

        class Program
        {
            // Criação de um Vetor de Objetos do tipo Cliente chamado Fila com 10 Espaços
            static Cliente[] fila = new Cliente[10]; 
            // Criação de uma Variavel Estatica para Conferir a Quantidade de Clientes Presente na FIla
            static int quantidadeClientes = 0;

            static void Main(string[] args)
            {
                string opcao; // Variavel Para Armazenar Opções Inseridas pelo Usuario

                do // Inicio do Laço de Repetição do While Opt != "Q"
                {
                    Console.WriteLine("\n=== MENU ===");
                    Console.WriteLine("1 - Cadastrar e Inserir Cliente");
                    Console.WriteLine("2 - Listar Fila");
                    Console.WriteLine("3 - Atender Cliente");
                    Console.WriteLine("Q - Sair");
                    Console.Write("Opção: ");
                    // Exibição das Opções para Navegar no Sistema

                    opcao = Console.ReadLine().ToUpper(); // Leitura da Opção Inserida pelo Usuario e Converter para UpperCase

                    switch (opcao) // Switch Case Para Confirmar a Opção Armazeda na Instrução Anterior
                    {
                        case "1":
                            CadastrarCliente(); // Invoca Função CadastrarCliente se Opção == 1
                            break;
                        case "2":
                            ListarFila(); // Invoca Função ListarFIla se Opção == 2
                            break;
                        case "3":
                            AtenderCliente(); // Invoca Função Atender CLiente se Opção == 3
                            break;
                        case "Q":
                            Console.WriteLine("Saindo..."); // Exibe Cadeia de Caracteres se Opção == Q
                            break;
                        default:
                            Console.WriteLine("Opção inválida!"); // Retorna 
                            break;
                    }

                } while (opcao != "Q");
            }

            static void CadastrarCliente() // Inicio Função Cadastrar Cliente
            {
                if (quantidadeClientes >= 10) // Confirma se a Quantidade dos Clientes na FIla é igual ou Superior a 10
                {
                    Console.WriteLine("Fila cheia! Não é possível adicionar mais clientes."); // Retorna Mensagem caso Fila estiver Cheia
                    return;
                }

                Cliente novoCliente = new Cliente(); // Instancia do Objeto Cliente

                Console.Write("Nome do cliente: ");     // Exibe Texto Para Informar ao Usuario e Solicitar Informação
                novoCliente.Nome = Console.ReadLine(); // Atribui Nome ao Objeto novoCliente

                Console.Write("Idade do cliente: ");                // Exibe Texto Para Informar ao Usuario e Solicitar Informação
                novoCliente.Idade = int.Parse(Console.ReadLine()); //  Converte para Inteiro e Atribui valor Idade ao Objeto novoCliente 

                Console.Write("RG do cliente: ");       // Exibe Texto Para Informar ao Usuario e Solicitar Informação
                novoCliente.RG = Console.ReadLine();    // Atribui RG ao Objeto novoCliente

                Console.Write("CPF do cliente: ");      // Exibe Texto Para Informar ao Usuario e Solicitar Informação
                novoCliente.CPF = Console.ReadLine();   // Atribui CPF ao Objeto novoCliente

                Console.Write("Endereço do cliente: ");    // Exibe Texto Para Informar ao Usuario e Solicitar Informação
                novoCliente.Endereco = Console.ReadLine(); // Atribui Endereco ao Objeto novoCliente

                Console.Write("Telefone do Cliente: ");
                novoCliente.Telefone = int.Parse(Console.ReadLine());

            // Definir se é prioritário
            if (novoCliente.Idade >= 60) // Valida se Idade Cliente é => 60
                {
                    novoCliente.Prioritario = true;  // Define propridade Prioritario como True
                    Console.WriteLine("Cliente classificado como prioritário (idade >= 60 anos).");
                }
                else
                {
                    Console.Write("O cliente é prioritário? (s/n): "); // Solicita Informação se For Prioritario 
                    string resposta = Console.ReadLine();
                    novoCliente.Prioritario = resposta.ToLower() == "s";  // Se Resposta for S Atribui Propriedade Prioritario como True
                }

                InserirNaFila(novoCliente); // Após Cadastro, Invoca Função Inserir Na FIla passando Objeto novoCliente
            }

            static void InserirNaFila(Cliente cliente) // Inicio Função InserirNaFila 
            {
   
                if (quantidadeClientes >= 10) // Verifica se FIla esta Cheia
                {
                    Console.WriteLine("Fila cheia! Não é possível adicionar mais clientes.");
                    return;
                }

                if (cliente.Prioritario)                         // Verifica se o Cliente que foi passado como Parametro é Prioritario
                {
                    int posicao = 0;                             // Inicio Variavel para Armazenar a Posição onde o Novo Cliente Sera Inserido

                    // Encontra o último prioritário
                    for (int i = 0; i < quantidadeClientes; i++) // Percorre o Array de Acordo com a Quantidade de Clientes na FIla
                    {
                        if (fila[i].Prioritario)                 // Ao encontrar o Ultimo Prioritario Incrementa a mesma a Variavel Posicao para usar como Referencia para Inserção
                            posicao = i + 1;                     // Atribui Valor a Variavel Posicao 
                        else
                            break;                               // Se não Encontrar o Primeiro Cliente Prioritario, Para o Laço
                    }                                            // Final do Laço For para Encontrar a Posição Após o Ultimo Cliente Prioritario

                    // Move os outros clientes para abrir espaço
                    for (int i = quantidadeClientes; i > posicao; i--) // Inicia o Laço de Repetição do Final da Fila 
                    {
                        fila[i] = fila[i - 1];                         // Move Cada CLiente para uma Posição a Frente Até alcançar a Posição de Inserção
                    }

                    fila[posicao] = cliente;                           // Após Abrir Espaço e Alcançar a Posição de Inserção Insere o Novo Cliente Prioritario na Posição Correta
                }
                else
                {
                    fila[quantidadeClientes] = cliente;                // Se não For Prioritario, Insere Cliente No Final da FIla
                }

                quantidadeClientes++; // Atualiza o Valor de Quantidade de Clientes na FIla
                Console.WriteLine("Cliente inserido na fila com sucesso!"); // Retorna Mensagem de Inserçao Bem Sucedida 
            }

            static void ListarFila() // Inicio Função ListarFila
            {
                if (quantidadeClientes == 0) // Se FIla Estiver Vazia, Retorna Mensagem
                {
                    Console.WriteLine("Fila vazia.");
                    return; // Sai da função se não houver clientes
                }

                Console.WriteLine("\n=== FILA DE CLIENTES ===");
                for (int i = 0; i < quantidadeClientes; i++) // Percorre todos os Clientes Existentes
                {
                Console.WriteLine($"{i + 1}. Nome: {fila[i].Nome} - Idade: {fila[i].Idade} - RG: {fila[i].RG} - CPF: {fila[i].CPF} - Endereço: {fila[i].Endereco} - Telefone: {fila[i].Telefone} - Prioritário: {(fila[i].Prioritario ? "Sim" : "Não")}");
            }
            }

            static void AtenderCliente() // Inicio Função Atender Cliente
            {
                if (quantidadeClientes == 0) // Verifica se a Fila Esta Vazia
                {
                    Console.WriteLine("Fila vazia. Nenhum cliente para atender.");
                    return; // Sai Da Função se Não Houver Clientes
                }
                Console.WriteLine("\n=== Sessão de Atendimento ===");
                Console.WriteLine($"Atendendo cliente: {fila[0].Nome}"); // Informa nome do Cliente a Ser Atendido

                // Move todos uma posição para a esquerda (Quem Estava em 1 vai pra 0)
                for (int i = 0; i < quantidadeClientes - 1; i++) // 
                {
                    fila[i] = fila[i + 1];  // Sobrescreve cada posição com o cliente da próxima posição
                }
                fila[quantidadeClientes - 1] = null; // Remove referência do último cliente, agora duplicado
                quantidadeClientes--; // Decrementa Quantidade de Cliente Total de CLientes na Fila

                Console.WriteLine("Cliente atendido com sucesso!");
            }
        }
    }
