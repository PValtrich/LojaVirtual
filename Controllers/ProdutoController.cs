using LojaVirtual.Models;
using LojaVirtual.Services;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LojaVirtual.Controllers
{
    //Classe com as regras de negócio e o CRUD de Produtos
    public class ProdutoController
    {
        //Variável que faz o acesso ao banco de dados
        DataBaseSqlServer dataBase = new DataBaseSqlServer();

        public int Inserir(Produto produto)
        {
            string query =
                "INSERT INTO Produtos " +
                "(NomeProduto, Descricao, Preco, Estoque, Marca, IdCategoria, Peso) " +
                "VALUES " +
                "(@NomeProduto, @Descricao, @Preco, @Estoque, @Marca, @Categoria, @Peso)";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
            command.Parameters.AddWithValue("@Descricao", produto.Descricao);
            command.Parameters.AddWithValue("@Preco", produto.Preco);
            command.Parameters.AddWithValue("@Estoque", produto.Estoque);
            command.Parameters.AddWithValue("@Marca", produto.Marca);
            command.Parameters.AddWithValue("@Categoria", produto.Categoria.CategoriaId);
            command.Parameters.AddWithValue("@Peso", produto.Peso);
            return dataBase.ExecuteSQL(command);
        }

        public int Alterar(Produto produto)
        {
            string query =
                "UPDATE Produtos SET " +
                "NomeProduto = @NomeProduto, " +
                "Descricao = @Descricao, " +
                "Preco = @Preco, " +
                "Estoque = @Estoque, " +
                "Marca = @Marca, " +
                "IdCategoria = @Categoria, " +
                "Peso = @Peso " +
                "WHERE IdProduto = @ProdutoId";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
            command.Parameters.AddWithValue("@Descricao", produto.Descricao);
            command.Parameters.AddWithValue("@Preco", produto.Preco);
            command.Parameters.AddWithValue("@Estoque", produto.Estoque);
            command.Parameters.AddWithValue("@Marca", produto.Marca);
            command.Parameters.AddWithValue("@Categoria", produto.Categoria.CategoriaId);
            command.Parameters.AddWithValue("@Peso", produto.Peso);
            command.Parameters.AddWithValue("@ProdutoId", produto.ProdutoId);
            return dataBase.ExecuteSQL(command);
        }

        public int Excluir(int produtoId)
        {
            string query =
                "DELETE FROM Produtos " +
                "WHERE IdProduto = @ProdutoId";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ProdutoId", produtoId);
            return dataBase.ExecuteSQL(command);
        }

        //Converte as linhas do DataTable em uma coleção de objetos
        //Todo dado precisa ser convertido do SQL Server para C#
        private ProdutoCollection ConverterTabela(DataTable dataTable)
        {
            ProdutoCollection produtos = new ProdutoCollection();

            foreach (DataRow row in dataTable.Rows)
            {
                Produto produto = new Produto();
                produto.ProdutoId = Convert.ToInt32(row["IdProduto"]);
                produto.NomeProduto = Convert.ToString(row["NomeProduto"]);
                produto.Descricao = Convert.ToString(row["Descricao"]);
                produto.Preco = Convert.ToDecimal(row["Preco"]);
                produto.Estoque = Convert.ToInt32(row["Estoque"]);
                produto.Marca = Convert.ToString(row["Marca"]);
                produto.Categoria = new CategoriaController().GetById(Convert.ToInt32(row["IdCategoria"]));
                string pesoTexto = Convert.ToString(row["Peso"]);
                if (pesoTexto == "")
                    produto.Peso = 0;
                else
                    produto.Peso = decimal.Parse(pesoTexto);
                produtos.Add(produto);
            }
            return produtos;
        }

        public Produto GetById(int produtoId)
        {
            string query =
                "SELECT * " +
                "FROM Produtos " +
                "WHERE IdProduto = @ProdutoId";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ProdutoId", produtoId);
            DataTable dataTable = dataBase.GetDataTable(command);

            ProdutoCollection lista = ConverterTabela(dataTable);
            if (lista.Count > 0)
                return lista[0];
            else
                return null;
        }

        public ProdutoCollection GetAll()
        {
            string query =
                "SELECT * " +
                "FROM Produtos " +
                "ORDER BY NomeProduto";

            SqlCommand command = new SqlCommand(query);
            DataTable dataTable = dataBase.GetDataTable(command);

            return ConverterTabela(dataTable);
        }

        //Consulta com filtro. Passando o valor vazio, retorna todos os registros
        public ProdutoCollection GetByNome(string value)
        {
            string query =
                "SELECT * " +
                "FROM Produtos " +
                "WHERE NomeProduto LIKE @Valor " +
                "ORDER BY NomeProduto";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@Valor", "%" + value + "%");
            DataTable dataTable = dataBase.GetDataTable(command);

            return ConverterTabela(dataTable);
        }
    }
}
