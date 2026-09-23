using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace du_an_ket_thuc_hoc_phan
{    
    public partial class CS3 : Form
    {
        
        
        public CS3()
        {
            InitializeComponent();
            

        }
        
        private void loaf() 
        {
            if (qlsl.conect())
            {
                string sql = "select * from khachhang";
                SqlCommand cmd = new SqlCommand(sql, qlsl.con);
                SqlDataReader rd = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                int stt = 1;
                while (rd.Read()) 
                {
                    string makh  = rd["Makh"].ToString();
                    string tenkh = rd["TenKH"].ToString();
                    string sdt   = rd["SDT"].ToString();
                    string email = rd["email"].ToString();
                    string cc    = rd["MST"].ToString();
                    dataGridView1.Rows.Add(stt++,makh,tenkh,sdt,cc,email);
                }
                rd.Close();
                qlsl.end();
            }
        }
        private void CS3_Load(object sender, EventArgs e)
        {
            if(qlsl.conect())
            {
                loaf();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KHIP f2 = new KHIP();
            if (f2.ShowDialog() == DialogResult.OK) 
            {
                int stt =(dataGridView1.Rows.Count)+1;
                var datakh = f2.KH;
                dataGridView1.Rows.Add(stt,datakh.maKH,datakh.hoten,datakh.sdt,datakh.cancuoc,datakh.email);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow r2 = dataGridView1.CurrentRow;
                string makh = r2.Cells[1].Value.ToString();
                string tenkh = r2.Cells[2].Value.ToString();
                string sdt = r2.Cells[3].Value.ToString();
                string email = r2.Cells[5].Value.ToString();
                string cc = r2.Cells[4].Value.ToString();
                KHIP f3 = new KHIP();
                f3.suakh( tenkh,makh, sdt, email, cc);
                if (f3.ShowDialog() == DialogResult.OK)
                {
                    var datakh = f3.KH;
                    r2.Cells[2].Value = datakh.maKH;
                    r2.Cells[1].Value = datakh.hoten;
                    r2.Cells[3].Value = datakh.sdt;
                    r2.Cells[5].Value = datakh.email;
                    r2.Cells[4].Value = datakh.cancuoc;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (qlsl.conect()) 
            {
                loaf();
                MessageBox.Show("Dữ liệu đã được nhập thành công !");
            }
        }
        private void link()
        {
            if (qlsl.conect())
            {
                SqlCommand cmd = new SqlCommand("delete from khachhang", qlsl.con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string Makh  = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string Tenkh = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string sdt   = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string email = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    string cc    = dataGridView1.Rows[i].Cells[4].Value.ToString();

                    String Sql = " insert into khachhang values( @Makh, @TenKH, @SDT, @email, @MST)";
                    SqlCommand icmd = new SqlCommand(Sql, qlsl.con);
                    icmd.Parameters.Add("@Makh",  SqlDbType.VarChar). Value = Makh;
                    icmd.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = Tenkh;
                    icmd.Parameters.Add("@SDT",   SqlDbType.VarChar). Value = sdt;
                    icmd.Parameters.Add("@MST", SqlDbType.VarChar). Value = email;
                    icmd.Parameters.Add("@email",  SqlDbType.VarChar). Value = cc;
                    icmd.ExecuteNonQuery();
                    icmd.Dispose();
                }
                qlsl.end();
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            if (qlsl.conect()) 
            {
                link();
                MessageBox.Show("Dữ liệu đã được lưu thành công");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
