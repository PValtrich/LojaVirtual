using LojaVirtual.Models;
using LojaVirtual.Services;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LojaVirtual.Controllers
{
    //Classe com as regras de negócio e o CRUD de Categorias
    public class CategoriaController
    {
        //Variável que faz o acesso ao banco de dados
        DataBaseSqlServer dataBase = new DataBaseSqlServer();

        public int Inserir(Categoria categoria)
        {
            string query =
                "INSERT INTO Categorias " +
                "(NomeCategoria, Descricao, Departamento, Localizacao, DataCadastro, Responsavel, Ordem) " +
                "VALUES " +
                "(@NomeCategoria, @Descricao, @Departamento, @Localizacao, @DataCadastro, @Responsavel, @Ordem)";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@NomeCategoria", categoria.NomeCategoria);
            command.Parameters.AddWithValue("@Descricao", categoria.Descricao);
            command.Parameters.AddWithValue("@Departamento", categoria.Departamento);
            command.Parameters.AddWithValue("@Localizacao", categoria.Localizacao);
            command.Parameters.AddWithValue("@DataCadastro", categoria.DataCadastro);
            command.Parameters.AddWithValue("@Responsavel", categoria.Responsavel);
            command.Parameters.AddWithValue("@Ordem", categoria.Ordem);
            return dataBase.ExecuteSQL(command);
        }

        public int Alterar(Categoria categoria)
        {
            string query =
                "UPDATE Categorias SET " +
                "NomeCategoria = @NomeCategoria, " +
                "Descricao = @Descricao, " +
                "Departamento = @Departamento, " +
                "Localizacao = @Localizacao, " +
                "DataCadastro = @DataCadastro, " +
                "Responsavel = @Responsavel, " +
                "Ordem = @Ordem " +
                "WHERE IdCategoria = @CategoriaId";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@NomeCategoria", categoria.NomeCategoria);
            command.Parameters.AddWithValue("@Descricao", categoria.Descricao);
            command.Parameters.AddWithValue("@Departamento", categoria.Departamento);
            command.Parameters.AddWithValue("@Localizacao", categoria.Localizacao);
            command.Parameters.AddWithValue("@DataCadastro", categoria.DataCadastro);
            command.Parameters.AddWithValue("@Responsavel", categoria.Responsavel);
            command.Parameters.AddWithValue("@Ordem", categoria.Ordem);
            command.Parameters.AddWithValue("@CategoriaId", categoria.CategoriaId);
            return dataBase.ExecuteSQL(command);
        }

        public int Excluir(int categoriaId)
        {
            string query =
                "DELETE FROM Categorias " +
                "WHERE IdCategoria = @CategoriaId";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@CategoriaId", categoriaId);
            return dataBase.ExecuteSQL(command);
        }

        //Converte as linhas do DataTable em uma coleção de objetos
        //Todo dado precisa ser convertido do SQL Server para C#
        private CategoriaCollection ConverterTabela(DataTable dataTable)
        {
            CategoriaCollection categorias = new CategoriaCollection();

            foreach (DataRow row in dataTable.Rows)
            {
                Categoria categoria = new Categoria();
                categoria.CategoriaId = Convert.ToInt32(row["IdCategoria"]);
                categoria.NomeCategoria = Convert.ToString(row["NomeCategoria"]);
                categoria.Descricao = Convert.ToString(row["Descricao"]);
                categoria.Departamento = Convert.ToString(row["Departamento"]);
                categoria.Localizacao = Convert.ToString(row["Localizacao"]);
                categoria.DataCadastro = Convert.ToDateTime(row["DataCadastro"]);
                categoria.Responsavel = Convert.ToString(row["Responsavel"]);
                categoria.Ordem = Convert.ToInt32(row["Ordem"]);
                categorias.Add(categoria);
            }
            return categorias;
        }

        public Categoria GetById(int categoriaId)
        {
            string query =
                "SELECT * " +
                "FROM Categorias " +
                "WHERE IdCategoria = @CategoriaId";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@CategoriaId", categoriaId);
            DataTable dataTable = dataBase.GetDataTable(command);

            CategoriaCollection lista = ConverterTabela(dataTable);
            if (lista.Count > 0)
                return lista[0];
            else
                return null;
        }

        public CategoriaCollection GetAll()
        {
            string query =
                "SELECT * " +
                "FROM Categorias " +
                "ORDER BY NomeCategoria";

            SqlCommand command = new SqlCommand(query);
            DataTable dataTable = dataBase.GetDataTable(command);

            return ConverterTabela(dataTable);
        }

        //Consulta com filtro. Passando o valor vazio, retorna todos os registros
        public CategoriaCollection GetByNome(string value)
        {
            string query =
                "SELECT * " +
                "FROM Categorias " +
                "WHERE NomeCategoria LIKE @Valor " +
                "ORDER BY NomeCategoria";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Valor", "%" + value + "%");
            DataTable dataTable = dataBase.GetDataTable(command);

            return ConverterTabela(dataTable);
        }
    }
}
