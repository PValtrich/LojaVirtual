using System;
using System.Collections.Generic;

namespace LojaVirtual.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string NomeCategoria { get; set; }
        public string Descricao { get; set; }
        public string Departamento { get; set; }
        public string Localizacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Responsavel { get; set; }
        public int Ordem { get; set; }
    }

    public class CategoriaCollection : List<Categoria> { }
}
