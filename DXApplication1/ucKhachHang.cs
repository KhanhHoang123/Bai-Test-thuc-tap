using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace DXApplication1
{
    public partial class ucKhachHang : UserControl
    {
        public ucKhachHang()
        {
            InitializeComponent();
        }
        SqlConnection cn = null;
        DataTable tb = new DataTable();
        private void ucKhachHang_Load(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf('\\') - 3);
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"App_Data\QLBanHang.mdf;Integrated Security=True;");
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from KhachHang", cn);
            cmd.ExecuteNonQuery();
            //DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tb);
            gridControl1.DataSource = tb;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }
    }
}
