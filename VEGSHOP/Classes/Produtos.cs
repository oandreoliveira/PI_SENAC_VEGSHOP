using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGSHOP
{
    class Produtos
    {

        private int IdProduto { get; set; }
        private CategoriaProdutos Categoria { get; set; }
        private string NomeProduto { get; set; }
        private string DescricaoProduto { get; set; }
        private bool ProdutoVegano { get; set; }
        private bool ProdutoExcluido { get; set; }


        public Produtos(int idProduto, CategoriaProdutos categoria, string nomeProduto, string descricaoProduto, bool produtoVegano)
        {
            IdProduto = idProduto;
            Categoria = categoria;
            NomeProduto = nomeProduto;
            DescricaoProduto = descricaoProduto;
            ProdutoVegano = produtoVegano;
            ProdutoExcluido = false;
        }
        public string TransformarSimOuNao(bool texto)
        {
            return texto ? "Este Produto é Vegano" : "Este Produto NÃO é Vegano";
        }

        public override string ToString()
        {
            return $"ID: {IdProduto} | PRODUTO: {NomeProduto} | DESCRIÇÃO: {DescricaoProduto} | {TransformarSimOuNao(ProdutoVegano)} ";
        }
        public string RetornaNomeProtuto()
        {
            return NomeProduto;
        }
        public string RetornaDescricaoProtuto()
        {
            return DescricaoProduto;
        }

        public int RetornaIdProduto()
        {
            return IdProduto;
        }
        public bool RetornaProdutoExcluido()
        {
            return ProdutoExcluido;
        }
        public void Excluir()
        {
            ProdutoExcluido = true;
        }
        public string RetornaProdutoVegano()
        {

            return TransformarSimOuNao(ProdutoVegano);

        }
    }

}
