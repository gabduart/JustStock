using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace JustStock.BLL
{
    internal class Fornecedor
    {
        private int id_fornecedor;
        private string nome;
        private string cnpj_cpf;
        private string contato;
        private string endereco;

        public int Id_fornecedor { get => id_fornecedor; set => id_fornecedor = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cnpj_cpf { get => cnpj_cpf; set => cnpj_cpf = value; }
        public string Contato { get => contato; set => contato = value; }
        public string Endereco { get => endereco; set => endereco = value; }
    }
}
