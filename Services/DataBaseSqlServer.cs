using System.Data;
using System.Data.SqlClient;

namespace LojaVirtual.Services
{
    //Classe para gerenciar a conexão com o BD
    //Importar bibliotecas
    //using System.Data;
    //using System.Data.SqlClient;
    public class DataBaseSqlServer
    {
        //Método privado que cria nova conexão com o banco
        private SqlConnection GetConnection()
        {
            //Variável que irá armazenar a conexão
            SqlConnection connection = new SqlConnection();

            //Definindo a string de conexão
            //Host (Nome/IP), nome do banco de dados e
            //autenticação do Windows
            connection.ConnectionString =
                "Data Source=.\\SQLEXPRESS;" +
                "Initial Catalog=LojaVirtual;" +
                "Integrated Security=SSPI;";

            //Método para abrir a conexão
            connection.Open();
            //Retornando a conexão aberta
            return connection;
        }

        //Método público que executa comandos
        //INSERT, UPDATE e DELETE
        //Retorna a quantidade de linhas afetada
        public int ExecuteSQL(SqlCommand command)
        {
            command.Connection = GetConnection();
            int retorno = command.ExecuteNonQuery();
            //Fecho a conexão para não deixar conexões abertas
            command.Connection.Close();
            return retorno;
        }

        //Método público que executa comando SELECT no banco de dados
        //Retorna apenas a primeira coluna da primeira linha do banco
        //Utilizamos o tipo de dados object pois não sabemos o tipo
        //de dados que será retornado
        public object ExecuteScalar(SqlCommand command)
        {
            command.Connection = GetConnection();
            object retorno = command.ExecuteScalar();
            command.Connection.Close();
            return retorno;
        }

        //Método público que executa comando SQL
        //Retorna todas as linhas e colunas da consulta
        public DataTable GetDataTable(SqlCommand command)
        {
            // Criando o objeto DataTable
            DataTable dataTable = new DataTable();

            // Definindo a conexão do comando SQL
            command.Connection = GetConnection();
            // Criando o objeto SqlDataAdapter e vinculando o comando
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);

            // Preenchendo o DataTable com os dados do banco
            sqlDataAdapter.Fill(dataTable);
            command.Connection.Close();

            // Retornando o DataTable preenchido
            return dataTable;
        }
    }
}
