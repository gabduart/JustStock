using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStock.BLL
{
    internal class Movimentacao
    {
        private int id_movimentacao;
        private int id_produto; // fk
        private int tipo;
        private int quantidade;
        private DateTime data_hora;
        private int id_usuario; // fk

        public int Id_movimentacao { get => id_movimentacao; set => id_movimentacao = value; }
        public int Id_produto { get => id_produto; set => id_produto = value; }
        public int Tipo { get => tipo; set => tipo = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }
        public DateTime Data_hora { get => data_hora; set => data_hora = value; }
        public int Id_usuario { get => id_usuario; set => id_usuario = value; }
    }
}
