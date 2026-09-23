using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace du_an_ket_thuc_hoc_phan
{

    public partial class DNIP : Form
    {
        
        
        public DNIP()
        {
            InitializeComponent();
            
        }

        private void DNIP_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        
        private void trux(string tk,string pw)
        {
            if (qlsl.conect())
            {   
                string sql = "select * from taikhoan where tendangnhap COLLATE Latin1_General_BIN = '" + tk + "' and matkhau COLLATE Latin1_General_BIN = '"+pw+"'";
                SqlCommand cmd = new SqlCommand(sql, qlsl.con);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    nguoidungcs.tendangnhap = rdr["tendangnhap"].ToString();
                    nguoidungcs.tenhienthi = rdr["tenhienthi"].ToString();                    
                    nguoidungcs.quyen = int.Parse(rdr["quyen"].ToString());
                    
                }
                
            }
            qlsl.end();

        }
        private bool login(string us, string pw) 
        {
            if (qlsl.conect())
            {
                string sql = "select count(*) from taikhoan where tendangnhap collate Latin1_General_BIN = '" + us + "' and matkhau collate Latin1_General_BIN = '" + pw + "'";
                SqlCommand cmd = new SqlCommand(sql, qlsl.con);
                int lg = int.Parse(cmd.ExecuteScalar().ToString());
                return lg > 0;
                
            }
            else
            {
                return false;
                
            }
            qlsl.end();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string us = textBox1.Text;
            string pw = textBox2.Text;
            if (login(us,pw))
            {
                trux(us,pw);
                MessageBox.Show("Đăng nhập thành công");                
                mainCS f2 = new mainCS();                
                f2.ShowDialog();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
