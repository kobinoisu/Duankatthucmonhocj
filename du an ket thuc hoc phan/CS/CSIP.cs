using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace du_an_ket_thuc_hoc_phan
{
    public partial class CSIP : Form
    {
        public class vattu
        {
        public string MaVT { get; set; }
        public string TenVT { get; set; }
        public string Soluong { get; set; }
        public string Dongia { get; set; }
        public string goianh { get; set; }
        public Image Anh { get; set; } 
        }
        private bool edited = false;
        public vattu Thongtinnhap { get; set; }
        private string dananh = "" ;
        public CSIP()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();   
        }
        public void sua(string maVT, string tenVT, string soluong, string dongia, string goianh, Image anh)
        {
            edited = true;
            textBox2.Text = maVT;
            textBox1.Text = tenVT;
            textBox4.Text = dongia;
            textBox3.Text= soluong;
            dananh = goianh;
            pictureBox1.Image = anh;
            textBox2.ReadOnly = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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

        private void CSIP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                return;
            }
                if (MessageBox.Show("Bạn chua luu có muốn thoát không?",
                    "Thông báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (
                  string.IsNullOrWhiteSpace(textBox1.Text)||
                  string.IsNullOrWhiteSpace(textBox2.Text)||
                  string.IsNullOrWhiteSpace(textBox3.Text)||
                  string.IsNullOrWhiteSpace(textBox4.Text)
                )
            {
                MessageBox.Show("vui long nhap thong tin ! "," thong bao ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Image anh = pictureBox1.Image;
            string da = dananh;
            if (anh == null || string.IsNullOrWhiteSpace(da))
            {   
                anh = Properties.Resources.cale;
                da = "";
            }
            
            
                Thongtinnhap = new vattu
                {
                    MaVT = textBox2.Text,
                    TenVT = textBox1.Text,
                    Dongia = textBox3.Text,
                    Soluong = textBox4.Text,                    
                    goianh = da,
                    Anh = anh
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Back) 
            {
                e.Handled = false;
            }
            else
                { e.Handled = true; }

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else { e.Handled = true; }
        }

        private void CSIP_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
