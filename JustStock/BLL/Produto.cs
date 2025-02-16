using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace JustStock.BLL
{
    internal class Produto
    {
        private int id_produto;
        private string nome;
        private string codigo_barras;
        private string categoria;
        private string descricao;
        private float preco_compra;
        private float preco_venda;
        private string unidade_medida;
        private int quantidade;
        private int fk_fornecedor; // fk

        public int Id_produto { get => id_produto; set => id_produto = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Codigo_barras { get => codigo_barras; set => codigo_barras = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public float Preco_compra { get => preco_compra; set => preco_compra = value; }
        public float Preco_venda { get => preco_venda; set => preco_venda = value; }
        public string Unidade_medida { get => unidade_medida; set => unidade_medida = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public int Fk_fornecedor { get => fk_fornecedor; set => fk_fornecedor = value; }
    }
}
