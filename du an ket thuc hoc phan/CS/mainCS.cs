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
    public partial class mainCS : Form
    {
        public mainCS()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {            
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CS2 f2 = new CS2();
            f2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CS3 f3 = new CS3();
            f3.ShowDialog();
        }

        private void mainCS_Load(object sender, EventArgs e)
        {
            string ten = nguoidungcs.tenhienthi;
            label1.Text = "Chào Mừng " + ten + " Đến Với Chương Trình Tính Vật Tư ";
            if (nguoidungcs.quyen == 1) 
            {
                button6.Enabled = false;
                button3.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CS4 f1 = new CS4();
            f1.ShowDialog();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            suliitaikhoan f1 = new suliitaikhoan();
            f1.ShowDialog();

            
        }
        
        private void mainCS_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = MessageBox.Show(" Bạn có chắc chắn đăng xuất không ? ", " thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.No)
            {
                e.Cancel = true;
            }
            else 
            {
                nguoidungcs.clee();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
