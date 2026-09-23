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
    public partial class themxe : Form
    {
        public themxe()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show(" Vui lòng nhập dữ liệu ");
            }
            else
            {
                dulieuxe.bienso = textBox1.Text;
                dulieuxe.tenthietbi = textBox2.Text;
                dulieuxe.makh = textBox3.Text;
                dulieuxe.tinhtrang = textBox4.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
