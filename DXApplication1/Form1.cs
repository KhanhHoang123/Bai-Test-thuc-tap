using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace DXApplication1
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            pnTrangchu.Controls.Clear();
            ucHinhtrangchinh frm = new ucHinhtrangchinh();
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            pnTrangchu.Controls.Add(frm);
            
            
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnTrangchu.Controls.Clear();
            ucHinhCaNhan canhan = new ucHinhCaNhan();
            canhan.Dock = System.Windows.Forms.DockStyle.Fill;
            pnTrangchu.Controls.Add(canhan);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnTrangchu.Controls.Clear();
            ucCongTy ct = new ucCongTy();
            ct.Dock = System.Windows.Forms.DockStyle.Fill;
            pnTrangchu.Controls.Add(ct);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnTrangchu.Controls.Clear();
            ucSanPham sp = new ucSanPham();
            sp.Dock = System.Windows.Forms.DockStyle.Fill;
            pnTrangchu.Controls.Add(sp);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnTrangchu.Controls.Clear();
            ucLoaiSP lsp = new ucLoaiSP();
            lsp.Dock = System.Windows.Forms.DockStyle.Fill;
            pnTrangchu.Controls.Add(lsp);
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pnTrangchu.Controls.Clear();
            ucNhanVien nv = new ucNhanVien();
            nv.Dock = System.Windows.Forms.DockStyle.Fill;
            pnTrangchu.Controls.Add(nv);
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {
            pnTrangchu.Controls.Clear();
            ucHoaDon hd = new ucHoaDon();
            hd.Dock = System.Windows.Forms.DockStyle.Fill;
            pnTrangchu.Controls.Add(hd);
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pnTrangchu.Controls.Clear();
            ucCTHD cthd = new ucCTHD();
            cthd.Dock = System.Windows.Forms.DockStyle.Fill;
            pnTrangchu.Controls.Add(cthd);
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pnTrangchu.Controls.Clear();
            ucKhachHang kh = new ucKhachHang();
            kh.Dock = System.Windows.Forms.DockStyle.Fill;
            pnTrangchu.Controls.Add(kh);
        }

       

        
    }
}
