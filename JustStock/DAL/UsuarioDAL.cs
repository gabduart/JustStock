using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace JustStock.DAL
{
    internal class UsuarioDAL
    {
        Conexao con = new Conexao();

        public bool Cadastrar(BLL.Usuario user)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = @"INSERT INTO Usuarios    (nome, email, senha)
                                                VALUES      (@nome, @email, @senha)";
                command.Parameters.AddWithValue("@nome", user.Nome);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@senha", user.Senha);

                command.Connection = con.Conectar();
                command.ExecuteNonQuery();
                con.Desconectar();
            } catch
            {
                return false;
            }
            return true;
        }

        public BLL.Usuario BuscarPorEmail(string email)
        {
            BLL.Usuario user = null;
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = @"SELECT nome, email, senha, tipo_usuario FROM Usuarios WHERE email = @email";
                command.Parameters.AddWithValue("@email", email);

                command.Connection = con.Conectar();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    user = new BLL.Usuario();
                    user.Nome = reader["nome"].ToString();
                    user.Email = reader["email"].ToString();
                    user.Senha = reader["senha"].ToString();

                    // Verificar se tipo_usuario não é nulo e é um número
                    if (reader["tipo_usuario"] != DBNull.Value && int.TryParse(reader["tipo_usuario"].ToString(), out int tipoUsuario))
                    {
                        user.Tipo_usuario = tipoUsuario;
                    }
                    else
                    {
                        user.Tipo_usuario = 0;
                    }
                }

                reader.Close();
                con.Desconectar();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar usuário: " + ex.Message);
            }

            return user;
        }
    }
}
