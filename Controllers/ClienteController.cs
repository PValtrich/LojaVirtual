using LojaVirtual.Models;
using LojaVirtual.Services;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LojaVirtual.Controllers
{
    //Classe com as regras de negócio e o CRUD de Clientes
    public class ClienteController
    {
        //Variável que faz o acesso ao banco de dados
        DataBaseSqlServer dataBase = new DataBaseSqlServer();

        public int Inserir(Cliente cliente)
        {
            string query =
                "INSERT INTO Clientes " +
                "(Nome, CPF, Email, Telefone, Endereco, Cidade, DataCadastro) " +
                "VALUES " +
                "(@Nome, @Cpf, @Email, @Telefone, @Endereco, @Cidade, @DataCadastro)";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Nome", cliente.Nome);
            command.Parameters.AddWithValue("@Cpf", cliente.Cpf);
            command.Parameters.AddWithValue("@Email", cliente.Email);
            command.Parameters.AddWithValue("@Telefone", cliente.Telefone);
            command.Parameters.AddWithValue("@Endereco", cliente.Endereco);
            command.Parameters.AddWithValue("@Cidade", cliente.Cidade);
            command.Parameters.AddWithValue("@DataCadastro", cliente.DataCadastro);
            return dataBase.ExecuteSQL(command);
        }

        public int Alterar(Cliente cliente)
        {
            string query =
                "UPDATE Clientes SET " +
                "Nome = @Nome, " +
                "CPF = @Cpf, " +
                "Email = @Email, " +
                "Telefone = @Telefone, " +
                "Endereco = @Endereco, " +
                "Cidade = @Cidade, " +
                "DataCadastro = @DataCadastro " +
                "WHERE IdCliente = @ClienteId";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Nome", cliente.Nome);
            command.Parameters.AddWithValue("@Cpf", cliente.Cpf);
            command.Parameters.AddWithValue("@Email", cliente.Email);
            command.Parameters.AddWithValue("@Telefone", cliente.Telefone);
            command.Parameters.AddWithValue("@Endereco", cliente.Endereco);
            command.Parameters.AddWithValue("@Cidade", cliente.Cidade);
            command.Parameters.AddWithValue("@DataCadastro", cliente.DataCadastro);
            command.Parameters.AddWithValue("@ClienteId", cliente.ClienteId);
            return dataBase.ExecuteSQL(command);
        }

        public int Excluir(int clienteId)
        {
            string query =
                "DELETE FROM Clientes " +
                "WHERE IdCliente = @ClienteId";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ClienteId", clienteId);
            return dataBase.ExecuteSQL(command);
        }

        //Converte as linhas do DataTable em uma coleção de objetos
        //Todo dado precisa ser convertido do SQL Server para C#
        private ClienteCollection ConverterTabela(DataTable dataTable)
        {
            ClienteCollection clientes = new ClienteCollection();

            foreach (DataRow row in dataTable.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.ClienteId = Convert.ToInt32(row["IdCliente"]);
                cliente.Nome = Convert.ToString(row["Nome"]);
                cliente.Cpf = Convert.ToString(row["CPF"]);
                cliente.Email = Convert.ToString(row["Email"]);
                cliente.Telefone = Convert.ToString(row["Telefone"]);
                cliente.Endereco = Convert.ToString(row["Endereco"]);
                cliente.Cidade = Convert.ToString(row["Cidade"]);
                cliente.DataCadastro = Convert.ToDateTime(row["DataCadastro"]);
                clientes.Add(cliente);
            }
            return clientes;
        }

        public Cliente GetById(int clienteId)
        {
            string query =
                "SELECT * " +
                "FROM Clientes " +
                "WHERE IdCliente = @ClienteId";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ClienteId", clienteId);
            DataTable dataTable = dataBase.GetDataTable(command);

            ClienteCollection lista = ConverterTabela(dataTable);
            if (lista.Count > 0)
                return lista[0];
            else
                return null;
        }

        public ClienteCollection GetAll()
        {
            string query =
                "SELECT * " +
                "FROM Clientes " +
                "ORDER BY Nome";

            SqlCommand command = new SqlCommand(query);
            DataTable dataTable = dataBase.GetDataTable(command);

            return ConverterTabela(dataTable);
        }

        //Consulta com filtro. Passando o valor vazio, retorna todos os registros
        public ClienteCollection GetByNome(string value)
        {
            string query =
                "SELECT * " +
                "FROM Clientes " +
                "WHERE Nome LIKE @Valor " +
                "ORDER BY Nome";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Valor", "%" + value + "%");
            DataTable dataTable = dataBase.GetDataTable(command);

            return ConverterTabela(dataTable);
        }
    }
}
