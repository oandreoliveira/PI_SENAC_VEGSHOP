using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VEGSHOP
{
    class ProdutoRepositorio : IRepositorio<Produto>
    {
        public List<Produto> ListaProduto = new List<Produto>();
        public void Atualiza(int id, Produto entidade)
        {
            ListaProduto[id] = entidade;
        }

        public void Exclui(int id)
        {
            ListaProduto[id].Excluir();
            
        }

        public void Insere(Produto entidade)
        {
            ListaProduto.Add(entidade);
        }

        public List<Produto> Lista()
        {
            return ListaProduto;
        }

        public int ProximoId()
        {
            return ListaProduto.Count;
        }

        public Produto RetornaPorId(int id)
        {
            return ListaProduto[id];
        }

    }
}
