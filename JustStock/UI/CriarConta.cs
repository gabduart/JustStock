using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using JustStock.DAL;
using BCrypt.Net;

namespace JustStock.UI
{
    public partial class CriarConta : Form
    {
        BLL.Usuario user = new BLL.Usuario();
        DAL.UsuarioDAL userDal = new DAL.UsuarioDAL();
        private bool TextBoxVazias()
        {
            foreach (Control c in this.Controls)
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                        return true;
                }
            return false;
        }
        private bool EmailValido(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(email, pattern))
            {
                return false;
            }
            return true;
        }
        private bool SenhaValida(string senha)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{}|;:'"",.<>?/`~\\])[A-Za-z\d!@#$%^&*()_+\-=\[\]{}|;:'"",.<>?/`~\\]{8,}$";
            return Regex.IsMatch(senha, pattern);
        }
        private string HashSenha(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public CriarConta()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string email = txtEmailCC.Text;
            string senha = txtSenhaCC.Text;
            string confSenha = txtConfSenhaCC.Text;

            if (TextBoxVazias())
            {
                MessageBox.Show("Todos os campos devem ser preenchidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (!EmailValido(email))
            {
                MessageBox.Show("Insira um e-mail válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (senha != confSenha)
            {
                MessageBox.Show("As senhas não coincidem!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (!SenhaValida(senha))
            {
                MessageBox.Show("A senha deve conter pelo menos:\n" +
                    "✔ 8 caracteres\n" +
                    "✔ 1 letra maiúscula\n" +
                    "✔ 1 letra minúscula\n" +
                    "✔ 1 número\n" +
                    "✔ 1 caractere especial (@$!%*?&)", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                try
                {
                    user.Nome = nome;
                    user.Email = email;
                    user.Senha = HashSenha(senha);

                    if (userDal.Cadastrar(user))
                    {
                        MessageBox.Show("Conta criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Redirecionar para a página de login
                        Form1 login = new Form1();
                        this.Hide();
                        login.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar usuário. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine("Erro ao criar conta: " + ex.Message);
                }
            }
        }

        private void linkCriarConta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 login = new Form1();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }
    }
}
