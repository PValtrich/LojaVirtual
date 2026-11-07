using System;
using System.Collections.Generic;

namespace LojaVirtual.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
    }

    public class UsuarioCollection : List<Usuario> { }
}
