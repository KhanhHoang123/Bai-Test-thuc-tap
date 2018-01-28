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
    public partial class ucSanPham : UserControl
    {
        public ucSanPham()
        {
            InitializeComponent();
        }
        SqlConnection cn = null;
        DataTable tb = new DataTable();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ucSanPham_Load(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf('\\') - 3);
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"App_Data\QLBanHang.mdf;Integrated Security=True;");
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from SanPham", cn);
            cmd.ExecuteNonQuery();
            //DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tb);
           gridControl1.DataSource = tb;
        }

       
        //Nút In
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }
        //Nút Tìm
        private void btTim_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf('\\') - 3);
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"App_Data\QLBanHang.mdf;Integrated Security=True;");
            
            string sql = "SELECT * FROM SanPham WHERE MaSP LIKE N'%" + txtMa.Text + "%'";
            cn.Open();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tb);
            gridControl1.DataSource = tb;
        }
        //Nút Xóa
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Xoa();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from SanPham", cn);
            SqlCommandBuilder cmb = new SqlCommandBuilder(sda);
            sda.Update(tb);
            
        }

        //Code chức năng Thêm
        public void Them()
        {
            DataRow dr = tb.NewRow();
            DataColumn[] keyColumn = new DataColumn[1]; // số cột làm khóa chính là 1
            keyColumn[0] = tb.Columns["MaSP"];
            tb.PrimaryKey = keyColumn;

            // CSDL bảng Customer không có Primary nên không thể thực hiện lệnh delete
            dr = tb.Rows.Find(txtMa.Text.Trim());
            if (dr == null)
            {
                dr = tb.NewRow();
                dr[0] = txtMa.Text;
                dr[1] = txtTen.Text;
                dr[2] = txtDonvi.Text;
                dr[3] = txtDongia.Text;
                dr[4] = txtMaLoai.Text;
                try
                {
                    tb.Rows.Add(dr);
                    MessageBox.Show("Thêm thành công vui lòng nhấn lại nút Sản Phẩm để cập nhật dữ liệu!!");
                    
                   

                }
                catch (MissingPrimaryKeyException ex)
                {

                    SqlDataAdapter sda = new SqlDataAdapter("Select * from SanPham", cn);
                    SqlCommandBuilder cmb = new SqlCommandBuilder(sda);
                    sda.Update(tb);
                    gridControl1.DataSource = tb;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                MessageBox.Show("San Pham đã tồn tại");
            }
        }
        // Code chức năng Xóa
        public void Xoa()
        {
            DataRow dr = tb.NewRow();
            DataColumn[] keyColumn = new DataColumn[1]; 
            keyColumn[0] = tb.Columns["MaSP"];
            tb.PrimaryKey = keyColumn;

            
            dr = tb.Rows.Find(txtMa.Text.Trim());
            if (dr != null)
            {
                try
                {
                    dr.Delete();
                    MessageBox.Show("Ban xoa thanh cong");
                }
                catch (MissingPrimaryKeyException ex)
                {
                    
                    SqlDataAdapter sda = new SqlDataAdapter("Select * from SanPham", cn);
                    SqlCommandBuilder cmb = new SqlCommandBuilder(sda);
                    sda.Update(tb);
                    gridControl1.DataSource = tb;
                }
            }
            else
            {
                MessageBox.Show("San Pham ban xoa khong ton tai");
            }
        }
        //Nut thêm
        private void btThem_Click(object sender, EventArgs e)
        {
            Them();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from SanPham", cn);
            SqlCommandBuilder cmb = new SqlCommandBuilder(sda);
            sda.Update(tb);
        }
        //Nut Sửa
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataColumn[] key = new DataColumn[1];
            key[0] = tb.Columns["MaSP"];
            tb.PrimaryKey = key;
            DataRow dr = tb.NewRow();
            dr = tb.Rows.Find(txtMa.Text.Trim());
            if (dr != null)
            {
                dr.BeginEdit();
                dr["TenSP"] = txtTen.Text.Trim();
                dr["Donvitinh"] = txtDonvi.Text.Trim();
                dr["Dongia"] = txtDongia.Text.Trim();
                dr["MaLoaiSP"] = txtMaLoai.Text.Trim();
                dr.EndEdit();
                SqlDataAdapter sda = new SqlDataAdapter("Select * from SanPham", cn);
                SqlCommandBuilder cmb = new SqlCommandBuilder(sda);
                sda.Update(tb);
                MessageBox.Show("Sua thanh cong!!!");
                gridControl1.DataSource = tb;
            }
            else
            {
                MessageBox.Show("San Pham ban sua khong ton tai");
            }
        }

       
    }
}
