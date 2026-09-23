using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace du_an_ket_thuc_hoc_phan
{
    public static class checklama
    {
        public static bool chekm(string check, string ts1, string ts2)
        {
            try
            {
                bool t = false;
                if (qlsl.conect())
                {

                    string sql = "select count(*) from " + ts1 + " where " + ts2 + " = @check";

                    using (SqlCommand cmd = new SqlCommand(sql, qlsl.con))
                    {
                        cmd.Parameters.Add("@check", SqlDbType.VarChar, 50).Value = check.Trim();
                        int kq = Convert.ToInt32(cmd.ExecuteScalar());
                        if (kq > 0)
                        {
                            t = true;
                        }
                    }
                }
                return t;
            }
            finally
            {
                qlsl.end();
            }           
        }
    }
}
