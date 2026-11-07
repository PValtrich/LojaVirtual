using LojaVirtual.Models;
using LojaVirtual.Services;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LojaVirtual.Controllers
{
    //Classe com as regras de negócio e o CRUD de Usuários
    public class UsuarioController
    {
        //Variável que faz o acesso ao banco de dados
        DataBaseSqlServer dataBase = new DataBaseSqlServer();

        public int Inserir(Usuario usuario)
        {
            string query =
                "INSERT INTO Usuarios " +
                "(Nome, CPF, Email, Senha, Perfil, Telefone, DataCadastro) " +
                "VALUES " +
                "(@Nome, @Cpf, @Email, @Senha, @Perfil, @Telefone, @DataCadastro)";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Nome", usuario.Nome);
            command.Parameters.AddWithValue("@Cpf", usuario.Cpf);
            command.Parameters.AddWithValue("@Email", usuario.Email);
            command.Parameters.AddWithValue("@Senha", usuario.Senha);
            command.Parameters.AddWithValue("@Perfil", usuario.Perfil);
            command.Parameters.AddWithValue("@Telefone", usuario.Telefone);
            command.Parameters.AddWithValue("@DataCadastro", usuario.DataCadastro);
            return dataBase.ExecuteSQL(command);
        }

        public int Alterar(Usuario usuario)
        {
            string query =
                "UPDATE Usuarios SET " +
                "Nome = @Nome, " +
                "CPF = @Cpf, " +
                "Email = @Email, " +
                "Senha = @Senha, " +
                "Perfil = @Perfil, " +
                "Telefone = @Telefone, " +
                "DataCadastro = @DataCadastro " +
                "WHERE IdUsuario = @UsuarioId";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Nome", usuario.Nome);
            command.Parameters.AddWithValue("@Cpf", usuario.Cpf);
            command.Parameters.AddWithValue("@Email", usuario.Email);
            command.Parameters.AddWithValue("@Senha", usuario.Senha);
            command.Parameters.AddWithValue("@Perfil", usuario.Perfil);
            command.Parameters.AddWithValue("@Telefone", usuario.Telefone);
            command.Parameters.AddWithValue("@DataCadastro", usuario.DataCadastro);
            command.Parameters.AddWithValue("@UsuarioId", usuario.UsuarioId);
            return dataBase.ExecuteSQL(command);
        }

        public int Excluir(int usuarioId)
        {
            string query =
                "DELETE FROM Usuarios " +
                "WHERE IdUsuario = @UsuarioId";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@UsuarioId", usuarioId);
            return dataBase.ExecuteSQL(command);
        }

        //Converte as linhas do DataTable em uma coleção de objetos
        //Todo dado precisa ser convertido do SQL Server para C#
        private UsuarioCollection ConverterTabela(DataTable dataTable)
        {
            UsuarioCollection usuarios = new UsuarioCollection();

            foreach (DataRow row in dataTable.Rows)
            {
                Usuario usuario = new Usuario();
                usuario.UsuarioId = Convert.ToInt32(row["IdUsuario"]);
                usuario.Nome = Convert.ToString(row["Nome"]);
                usuario.Cpf = Convert.ToString(row["CPF"]);
                usuario.Email = Convert.ToString(row["Email"]);
                usuario.Senha = Convert.ToString(row["Senha"]);
                usuario.Perfil = Convert.ToString(row["Perfil"]);
                usuario.Telefone = Convert.ToString(row["Telefone"]);
                usuario.DataCadastro = Convert.ToDateTime(row["DataCadastro"]);
                usuarios.Add(usuario);
            }
            return usuarios;
        }

        public Usuario GetById(int usuarioId)
        {
            string query =
                "SELECT * " +
                "FROM Usuarios " +
                "WHERE IdUsuario = @UsuarioId";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@UsuarioId", usuarioId);
            DataTable dataTable = dataBase.GetDataTable(command);

            UsuarioCollection lista = ConverterTabela(dataTable);
            if (lista.Count > 0)
                return lista[0];
            else
                return null;
        }

        public UsuarioCollection GetAll()
        {
            string query =
                "SELECT * " +
                "FROM Usuarios " +
                "ORDER BY Nome";

            SqlCommand command = new SqlCommand(query);
            DataTable dataTable = dataBase.GetDataTable(command);

            return ConverterTabela(dataTable);
        }

        //Consulta com filtro. Passando o valor vazio, retorna todos os registros
        public UsuarioCollection GetByNome(string value)
        {
            string query =
                "SELECT * " +
                "FROM Usuarios " +
                "WHERE Nome LIKE @Valor " +
                "ORDER BY Nome";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Valor", "%" + value + "%");
            DataTable dataTable = dataBase.GetDataTable(command);

            return ConverterTabela(dataTable);
        }
    }
}
