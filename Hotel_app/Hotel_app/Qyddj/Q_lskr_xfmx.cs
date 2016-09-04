using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Q_lskr_xfmx : Form
    {
        public Q_lskr_xfmx()
        {
            InitializeComponent();
        }

        private DataSet ds_lsxfxx = null;
        private string krxm = "";
        private string zjhm = "";
        private string totalCost = "";
        public Q_lskr_xfmx(DataSet ds_lsxfxx,string krxm,string zjhm,string totalCost)
        {
            InitializeComponent();
            this.ds_lsxfxx = ds_lsxfxx;
            this.krxm = krxm;
            this.zjhm = zjhm;
            this.totalCost = totalCost;
            Bindata();
        }
        private void Bindata()
        {
            if (ds_lsxfxx != null&&ds_lsxfxx.Tables[0].Rows.Count>0)
            {
                dgv_lskrxfxx.AutoGenerateColumns = false;
                bindingSource1.DataSource = ds_lsxfxx.Tables[0].DefaultView;
                dgv_lskrxfxx.DataSource = bindingSource1;
                tb_krxm.Text = krxm;
                tb_zjhm.Text = zjhm;
                tb_ljxf.Text = totalCost;
            }
        }
    }
}