using System;

namespace VEGSHOP
{
    class Program
    {
        static ProdutosEstoque estoque = new ProdutosEstoque();
        static void Main(string[] args)
        {
            string opcaoLoja = ObterOpcaoLoja();

            while (opcaoLoja.ToUpper() != "X")
            {
                switch (opcaoLoja)
                {
                    case "1":
                        ListarProdutos();
                        break;
                    case "2":
                        InserirProdutos();
                        break;
                    case "3":
                        AtualizarProdutos();
                        break;
                    case "4":
                        ExcluirProdutos();
                        break;
                    case "5":
                        VisualizarProdutos();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoLoja = ObterOpcaoLoja();
            }

            Console.WriteLine(" Obrigado! Juntos Fazemos a Diferença!");
            Console.ReadLine();
        }
        private static void ExcluirProdutos()
        {
            Console.Write(" Digite o ID do Produto: ");
            int indiceProduto = int.Parse(Console.ReadLine());

            estoque.Exclui(indiceProduto);
        }
        private static void VisualizarProdutos()
        {
            Console.Write(" Digite o ID do Produto: ");
            int indiceProduto = int.Parse(Console.ReadLine());

            var produto = estoque.RetornaPorId(indiceProduto);
            Console.WriteLine(produto);

        }

        private static void AtualizarProdutos()
        {
            Console.Write(" Digite o ID do Produto: ");
            int indiceProduto = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(CategoriaProdutos)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(CategoriaProdutos), i));
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
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(EscolhaDoVendedor), i));
            }
            string entradaVegano = (Console.ReadLine());
            if (entradaVegano == "1")
                entradaVegano = "true";
            else
                entradaVegano = "false";
            Convert.ToBoolean(entradaVegano);

            // bool entradaVegano = bool.Parse(Console.ReadLine());

            Produtos atualizaProduto = new Produtos(idProduto: indiceProduto,
                                        categoria: (CategoriaProdutos)entradaCategoriaProdutos,
                                        nomeProduto: entradaNomeProduto,
                                        descricaoProduto: entradaDescricaoProduto,
                                        produtoVegano: Convert.ToBoolean(entradaVegano));

            estoque.Atualiza(indiceProduto, atualizaProduto);
        }
        private static void ListarProdutos()
        {
            Console.WriteLine(" Produtos Cadastrados");
            Console.WriteLine();

            var lista = estoque.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine(" Você ainda não cadastrou nenhum produto");
                return;
            }

            foreach (var produto in lista)
            {
                var excluido = produto.RetornaProdutoExcluido();

                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine(" {0}  ID: {1} | PRODUTO: {2} | DESCRIÇÃO: {3} | {4} |", (excluido ? " PRODUTO EXCLUÍDO " : ""), produto.RetornaIdProduto(), produto.RetornaNomeProtuto(), produto.RetornaDescricaoProtuto(), produto.RetornaProdutoVegano());
            }

        }
        private static void InserirProdutos()
        {
            Console.WriteLine(" Inserir novo Produto");
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(CategoriaProdutos)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(CategoriaProdutos), i));
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
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(EscolhaDoVendedor), i));
            }
            string entradaVegano = (Console.ReadLine());
            if (entradaVegano == "1")
                entradaVegano = "true";
            else
                entradaVegano = "false";
            Convert.ToBoolean(entradaVegano);


            Produtos novoProduto = new Produtos(idProduto: estoque.ProximoId(),
                                        categoria: (CategoriaProdutos)entradaCategoriaProdutos,
                                        nomeProduto: entradaNomeProduto,
                                        descricaoProduto: entradaDescricaoProduto,
                                        produtoVegano: Convert.ToBoolean(entradaVegano));

            estoque.Insere(novoProduto);
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
            Console.WriteLine(" C - Limpar Tela");
            Console.WriteLine(" X - Sair");
            Console.WriteLine();

            string opcaoLoja = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoLoja;



        }
    }
}

