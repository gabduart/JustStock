using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStock.BLL
{
    internal class Usuario
    {
        private int id_usuario;
        private string nome;
        private string email;
        private string senha;
        private int tipo_usuario;

        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }
        public int Tipo_usuario { get => tipo_usuario; set => tipo_usuario = value; }
    }
}
