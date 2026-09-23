using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace du_an_ket_thuc_hoc_phan
{
    public static class nguoidungcs
    {
        public static string tendangnhap { get;set; }
        public static string tenhienthi { get;set; }        
        public static int quyen { get; set; }
        public static void clee() 
        {
            tendangnhap = null;
            tenhienthi = null;            
            quyen = 1;

        }
    }
}
