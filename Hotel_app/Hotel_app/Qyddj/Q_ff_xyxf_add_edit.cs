using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Qyddj
{
    public partial class Q_ff_xyxf_add_edit : Form
    {
        public string xfdr = "";
        public string add_edit = common_file.common_app.get_add;
        public string id = "";
        Model.Q_ff_xyxf M_Q_ff_xyxf;
        BLL.Q_ff_xyxf B_Q_ff_xyxf;
        public Q_ff_xyxf_add_edit(string add_edit_0,string id_0)
        {
            add_edit = add_edit_0;
            id = id_0;
            if(add_edit==common_file.common_app.get_edit)
            {
                if (id != "")
                {
                    M_Q_ff_xyxf = B_Q_ff_xyxf.GetModel(int.Parse(id));
                }
            }
            InitializeComponent();
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Q_ff_xyxf_add_edit_Load(object sender, EventArgs e)
        {
            cB_fyrx.Text = Szwgl.common_zw.fwrx_sjje;
            cB_fyrx.Items.Add(Szwgl.common_zw.fwrx_sjje);
            cB_fyrx.Items.Add(Szwgl.common_zw.fwrx_abl);
        }

        private void b_save_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}