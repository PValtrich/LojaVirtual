using LojaVirtual.Models;
using LojaVirtual.Services;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LojaVirtual.Controllers
{
    //Classe com as regras de negócio e o CRUD de Pedidos
    public class PedidoController
    {
        //Variável que faz o acesso ao banco de dados
        DataBaseSqlServer dataBase = new DataBaseSqlServer();

        public int Inserir(Pedido pedido)
        {
            string query =
                "INSERT INTO Pedidos " +
                "(IdCliente, IdUsuario, DataPedido, ValorTotal, FormaPagamento, EnderecoEntrega, CidadeEntrega) " +
                "VALUES " +
                "(@Cliente, @Usuario, @DataPedido, @ValorTotal, @FormaPagamento, @EnderecoEntrega, @CidadeEntrega)";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Cliente", pedido.Cliente.ClienteId);
            command.Parameters.AddWithValue("@Usuario", pedido.Usuario.UsuarioId);
            command.Parameters.AddWithValue("@DataPedido", pedido.DataPedido);
            command.Parameters.AddWithValue("@ValorTotal", pedido.ValorTotal);
            command.Parameters.AddWithValue("@FormaPagamento", pedido.FormaPagamento);
            command.Parameters.AddWithValue("@EnderecoEntrega", pedido.EnderecoEntrega);
            command.Parameters.AddWithValue("@CidadeEntrega", pedido.CidadeEntrega);
            return dataBase.ExecuteSQL(command);
        }

        public int Alterar(Pedido pedido)
        {
            string query =
                "UPDATE Pedidos SET " +
                "IdCliente = @Cliente, " +
                "IdUsuario = @Usuario, " +
                "DataPedido = @DataPedido, " +
                "ValorTotal = @ValorTotal, " +
                "FormaPagamento = @FormaPagamento, " +
                "EnderecoEntrega = @EnderecoEntrega, " +
                "CidadeEntrega = @CidadeEntrega " +
                "WHERE IdPedido = @PedidoId";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Cliente", pedido.Cliente.ClienteId);
            command.Parameters.AddWithValue("@Usuario", pedido.Usuario.UsuarioId);
            command.Parameters.AddWithValue("@DataPedido", pedido.DataPedido);
            command.Parameters.AddWithValue("@ValorTotal", pedido.ValorTotal);
            command.Parameters.AddWithValue("@FormaPagamento", pedido.FormaPagamento);
            command.Parameters.AddWithValue("@EnderecoEntrega", pedido.EnderecoEntrega);
            command.Parameters.AddWithValue("@CidadeEntrega", pedido.CidadeEntrega);
            command.Parameters.AddWithValue("@PedidoId", pedido.PedidoId);
            return dataBase.ExecuteSQL(command);
        }

        public int Excluir(int pedidoId)
        {
            string query =
                "DELETE FROM Pedidos " +
                "WHERE IdPedido = @PedidoId";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@PedidoId", pedidoId);
            return dataBase.ExecuteSQL(command);
        }

        //Converte as linhas do DataTable em uma coleção de objetos
        //Todo dado precisa ser convertido do SQL Server para C#
        private PedidoCollection ConverterTabela(DataTable dataTable)
        {
            PedidoCollection pedidos = new PedidoCollection();

            foreach (DataRow row in dataTable.Rows)
            {
                Pedido pedido = new Pedido();
                pedido.PedidoId = Convert.ToInt32(row["IdPedido"]);
                pedido.Cliente = new ClienteController().GetById(Convert.ToInt32(row["IdCliente"]));
                pedido.Usuario = new UsuarioController().GetById(Convert.ToInt32(row["IdUsuario"]));
                pedido.DataPedido = Convert.ToDateTime(row["DataPedido"]);
                pedido.ValorTotal = Convert.ToDecimal(row["ValorTotal"]);
                pedido.FormaPagamento = Convert.ToString(row["FormaPagamento"]);
                pedido.EnderecoEntrega = Convert.ToString(row["EnderecoEntrega"]);
                pedido.CidadeEntrega = Convert.ToString(row["CidadeEntrega"]);
                pedidos.Add(pedido);
            }
            return pedidos;
        }

        public Pedido GetById(int pedidoId)
        {
            string query =
                "SELECT * " +
                "FROM Pedidos " +
                "WHERE IdPedido = @PedidoId";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@PedidoId", pedidoId);
            DataTable dataTable = dataBase.GetDataTable(command);

            PedidoCollection lista = ConverterTabela(dataTable);
            if (lista.Count > 0)
                return lista[0];
            else
                return null;
        }

        public PedidoCollection GetAll()
        {
            string query =
                "SELECT * " +
                "FROM Pedidos " +
                "ORDER BY DataPedido";

            SqlCommand command = new SqlCommand(query);
            DataTable dataTable = dataBase.GetDataTable(command);

            return ConverterTabela(dataTable);
        }

        public PedidoCollection GetByFormaPagamento(string value)
        {
            string query =
                "SELECT * " +
                "FROM Pedidos " +
                "WHERE FormaPagamento = @Valor " +
                "ORDER BY DataPedido";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Valor", value);
            DataTable dataTable = dataBase.GetDataTable(command);

            return ConverterTabela(dataTable);
        }
    }
}
