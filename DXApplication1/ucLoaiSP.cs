using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace DXApplication1
{
    public partial class ucLoaiSP : UserControl
    {
        public ucLoaiSP()
        {
            InitializeComponent();
        }
        SqlConnection cn = null;
        DataTable tb = new DataTable();
        private void ucLoaiSP_Load(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf('\\') - 3);
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"App_Data\QLBanHang.mdf;Integrated Security=True;");
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from LoaiSP", cn);
            cmd.ExecuteNonQuery();
            //DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tb);
            gridControl1.DataSource = tb;
        }
    }
}
