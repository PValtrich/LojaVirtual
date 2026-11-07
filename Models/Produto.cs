using System;
using System.Collections.Generic;

namespace LojaVirtual.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string Marca { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Peso { get; set; }

        //Propriedades somente leitura, usadas para exibir
        //os dados já tratados na grade
        public string CategoriaNome
        {
            get
            {
                return Categoria.NomeCategoria;
            }
        }

        public string PrecoTratado
        {
            get
            {
                return Preco.ToString("C");
            }
        }
    }

    public class ProdutoCollection : List<Produto> { }
}
