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
    public partial class suliitaikhoan : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
        SqlConnection con;
        string dananh;
        public suliitaikhoan()
        {
            InitializeComponent();
            con = new SqlConnection(connectionString);
        }
        public bool conect()
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
        private bool checkpass(string pwc ,string tk) 
        {
            if (conect())
            {
                string sql = "select count ( matkhau ) from taikhoan where tendangnhap COLLATE Latin1_General_BIN = '"+tk+"' and matkhau COLLATE Latin1_General_BIN = '"+pwc+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                int ctt = int.Parse(cmd.ExecuteScalar().ToString());
                return ctt > 0;
            }
            else
            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conect()) 
            {
            string tk =textBox5.Text;
            string pwc =textBox2.Text;
            string pwn =textBox3.Text;
                string nlmmk =textBox4.Text;
                if (checkpass(pwc,tk))
                {
                    if (nlmmk != pwn)
                    {
                        MessageBox.Show("Hãy nhập lại pass ");
                        textBox4.Focus();
                    }
                    else 
                    {
                        string sql = "update taikhoan set matkhau = '" + pwn + "' where matkhau = '" + pwc + "'\r\n";
                        SqlCommand command = new SqlCommand(sql, con);
                        command.ExecuteNonQuery();
                        MessageBox.Show(" đổi password thành thụ ");
                    }
                }
                else 
                {
                    MessageBox.Show(" sai password cũ "  );
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void suliitaikhoan_Load(object sender, EventArgs e)
        {
            textBox1.Text = nguoidungcs.tenhienthi;
            textBox6.Text = nguoidungcs.tendangnhap;
            if (!string.IsNullOrEmpty(dananh) && System.IO.File.Exists(dananh))
            {
                pictureBox1.Image = Image.FromFile(dananh);
            }
            else
            {
                pictureBox1.Image = Properties.Resources.cale;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private bool check = true;
        private void button3_Click(object sender, EventArgs e)
        {
        
            if (check)
            {
                textBox2.PasswordChar = '\0';
                button3.BackColor = Color.FromArgb(245, 196, 0);
            }
            else
            {
                 textBox2.PasswordChar = '*';                 
                 button3.BackColor = Color.FromArgb(24, 53, 104);

            }
            check = !check;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (check)
            {
                textBox3.PasswordChar = '\0';
                button4.BackColor = Color.FromArgb(245, 196, 0);
            }
            else
            {
                textBox3.PasswordChar = '*';
                button4.BackColor = Color.FromArgb(24, 53, 104);
            }
            check = !check;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (check)
            {
                textBox4.PasswordChar = '\0';
                button5.BackColor = Color.FromArgb(245, 196, 0);
            }
            else
            {
                textBox4.PasswordChar = '*';
                button5.BackColor = Color.FromArgb(24, 53, 104);
            }
            check = !check;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (check)
            {
                textBox6.PasswordChar = '\0';
                button6.BackColor = Color.FromArgb(245, 196, 0);
            }
            else
            {
                textBox6.PasswordChar = '*';
                button6.BackColor = Color.FromArgb(24, 53, 104);
            }
            check = !check;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            

            }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog im = new OpenFileDialog();
            im.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            im.Title = "Chon anh cua ban";
            if (im.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(im.FileName);
                dananh = im.FileName;
            }
        }
    }
}
