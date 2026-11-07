using LojaVirtual.Models;
using LojaVirtual.Services;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LojaVirtual.Controllers
{
    //Classe com as regras de negócio e o CRUD dos Itens do Pedido
    public class PedidoItemController
    {
        //Variável que faz o acesso ao banco de dados
        DataBaseSqlServer dataBase = new DataBaseSqlServer();

        public int Inserir(PedidoItem pedidoItem)
        {
            string query =
                "INSERT INTO ItensPedido " +
                "(IdPedido, IdProduto, Quantidade, PrecoUnitario) " +
                "VALUES " +
                "(@PedidoId, @ProdutoId, @Quantidade, @PrecoUnitario)";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@PedidoId", pedidoItem.PedidoId);
            command.Parameters.AddWithValue("@ProdutoId", pedidoItem.Produto.ProdutoId);
            command.Parameters.AddWithValue("@Quantidade", pedidoItem.Quantidade);
            command.Parameters.AddWithValue("@PrecoUnitario", pedidoItem.PrecoUnitario);
            return dataBase.ExecuteSQL(command);
        }

        //Apaga todos os itens de um pedido (usado antes de regravar os itens na alteração)
        public int ExcluirPorPedido(int pedidoId)
        {
            string query =
                "DELETE FROM ItensPedido " +
                "WHERE IdPedido = @PedidoId";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@PedidoId", pedidoId);
            return dataBase.ExecuteSQL(command);
        }

        //Converte as linhas do DataTable em uma coleção de objetos
        private PedidoItemCollection ConverterTabela(DataTable dataTable)
        {
            PedidoItemCollection itens = new PedidoItemCollection();
            ProdutoController produtoController = new ProdutoController();

            foreach (DataRow row in dataTable.Rows)
            {
                PedidoItem item = new PedidoItem();
                item.PedidoItemId = Convert.ToInt32(row["IdItemPedido"]);
                item.PedidoId = Convert.ToInt32(row["IdPedido"]);
                item.Produto = produtoController.GetById(Convert.ToInt32(row["IdProduto"]));
                item.Quantidade = Convert.ToInt32(row["Quantidade"]);
                item.PrecoUnitario = Convert.ToDecimal(row["PrecoUnitario"]);
                itens.Add(item);
            }
            return itens;
        }

        public PedidoItemCollection GetByPedido(int pedidoId)
        {
            string query =
                "SELECT * " +
                "FROM ItensPedido " +
                "WHERE IdPedido = @PedidoId " +
                "ORDER BY IdItemPedido";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@PedidoId", pedidoId);
            DataTable dataTable = dataBase.GetDataTable(command);

            return ConverterTabela(dataTable);
        }
    }
}
