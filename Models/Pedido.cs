using System;
using System.Collections.Generic;

namespace LojaVirtual.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal ValorTotal { get; set; }
        public string FormaPagamento { get; set; }
        public string EnderecoEntrega { get; set; }
        public string CidadeEntrega { get; set; }

        //Propriedades somente leitura, usadas para exibir
        //os dados já tratados na grade
        public string ClienteNome
        {
            get
            {
                return Cliente.Nome;
            }
        }

        public string UsuarioNome
        {
            get
            {
                return Usuario.Nome;
            }
        }

        public string DataPedidoTratada
        {
            get
            {
                return DataPedido.ToString("dd/MM/yyyy");
            }
        }

        public string ValorTotalTratado
        {
            get
            {
                return ValorTotal.ToString("C");
            }
        }
    }

    public class PedidoCollection : List<Pedido> { }
}
