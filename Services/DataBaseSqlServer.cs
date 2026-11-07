using System.Configuration;
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

            //Definindo a string de conexão, guardada no App.config
            //(seção connectionStrings), para trocar o servidor sem recompilar
            connection.ConnectionString =
                ConfigurationManager.ConnectionStrings["LojaVirtual"].ConnectionString;

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
            //O using fecha a conexão mesmo que o comando lance uma exceção
            using (SqlConnection connection = GetConnection())
            {
                command.Connection = connection;
                return command.ExecuteNonQuery();
            }
        }

        //Método público que executa comando SELECT no banco de dados
        //Retorna apenas a primeira coluna da primeira linha do banco
        //Utilizamos o tipo de dados object pois não sabemos o tipo
        //de dados que será retornado
        public object ExecuteScalar(SqlCommand command)
        {
            //O using fecha a conexão mesmo que o comando lance uma exceção
            using (SqlConnection connection = GetConnection())
            {
                command.Connection = connection;
                return command.ExecuteScalar();
            }
        }

        //Método público que executa comando SQL
        //Retorna todas as linhas e colunas da consulta
        public DataTable GetDataTable(SqlCommand command)
        {
            // Criando o objeto DataTable
            DataTable dataTable = new DataTable();

            // O using fecha a conexão mesmo que a consulta lance uma exceção
            using (SqlConnection connection = GetConnection())
            {
                // Definindo a conexão do comando SQL
                command.Connection = connection;
                // Criando o objeto SqlDataAdapter e vinculando o comando
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);

                // Preenchendo o DataTable com os dados do banco
                sqlDataAdapter.Fill(dataTable);
            }

            // Retornando o DataTable preenchido
            return dataTable;
        }
    }
}
