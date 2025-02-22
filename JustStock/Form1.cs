using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JustStock.UI;
using BCrypt.Net;

namespace JustStock
{
    public partial class Form1 : Form
    {
        BLL.Usuario user = new BLL.Usuario();
        DAL.UsuarioDAL userDal = new DAL.UsuarioDAL();
        private bool VerificarSenha(string senhaDigitada, string hashSalvo)
        {
            return BCrypt.Net.BCrypt.Verify(senhaDigitada, hashSalvo);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void linkCriarConta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CriarConta criarConta = new CriarConta();
            this.Hide();
            criarConta.ShowDialog();
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string senhaDigitada = txtSenha.Text;

            var usuario = userDal.BuscarPorEmail(email);

            if (usuario != null && VerificarSenha(senhaDigitada, usuario.Senha))
            {
                MessageBox.Show("Login bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Dashboard dash = new Dashboard(usuario);
                this.Hide();
                dash.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Email ou senha incorretos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkRedefinir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Criar código para redefinir senha
        }
    }
}
