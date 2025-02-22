using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JustStock.BLL;

namespace JustStock.UI
{
    public partial class Dashboard : Form
    {
        private BLL.Usuario usuarioLogado;
        private void CarregarInformacoesUsuario()
        {
            label2.Text = $"Nome: {usuarioLogado.Nome}\nEmail: {usuarioLogado.Email}\nSenha: {usuarioLogado.Senha}\nTipo: {usuarioLogado.Tipo_usuario}";
        }
        public Dashboard(BLL.Usuario usuario)
        {
            InitializeComponent();
            usuarioLogado = usuario;
            CarregarInformacoesUsuario();
        }
    }
}
