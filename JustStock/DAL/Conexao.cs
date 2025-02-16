using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace JustStock.DAL
{
    internal class Conexao
    {
        SqlConnection con = new SqlConnection(@"Data Source=JARVIS;Initial Catalog=juststock;Integrated Security=True");

        public SqlConnection Conectar()
        {
            if (con.State == ConnectionState.Closed)
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return con;
        }

        public void Desconectar()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
