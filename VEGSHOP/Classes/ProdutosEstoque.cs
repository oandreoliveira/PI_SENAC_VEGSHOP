using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGSHOP
{
    class ProdutosEstoque : IEstoque<Produtos>
    {
        public List<Produtos> ListaProduto = new List<Produtos>();
        public void Atualiza(int id, Produtos entidade)
        {
            ListaProduto[id] = entidade;
        }

        public void Exclui(int id)
        {
            ListaProduto[id].Excluir();
            //ListaProduto.RemoveAt(id);
        }

        public void Insere(Produtos entidade)
        {
            ListaProduto.Add(entidade);
        }

        public List<Produtos> Lista()
        {
            return ListaProduto;
        }

        public int ProximoId()
        {
            return ListaProduto.Count;
        }

        public Produtos RetornaPorId(int id)
        {
            return ListaProduto[id];
        }

    }
}
