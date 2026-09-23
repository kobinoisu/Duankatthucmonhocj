using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace du_an_ket_thuc_hoc_phan
{    
    public partial class CS2 : Form
    {
        
        private bool save = true;
        public CS2()
        {
            InitializeComponent();   
            
        }

        
        private void Form1_Load(object sender, EventArgs e)
        { 
            if(qlsl.conect())
            loafdata();
        }




        private void loafdata() 
        {
            if (qlsl.conect())
            {
                string sql = "select * from vattu";
                SqlCommand cmd = new SqlCommand(sql, qlsl.con);
                SqlDataReader rd = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                int Stt = 1;
                while (rd.Read())
                {
                    string MaVT = rd["MaVT"].ToString();
                    string TenVt = rd["TenVt"].ToString();
                    decimal slg = decimal.Parse(rd["solg"].ToString());
                    decimal gia = decimal.Parse(rd["gia"].ToString());
                    string goianh = rd["goianh"].ToString();
                    Image Anh;
                    if (!string.IsNullOrEmpty(goianh) && System.IO.File.Exists(goianh))
                    {
                        Anh = Image.FromFile(goianh);
                    }
                    else
                    {
                        Anh = Properties.Resources.cale;
                    }

                    dataGridView1.Rows.Add(Stt++, MaVT, TenVt, gia, slg, Anh, goianh);
                }
                rd.Close();
                qlsl.end();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();   
        }
        
        private void linkdata()
        {
            
            if (qlsl.conect())
            {
                SqlCommand cmd = new SqlCommand("delete from vattu;", qlsl.con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string Mavt = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string TenVt = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    decimal slg = decimal.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    decimal dongia = decimal.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    string goianh = dataGridView1.Rows[i].Cells[6].Value.ToString();

                    String Sql = " insert into vattu values( @MaVT, @TenVT, @gia, @solg, @goianh )";
                    SqlCommand icmd = new SqlCommand(Sql,qlsl.con);
                    icmd.Parameters.Add("@MaVT", SqlDbType.VarChar).Value = Mavt;
                    icmd.Parameters.Add("@TenVT", SqlDbType.NVarChar).Value = TenVt;
                    icmd.Parameters.Add("@gia", SqlDbType.Decimal).Value = dongia;
                    icmd.Parameters.Add("@solg", SqlDbType.Int).Value = slg;
                    icmd.Parameters.Add("@goianh", SqlDbType.VarChar).Value = goianh;
                    icmd.ExecuteNonQuery();
                    icmd.Dispose();
                }
                qlsl.end();
            }
        }
        
     
        private void button2_Click(object sender, EventArgs e)
        {
            CSIP f2 = new CSIP();
            if(f2.ShowDialog() == DialogResult.OK)
            {
                int stt = dataGridView1.Rows.Count + 1;
                var datavt = f2.Thongtinnhap;
                dataGridView1.Rows.Add( stt,datavt.MaVT, datavt.TenVT, datavt.Dongia , datavt.Soluong, datavt.Anh, datavt.goianh);
            }
            save = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (qlsl.conect())
            {
                linkdata();
                MessageBox.Show("Dữ liệu đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                save = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DataGridViewRow r1 = dataGridView1.CurrentRow;
                string maVT = r1.Cells[1].Value.ToString();
                string tenVT = r1.Cells[2].Value.ToString();
                string dongia = r1.Cells[3].Value.ToString();
                string soluong = r1.Cells[4].Value.ToString();               
                Image Anh = r1.Cells[5].Value as Image;
                string goianh = r1.Cells[6].Value.ToString();

                CSIP f2 = new CSIP();
                f2.sua(maVT, tenVT, dongia, soluong,goianh,Anh);
                if (f2.ShowDialog() == DialogResult.OK)
                {
                   
                    var data = f2.Thongtinnhap;
                    r1.Cells[1].Value = data.MaVT;
                    r1.Cells[2].Value = data.TenVT;
                    r1.Cells[3].Value = data.Dongia;
                    r1.Cells[4].Value = data.Soluong;                    
                    r1.Cells[5].Value = data.Anh;
                    r1.Cells[6].Value = data.goianh;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            save = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {                
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {                   
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;                    
                }                
                save = false;
            }

        }

        private void CS2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!save)
            {
                DialogResult = MessageBox.Show
                    ("ban chua luu ban co muon luu khong", " xac nhan ",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    linkdata();
                }
                if (DialogResult == DialogResult.No)
                {
                    e.Cancel = false;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            
            loafdata();
            MessageBox.Show("Dữ liệu đã được nhập thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            save = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
