using System.Collections.Generic;

namespace LojaVirtual.Models
{
    public class PedidoItem
    {
        public int PedidoItemId { get; set; }
        public int PedidoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        public decimal Subtotal
        {
            get
            {
                return Quantidade * PrecoUnitario;
            }
        }

        //Propriedades somente leitura, usadas para exibir
        //os dados já tratados na grade
        public string ProdutoNome
        {
            get
            {
                return Produto.NomeProduto;
            }
        }

        public string PrecoUnitarioTratado
        {
            get
            {
                return PrecoUnitario.ToString("C");
            }
        }

        public string SubtotalTratado
        {
            get
            {
                return Subtotal.ToString("C");
            }
        }
    }

    public class PedidoItemCollection : List<PedidoItem>
    {
        //Soma o subtotal de todos os itens e retorna o valor total do pedido
        public decimal ValorTotal()
        {
            decimal total = 0;
            foreach (PedidoItem item in this)
                total += item.Subtotal;
            return total;
        }
    }
}
