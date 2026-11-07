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

        //Retorna o ID do pedido gravado
        public int Inserir(Pedido pedido)
        {
            //O valor total é a soma dos itens, então não depende do que foi digitado
            pedido.ValorTotal = pedido.Itens.ValorTotal();

            string query =
                "INSERT INTO Pedidos " +
                "(IdCliente, IdUsuario, DataPedido, ValorTotal, FormaPagamento, EnderecoEntrega, CidadeEntrega) " +
                "VALUES " +
                "(@Cliente, @Usuario, @DataPedido, @ValorTotal, @FormaPagamento, @EnderecoEntrega, @CidadeEntrega);" +
                "SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Cliente", pedido.Cliente.ClienteId);
            command.Parameters.AddWithValue("@Usuario", pedido.Usuario.UsuarioId);
            command.Parameters.AddWithValue("@DataPedido", pedido.DataPedido);
            command.Parameters.AddWithValue("@ValorTotal", pedido.ValorTotal);
            command.Parameters.AddWithValue("@FormaPagamento", pedido.FormaPagamento);
            command.Parameters.AddWithValue("@EnderecoEntrega", pedido.EnderecoEntrega);
            command.Parameters.AddWithValue("@CidadeEntrega", pedido.CidadeEntrega);

            //O ID do pedido recém-criado é necessário para gravar os itens
            int pedidoId = Convert.ToInt32(dataBase.ExecuteScalar(command));
            pedido.PedidoId = pedidoId;

            try
            {
                SalvarItens(pedido);
            }
            catch
            {
                //Se algum item não for gravado, apagamos o pedido para não sobrar pedido sem itens
                Excluir(pedidoId);
                throw;
            }

            return pedidoId;
        }

        public int Alterar(Pedido pedido)
        {
            pedido.ValorTotal = pedido.Itens.ValorTotal();

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

            int retorno = dataBase.ExecuteSQL(command);
            if (retorno > 0)
                SalvarItens(pedido);
            return retorno;
        }

        //Regrava os itens do pedido: apaga os antigos e grava os atuais
        private void SalvarItens(Pedido pedido)
        {
            PedidoItemController pedidoItemController = new PedidoItemController();
            pedidoItemController.ExcluirPorPedido(pedido.PedidoId);

            foreach (PedidoItem item in pedido.Itens)
            {
                item.PedidoId = pedido.PedidoId;
                pedidoItemController.Inserir(item);
            }
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
