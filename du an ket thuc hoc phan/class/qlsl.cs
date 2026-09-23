using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace du_an_ket_thuc_hoc_phan
{
    internal class qlsl
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
        public static SqlConnection con = new SqlConnection(connectionString);
        public static bool conect()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối cơ sở dữ liệu thất bại!\nLỗi chi tiết: " + ex.Message,
                                "Lỗi kết nối",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

        }
        public static void end()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}

