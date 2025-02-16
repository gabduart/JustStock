using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStock.BLL
{
    internal class Alerta
    {
        private int id_alerta;
        private int id_produto; // fk
        private int tipo_alerta;
        private DateTime data_criacao;

        public int Id_alerta { get => id_alerta; set => id_alerta = value; }
        public int Id_produto { get => id_produto; set => id_produto = value; }
        public int Tipo_alerta { get => tipo_alerta; set => tipo_alerta = value; }
        public DateTime Data_criacao { get => data_criacao; set => data_criacao = value; }
    }
}
