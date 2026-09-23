using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace du_an_ket_thuc_hoc_phan
{
    public partial class CS4 : Form
    {
        public CS4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void laofxe()
        {      
            
            
                Button btn = new Button();
                btn.Text = dulieuxe.bienso; 
                btn.Width = 140;   
                btn.Height = 180;
                btn.BackColor = Color.LightSkyBlue;
                btn.Margin = new Padding(10);
               
                btn.Click += (sender, e) =>
                { 
                    hdip f1 = new hdip();
                    f1.ShowDialog();
                };                
                flowLayoutPanel1.Controls.Add(btn);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            
          themxe f4 = new themxe();
          if (f4.ShowDialog() == DialogResult.OK)
            {
                if (qlsl.conect())
                {
                    laofxe();
                    string sql = "insert into thietbi values('" + dulieuxe.bienso + "', N'" + dulieuxe.tenthietbi + "', '" + dulieuxe.makh + "', '" + dulieuxe.tinhtrang + "');";
                    SqlCommand cmd = new SqlCommand(sql,qlsl.con);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    qlsl.end();
                    
                }
                
            }    
           
        }
    }
}
