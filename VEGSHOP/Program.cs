using System;

namespace VEGSHOP
{
    class Program
    {
        static ProdutoRepositorio estoque = new ProdutoRepositorio();
        static void Main(string[] args)
        {
            string opcaoLoja = ObterOpcaoLoja();

            while (opcaoLoja.ToUpper() != "X")
            {
                switch (opcaoLoja)
                {
                    case "1":
                        Console.Clear(); ListarProdutos();
                        break;
                    case "2":
                        Console.Clear(); InserirProdutos();
                        break;
                    case "3":
                        Console.Clear(); AtualizarProdutos();
                        break;
                    case "4":
                        Console.Clear(); ExcluirProdutos();
                        break;
                    case "5":
                        Console.Clear(); VisualizarProdutos();
                        break;

                    default:

                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine(" ------ OPÇÃO INVÁLIDA ------");
                        break;
                }

                opcaoLoja = ObterOpcaoLoja();
            }
            Console.WriteLine();
            Console.WriteLine(" OBRIGADO! JUNTOS FAZEMOS A DIFERENÇA!");
            Console.ReadLine();
        }
        private static void ExcluirProdutos()
        {
            Console.Write(" Digite o ID do Produto: ");
            var lista = estoque.Lista();
            var indiceProduto = int.Parse(Console.ReadLine());

            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine(" IMPOSSÍVEL EXCLUIR - NENHUM PRODUTO CADASTRADO");
                Console.WriteLine();
            }
            else
            {

                estoque.Exclui(indiceProduto);
                Console.WriteLine();
                Console.WriteLine(" ------ PRODUTO EXCLUÍDO COM SUCESSO! ------");
                Console.WriteLine();
            }
        }
        private static void VisualizarProdutos()
        {
            Console.Write(" Digite o ID do Produto: ");
            var lista = estoque.Lista();
            int indiceProduto = int.Parse(Console.ReadLine());

            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine(" IMPOSSÍVEL CONSULTAR - NENHUM PRODUTO CADASTRADO");
                Console.WriteLine();
            }
            else
            {
                var produto = estoque.RetornaPorId(indiceProduto);

                Console.WriteLine(produto);
            }

        }

        private static void AtualizarProdutos()
        {
            Console.Write(" Digite o ID do Produto: ");
            var lista = estoque.Lista();
            var indiceProduto = int.Parse(Console.ReadLine());

            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine(" IMPOSSÍVEL ATUALIZAR - NENHUM PRODUTO CADASTRADO");
                Console.WriteLine();
            }
            else
            {
                foreach (int i in Enum.GetValues(typeof(CategoriaProduto)))
                {
                    Console.WriteLine($"{i}-{Enum.GetName(typeof(CategoriaProduto), i)}");
                }
                Console.Write(" Digite a Categoria do seu Produto entre as opções acima: ");
                int entradaCategoriaProdutos = int.Parse(Console.ReadLine());

                Console.Write(" Digite o nome do seu Produto: ");
                string entradaNomeProduto = Console.ReadLine();

                Console.Write(" Digite a Descrição do seu Produto: ");
                string entradaDescricaoProduto = Console.ReadLine();

                Console.WriteLine(" O seu produto é Vegano?:");
                foreach (int i in Enum.GetValues(typeof(EscolhaDoVendedor)))
                {
                    Console.WriteLine($"{i}-{Enum.GetName(typeof(EscolhaDoVendedor), i)}");
                }
                string entradaVegano = (Console.ReadLine());
                if (entradaVegano == "1")
                    entradaVegano = "true";
                else
                    entradaVegano = "false";
                Convert.ToBoolean(entradaVegano);

                Produto atualizaProduto = new Produto(idProduto: indiceProduto,
                         categoria: (CategoriaProduto)entradaCategoriaProdutos,
                         nomeProduto: entradaNomeProduto,
                         descricaoProduto: entradaDescricaoProduto,
                         produtoVegano: Convert.ToBoolean(entradaVegano));

                estoque.Atualiza(indiceProduto, atualizaProduto);
            }

        }
        private static void ListarProdutos()
        {
            Console.WriteLine(" Produtos Cadastrados");
            Console.WriteLine();

            var lista = estoque.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine(" VOCÊ AINDA NÃO CADASTROU NENHUM PRODUTO");

            }

            foreach (var produto in lista)
            {
                var excluido = produto.RetornaProdutoExcluido();

                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine($"{ (excluido ? " PRODUTO EXCLUÍDO - " : "")} ID: {produto.RetornaIdProduto()} | PRODUTO: { produto.RetornaNomeProtuto()} | DESCRIÇÃO: {produto.RetornaDescricaoProtuto()} | {produto.RetornaProdutoVegano()} |");

            }

        }
        private static void InserirProdutos()
        {
            Console.WriteLine(" Inserir novo Produto");
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(CategoriaProduto)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(CategoriaProduto), i)}");
            }
            Console.WriteLine();
            Console.Write(" Digite a Categoria do seu Produto entre as opções acima: ");

            int entradaCategoriaProdutos = int.Parse(Console.ReadLine());

            Console.Write(" Digite o nome do seu Produto: ");
            string entradaNomeProduto = Console.ReadLine();

            Console.Write(" Digite a Descrição do seu Produto: ");
            string entradaDescricaoProduto = Console.ReadLine();

            Console.WriteLine(" O seu produto é Vegano?:");
            foreach (int i in Enum.GetValues(typeof(EscolhaDoVendedor)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(EscolhaDoVendedor), i)}");
            }
            string entradaVegano = (Console.ReadLine());
            if (entradaVegano == "1")
                entradaVegano = "true";
            else
                entradaVegano = "false";
            Convert.ToBoolean(entradaVegano);


            Produto novoProduto = new Produto(idProduto: estoque.ProximoId(),
                                        categoria: (CategoriaProduto)entradaCategoriaProdutos,
                                        nomeProduto: entradaNomeProduto,
                                        descricaoProduto: entradaDescricaoProduto,
                                        produtoVegano: Convert.ToBoolean(entradaVegano));

            estoque.Insere(novoProduto);
            Console.Clear();
        }
        private static string ObterOpcaoLoja()
        {
            Console.WriteLine();
            Console.WriteLine(@"    __     _______ ____ ____  _   _  ___  ____");
            Console.WriteLine(@"    \ \   / / ____/ ___/ ___|| | | |/ _ \|  _ \ ");
            Console.WriteLine(@"     \ \ / /|  _|| |  _\___ \| |_| | | | | |_) | ");
            Console.WriteLine(@"      \ V / | |__| |_| |___) |  _  | |_| |  __/ ");
            Console.WriteLine(@"       \_/  |_____\____|____/|_| |_|\___/|_|   ");
            Console.WriteLine();
            Console.WriteLine(" O que você deseja fazer? Escolha uma das Opções:");
            Console.WriteLine();
            Console.WriteLine(" 1 - Listar Produtos");
            Console.WriteLine(" 2 - Inserir novo Produto");
            Console.WriteLine(" 3 - Atualizar Produto");
            Console.WriteLine(" 4 - Excluir Produto");
            Console.WriteLine(" 5 - Consultar Produto");
            Console.WriteLine(" X - Sair");
            Console.WriteLine();

            string opcaoLoja = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoLoja;



        }
    }
}

