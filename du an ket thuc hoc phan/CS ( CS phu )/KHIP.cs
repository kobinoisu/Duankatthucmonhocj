using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace du_an_ket_thuc_hoc_phan
{
    public partial class KHIP : Form
    {
        public class khachhang
        {
            public string maKH { get; set; }
            public string hoten { get; set; }
            public string sdt { get; set; }
            public string email { get; set; }
            public string cancuoc { get; set; }         
        }
        public khachhang KH { get; set; }
        public KHIP()
        {
            InitializeComponent();
        }

        private void KHIP_Load(object sender, EventArgs e)
        {

        }
        public void suakh (string makh ,string tenkh,string sdt,string email,string cc) 
        {
            textBox2.Text = makh;
            textBox1.Text = tenkh;
            textBox3.Text = sdt;
            textBox5.Text = email;
            textBox4.Text = cc;


        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (qlsl.conect())
            {
                string ts = "MaKH";
                string tss = "khachhang";
                string check = textBox1.Text;
                if (checklama.chekm(tss,ts,check))
                {
                    if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                         string.IsNullOrWhiteSpace(textBox2.Text) ||
                         string.IsNullOrWhiteSpace(textBox3.Text) ||
                         string.IsNullOrWhiteSpace(textBox5.Text) ||
                         string.IsNullOrWhiteSpace(textBox4.Text))
                    {
                        MessageBox.Show("Vui lòng Nhập Thông Tin ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!textBox5.Text.Contains("@"))
                    {
                        MessageBox.Show("email phải chứa kí tự '@'!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox5.Focus();
                        return;
                    }

                    KH = new khachhang
                    {
                        hoten = textBox1.Text,
                        maKH = textBox2.Text,
                        sdt = textBox3.Text,
                        email = textBox5.Text,
                        cancuoc = textBox4.Text,
                    };
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Back) 
            {
                e.Handled = false;
            }
            else 
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
