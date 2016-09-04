using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.dxpt
{
    public partial class Frm_gl : Form
    {
        public Frm_gl(dxpt_send  frm_p)
        {
            InitializeComponent();
        }

        public string get_sel_cond = "  ";
        public string get_sel_cond_page2 = "   ";
        public string select_source = "";
        public string TableName = "";//返回查询客史的来源，外部导入时放空
        public string Inport_fileName = "";//如果选择外部导入，这里保留导入的文件名
        public string inport_file_type = "";//外部导入文件的扩展名
        private void cb_infoSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_infoSource.SelectedItem != null && !cb_infoSource.SelectedItem.ToString().Equals(""))
            {
                if (cb_infoSource.SelectedItem.ToString().Equals("客史"))
                {
                    changePanelControlText("客史");
                }
               if(cb_infoSource.SelectedItem.ToString().Equals("会员"))
                {
                    changePanelControlText("会员");
                }
                if(cb_infoSource.SelectedItem.ToString().Equals("协议单位"))
                {
                    changePanelControlText("协议单位");
                }
                if (cb_infoSource.SelectedItem.ToString().Equals("外部导入"))
                {
                    changePanelControlText("外部导入");
                }
            }
        }

        private void changePanelControlText(string p)
        {
            if (p.Equals("客史"))
            {
                l_1.Visible = l_2.Visible = l_3.Visible = l_4.Visible = l_5.Visible = l_6.Visible = tB_1.Visible = tB_2.Visible = tB_3.Visible = tB_4.Visible = dT_ddsj_cs.Visible = dT_ddsj_js.Visible = dT_lksj_cs.Visible = dT_lksj_js.Visible =p_button.Visible= true;
                p_input.Height = 240;
                this.Height = 395;
               tB_0.Enabled = tB_1.Enabled = tB_2.Enabled = tB_3.Enabled = tB_4.Enabled = dT_ddsj_cs.Enabled = dT_ddsj_js.Enabled = dT_lksj_cs.Enabled = dT_lksj_js.Enabled = true;
               b_in.Visible =  b_selectFile.Visible = b_cancell.Visible = false;
               tB_0.Width = 219;

                l_0.Text = "手机号码";
                l_1.Text = "证件号码";
                l_2.Text = "客人姓名";
                l_3.Text = "注册门店";
                tB_3.Enabled = false;
                l_4.Text = "客人性别";
                tB_4.Enabled = false;
                l_5.Text = "到达时间";
                l_6.Text = "离开时间";

                select_source = "1";
                TableName = common_dxpt.dx_table_source_ks;
            }
            if (p.Equals("会员"))
            {
                l_1.Visible = l_2.Visible = l_3.Visible = l_4.Visible = l_5.Visible = l_6.Visible = tB_1.Visible = tB_2.Visible = tB_3.Visible = tB_4.Visible = dT_ddsj_cs.Visible = dT_ddsj_js.Visible = dT_lksj_cs.Visible = dT_lksj_js.Visible = p_button.Visible = true;
                p_input.Height = 240;
                this.Height = 395;
                tB_0.Enabled = tB_1.Enabled = tB_2.Enabled = tB_3.Enabled = tB_4.Enabled = dT_ddsj_cs.Enabled = dT_ddsj_js.Enabled = dT_lksj_cs.Enabled = dT_lksj_js.Enabled = true;
                b_in.Visible = b_selectFile.Visible = b_cancell.Visible = false;
                tB_0.Width = 219;
                l_0.Text = "会员卡号";
                l_1.Text = "会员类型";
                l_2.Text = "客人姓名";
                l_3.Text = "注册门店";
                l_4.Text = "客人性别";
                l_5.Text = "注册时间";
                l_6.Text = "离开时间";
                dT_lksj_cs.Enabled = dT_lksj_js.Enabled = false;

                tB_0.Width = 219;
                select_source = "2";
                TableName =common_dxpt.dx_table_source_hy;

            }
            if(p.Equals("协议单位"))
            {
                l_1.Visible = l_2.Visible = l_3.Visible = l_4.Visible = l_5.Visible = l_6.Visible = tB_1.Visible = tB_2.Visible = tB_3.Visible = tB_4.Visible = dT_ddsj_cs.Visible = dT_ddsj_js.Visible = dT_lksj_cs.Visible = dT_lksj_js.Visible = p_button.Visible = true;
                p_input.Height = 240;
                this.Height = 395;
                tB_0.Enabled = tB_1.Enabled = tB_2.Enabled = tB_3.Enabled = tB_4.Enabled = dT_ddsj_cs.Enabled = dT_ddsj_js.Enabled = dT_lksj_cs.Enabled = dT_lksj_js.Enabled = true;
                b_in.Visible = b_selectFile.Visible = b_cancell.Visible = false;
                tB_0.Width = 219;
                l_0.Text = "协议单位";
                l_1.Text = "协议类型";
                l_2.Text = "联系人";
                l_3.Text = "销售员";
                l_4.Text = "客人性别";
                tB_4.Enabled = false;
                l_5.Text = "签订时间";
                l_6.Text = "离开时间";
                dT_lksj_cs.Enabled = dT_lksj_js.Enabled = false;

                tB_0.Width = 395;
                select_source = "3";
                TableName = common_dxpt.dx_table_source_xydw;

            }
            if (p.Equals("外部导入"))
            {
                l_1.Visible = l_2.Visible = l_3.Visible = l_4.Visible = l_5.Visible = l_6.Visible =  tB_1.Visible = tB_2.Visible = tB_3.Visible = tB_4.Visible = dT_ddsj_cs.Visible = dT_ddsj_js.Visible = dT_lksj_cs.Visible = dT_lksj_js.Visible = false;
                b_in.Visible = b_exit.Visible = b_selectFile.Visible = b_cancell.Visible = true;
                l_0.Text = "文件名";
                p_button.Visible = false;

                tB_0.Width = 133;
                select_source = "4";
                TableName = common_dxpt.dx_table_wb;
                p_input.Height = 87;
                this.Height = 185;
            }
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            gl();
            if (get_sel_cond != "")
            {
                this.DialogResult = DialogResult.OK;
            }
            if (get_sel_cond_page2 != "")
            {
                this.DialogResult = DialogResult.OK;
            }

        }

        private void gl()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (select_source.Equals("1"))
                {

                    if (tB_0.Text.Trim() != "")
                    {
                        get_sel_cond += "  and  krdh  like '%" + tB_0.Text.Trim() + "%'  ";
                    }
                    if (tB_1.Text.Trim() != "")
                    {
                        get_sel_cond += "  and   zjhm  like '%" + tB_1.Text.Trim().Replace("'", "-") + "%'  ";
                    }
                    if (tB_2.Text.Trim() != "")
                    {
                        get_sel_cond += "  and  krxm   like '%" + tB_2.Text.Trim().Replace("'", "-") + "%'  ";
                    }
                    if (DateTime.Parse(dT_ddsj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_ddsj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                    {
                        get_sel_cond = get_sel_cond + " and (ddsj between '" + dT_ddsj_cs.Value.ToShortDateString() + "' and '" + dT_ddsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
                    }
                    if (DateTime.Parse(dT_lksj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_lksj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                    {
                        get_sel_cond = get_sel_cond + " and (tfsj between '" + dT_lksj_cs.Value.ToShortDateString() + "' and '" + dT_lksj_cs.Value.ToShortDateString() + " 23:59:59" + "')";
                    }
                    get_sel_cond += "  and  krdh!=''  ";
                }
                if (select_source.Equals("2"))
                {
                    b_in.Visible = b_exit.Visible = true;

                    if (tB_0.Text.Trim() != "")
                    {
                        get_sel_cond += "  and  hykh_bz  like '%" + tB_0.Text.Trim() + "%'  ";
                    }
                    if (tB_1.Text.Trim() != "")
                    {
                        get_sel_cond += "  and   hyrx  like '%" + tB_1.Text.Trim().Replace("'", "-") + "%'  ";
                    }
                    if (tB_2.Text.Trim() != "")
                    {
                        get_sel_cond += "  and  krxm   like '%" + tB_2.Text.Trim().Replace("'", "-") + "%'  ";
                    }
                    if (tB_3.Text.Trim() != "")
                    {
                        get_sel_cond += "  and  krxb   like '%" + tB_3.Text.Trim().Replace("'", "-") + "%'  ";
                    }
                    if (DateTime.Parse(dT_ddsj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_ddsj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                    {
                        get_sel_cond = get_sel_cond + " and (djsj between '" + dT_ddsj_cs.Value.ToShortDateString() + "' and '" + dT_ddsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
                    }
                    if (DateTime.Parse(dT_lksj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_lksj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                    {
                        get_sel_cond = get_sel_cond + " and (krsr between '" + dT_lksj_cs.Value.ToShortDateString() + "' and '" + dT_lksj_cs.Value.ToShortDateString() + " 23:59:59" + "')";
                    }
                    get_sel_cond += "  and  krsj!=''  ";

                }
                if (select_source.Equals("3"))
                {
                    b_in.Visible = b_exit.Visible = true;

                    if (tB_0.Text.Trim() != "")
                    {
                        get_sel_cond += "  and  xydw  like '%" + tB_0.Text.Trim() + "%'  ";
                    }
                    if (tB_1.Text.Trim() != "")
                    {
                        get_sel_cond += "  and   rx  like '%" + tB_1.Text.Trim().Replace("'", "-") + "%'  ";
                    }
                    if (tB_2.Text.Trim() != "")
                    {
                        get_sel_cond += "  and  nxr   like '%" + tB_2.Text.Trim().Replace("'", "-") + "%'  ";
                    }
                    if (tB_3.Text.Trim() != "")
                    {
                        get_sel_cond += "  and  xsy   like '%" + tB_3.Text.Trim().Replace("'", "-") + "%'  ";
                    }
                    if (DateTime.Parse(dT_ddsj_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dT_ddsj_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                    {
                        get_sel_cond = get_sel_cond + " and (clsj  between '" + dT_ddsj_cs.Value.ToShortDateString() + "' and '" + dT_ddsj_js.Value.ToShortDateString() + " 23:59:59" + "')";
                    }
                    get_sel_cond += "  and  krdh!=''  ";

                }
                if (select_source.Equals("4"))
                {
                    //隐藏所有控件，出现导入的对话框
                    //l_0.Visible = l_1.Visible = l_2.Visible = l_3.Visible = l_4.Visible = l_5.Visible = l_6.Visible = tB_0.Visible = tB_1.Visible = tB_2.Visible = tB_3.Visible = tB_4.Visible = dT_ddsj_cs.Visible = dT_ddsj_js.Visible = dT_lksj_cs.Visible = dT_lksj_js.Visible = false;
                    //b_in.Visible = b_exit.Visible = true;
                    //l_0.Text = "文件名";
                }
            }
            if (tabControl1.SelectedIndex == 1)
            {
                    if (DateTime.Parse(dt_fs_cs.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj) || DateTime.Parse(dt_fs_js.Value.ToShortDateString()) != DateTime.Parse(common_file.common_app.cssj))
                    {
                        get_sel_cond_page2 = get_sel_cond_page2 + " and (sendTime  between '" + dt_fs_cs.Value.ToShortDateString() + "' and '" + dt_fs_js.Value.ToShortDateString() + " 23:59:59" + "')";
                    }
                    if (cb_fs_status.Text.Trim().Replace("'", "-") != "")
                    {
                        if(cb_fs_status.Text.Trim().Replace("'", "-").Equals("发送成功"))
                        {
                        get_sel_cond_page2 = get_sel_cond_page2 + " and sendStatusCode='0'  ";
                        }
                        if(cb_fs_status.Text.Trim().Replace("'", "-").Equals("发送失败"))
                        {
                        get_sel_cond_page2 = get_sel_cond_page2 + " and sendStatusCode!='0'  ";
                        }
                    }
                    if (tb_yfs_krxm.Text.Trim().Replace("'", "-") != "")
                    {
                        get_sel_cond_page2 = get_sel_cond_page2 + " and userName like '%" + tb_yfs_krxm.Text.Trim().Replace("'", "-") + "%'";
                    }
                    if (tb_yfs_sj.Text.Trim().Replace("'", "-") != "")
                    {
                        get_sel_cond_page2 = get_sel_cond_page2 + " and phoneNo like '%" + tb_yfs_sj.Text.Trim().Replace("'", "-") + "%'";
                    }
                    if (tb_yfs_info.Text.Trim().Replace("'", "-") != "")
                    {
                        get_sel_cond_page2 = get_sel_cond_page2 + " and tb_yfs_info like '%" + tb_yfs_info.Text.Trim().Replace("'", "-") + "%'";
                    }
            }
        }

        private void Frm_gl_Load(object sender, EventArgs e)
        {
            //默认显示成会员
            l_0.Visible = l_1.Visible = l_2.Visible = l_3.Visible = l_4.Visible = l_5.Visible = l_6.Visible = tB_0.Visible = tB_1.Visible = tB_2.Visible = tB_3.Visible = tB_4.Visible = dT_ddsj_cs.Visible = dT_ddsj_js.Visible = dT_lksj_cs.Visible = dT_lksj_js.Visible = true;
            b_in.Visible =  b_selectFile.Visible = b_cancell.Visible = false;
            tB_0.Width = 219;
            l_0.Text = "会员卡号";
            l_1.Text = "会员类型";
            l_2.Text = "客人姓名";
            l_3.Text = "注册门店";
            l_4.Text = "客人性别";
            l_5.Text = "注册时间";
            l_6.Text = "离开时间";
            l_6.Visible = true;
            dT_lksj_cs.Enabled = dT_lksj_js.Enabled = false;

            tB_0.Width = 219;
            select_source = "2";
            cb_infoSource.SelectedIndex = 1; TableName = "Hhygl";

        }

        private void b_selectFile_Click(object sender, EventArgs e)
        {
            //txt文件格式，一行一个数据
            //excel格式，一行三旬，分别为（电话，证件，姓名）
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|Excel Files (*.xls)|*.xls";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                if (filename.Trim() != "")
                {
                    tB_0.Text = filename;
                }
                //通过后最后的后缀名断送是什么类型文件
                string extendName = filename.Substring(filename.LastIndexOf(".") + 1);
                if(extendName.Equals("txt"))//文本文件
                {
                    inport_file_type = "txt";
                }
                if (extendName.Equals("xls"))//要导入EXCEL文件
                {
                    inport_file_type = "xls";
                }
                Inport_fileName=filename;




            }
        }

        private void b_in_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dT_ddsj_cs_Enter(object sender, EventArgs e)
        {
            common_file.common_app.GetCurrentTime(sender, e);
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_selectFile_Click_1(object sender, EventArgs e)
        {

        }

        private void b_in_Click_1(object sender, EventArgs e)
        {

        }
    }
}