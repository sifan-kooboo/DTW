using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Hotel_app.Yyxzx
{
    public partial class Yxydw_add_edit : Form
    {
        public string Yxydw_id = "";
        public string judge_add_edit = common_file.common_app.get_add;
        public string savePath;
        public string dwrx = "";
        public String strxyh="";
        public int strid =0;
        Model.Yxydw mode_xydw = new Hotel_app.Model.Yxydw();
        BLL.Yxydw bll_xydw = new Hotel_app.BLL.Yxydw();
        public string add_edit = "";
        public string xygz = "";
         #region 自定义方法

       
        /// <summary>
        /// 从管理界面过的
        /// </summary>
        /// <param name="xygz_flage">协议单位||挂账单位</param>
        /// <param name="add_edit_flage">新增</param>
        public Yxydw_add_edit(int id, string xygz_flage, string add_edit_flage)
        {

            xygz = xygz_flage;
            add_edit = add_edit_flage;
            InitializeComponent();
            InitEvents();
            strid = id;
            FormText();
            if (add_edit == common_file.common_app.get_add)
            {
                this.cB_krly.Text = common_file.common_xydw.krly_xydw;
                //tB_xyh_inner.Enabled = true;
                //tB_xydw.Enabled = true;
            }
            else if(add_edit==common_file.common_app.get_edit)
            {
                mode_xydw = bll_xydw.GetModel(id);
                this.cB_krly.Text = mode_xydw.krly;
                cB_xyrx.Text = mode_xydw.xyrx;
                //tB_xyh_inner.Enabled = false;
                //tB_xydw.Enabled = false;
            

            }
            Bindkrly();
            ShowImage();


        }
        //加载信息时根据 yddj和add_edit来设置窗体的Text
        public void FormText()
        {
          
            
            if (xygz == common_file.common_xydw.krly_xydw)
            {
                this.Text = common_file.common_xydw.krly_xydw + "设置";

            }
            if (xygz == common_file.common_xydw.xyrx_gzdw)
            {
                this.Text = common_file.common_xydw.xyrx_gzdw+"设置";
               
            }
        }
        #endregion
        public Yxydw_add_edit()
        {
            InitializeComponent();
            InitEvents();
            ShowImage();
       
        }
        private void ShowImage()
        {
            if (strid > 0)
            {
                //调用方法如：ShowImage("select Photo from UserPhoto where UserNo='" + userno +"'");
            
                mode_xydw = bll_xydw.GetModel(strid);
                if (mode_xydw.sign_image != null)
                {
                    byte[] b = (byte[])mode_xydw.sign_image;
                    if (b.Length > 0)
                    {
                        MemoryStream stream = new MemoryStream(b, true);
                        stream.Write(b, 0, b.Length);
                        pictureBox.Image = new Bitmap(stream);
                        stream.Close();
                    }
                }
            }
        }


        private void InitEvents()
        {
            buttonCaptureImage.Click += delegate(object sender, EventArgs e)
           {

               CSharpWin.CaptureImageTool capture = new CSharpWin.CaptureImageTool();
               if (capture.ShowDialog() == DialogResult.OK)
               {
                   Image image = capture.Image;
                   pictureBox.Width = image.Width;
                   pictureBox.Height = image.Height;
                   pictureBox.Image = image;
                   savePath=Application.StartupPath+"\\"+DateTime.Now.ToShortDateString().Replace('/','-')+".jpg";
                   image.Save(savePath);
               }

               if (!Visible)
               {
                   Show();
               }
           };
        }

        private void display_new_commonform_1(string judge_type_0,TextBox TB_ls)
        {
            common_file.common_app.get_czsj();
            Xxtsz.X_common_one X_common_one_new = new Hotel_app.Xxtsz.X_common_one();
            X_common_one_new.judge_type = judge_type_0;
            X_common_one_new.Left = common_file.common_app.x();
            X_common_one_new.Top = common_file.common_app.y();
            if (X_common_one_new.ShowDialog() == DialogResult.OK)
            {
                TB_ls.Text = X_common_one_new.get_value;
            }
            X_common_one_new.Dispose();
            TB_ls.Focus();
            Cursor.Current = Cursors.Default;

        }
        private void b_xsy_Click(object sender, EventArgs e)
        {
          
            display_new_commonform_1("Yxsy",tB_xsy);

        }
        private bool get_judge_void_local()
        {
            common_file.common_app.get_czsj();
            bool bl_temp = false;
            if (common_file.common_app.get_judge_void(tB_xyh_inner, "Y_xyh", "对不起，协议编号不能为空！") == true)
                if (common_file.common_app.get_judge_void(tB_xydw, "Y_xydw", "对不起，协议单位不能为空！") == true)
                    if (common_file.common_app.get_judge_void(tB_nxr, "Y_nxr", "对不起，联系人不能为空！") == true)
                        if (common_file.common_app.get_judge_void(tB_krdh, "Y_krdh", "对不起，联系电话不能为空！") == true)
                            if (common_file.common_app.get_judge_void(tB_qydz, "X_krdz", "对不起，联系地址不能为空！") == true)
                                if (common_file.common_app.get_judge_void(tB_xsy, "Y_xsy", "对不起，销售员不能为空！") == true)
                                                        bl_temp = true;
            return bl_temp;

        }
           //保存主单
        private void SaveNew_xydw()
        {
            int judge_save = 3;//3保存，其余不保存
            judge_save = common_file.common_app.get_judge_repeat("Yxydw", "xydw", "协议单位已经存在", tB_xydw.Text, judge_add_edit, Yxydw_id);
            if (judge_save == 3)
            {
                mode_xydw = bll_xydw.GetModel(strid);
                byte[] imageb = new byte[0];
                if (savePath != "" && savePath !=null)
                {
                    FileStream fs = File.OpenRead(savePath);
                    imageb = new byte[fs.Length];
                    fs.Read(imageb, 0, imageb.Length);
                }
                else if(strid>=0)
                {
                    if (mode_xydw!=null&&mode_xydw.sign_image != null)
                    {
                        imageb = mode_xydw.sign_image;
                    }
                }
                if (judge_add_edit == common_file.common_app.get_add)
                {
                    strxyh = common_file.common_ddbh.ddbh("xydw", "xydwdate", "xydwcounter", 6);
                }
                //else
                //{
                //    //if (common_file.common_xydw.Isyydh(mode_xydw.yydh))
                //    //{
                //    //    strxyh = mode_xydw.xyh;


                //    //}
                //    //else
                //    //{

                //    //    common_file.common_app.Message_box_show(common_file.common_app.message_title, "不是本店的协议单位不能修改，请联系管理人员！");
                //    //    return;

                //    //}

                //}

               
                string stryydh=common_file.common_app.yydh;
                string strqymc=common_file.common_app.qymc;

                string url = common_file.common_app.service_url + "Yyxzx/Yyxzx_app.asmx";
                object[] args = new object[21];
                args[0] = Yxydw_id;
                args[1] = stryydh;
                args[2] = strqymc;
                args[3] = tB_zjm.Text.Trim().Replace("'", "-");
                args[4] = cB_xyrx.Text.Trim().Replace("'", "-");
                args[5] = tB_xyh_inner.Text.Trim().Replace("'", "-");
                args[6] = tB_xydw.Text.Trim().Replace("'", "-");
                args[7] = tB_nxr.Text.Trim().Replace("'", "-");
                args[8] = tB_krdh.Text.Trim().Replace("'", "-");
                args[9] = tB_Email.Text.Trim().Replace("'", "-");
                args[10] = tB_krcz.Text.Trim().Replace("'", "-");
                args[11] = tB_qydz.Text.Trim().Replace("'", "-");
                args[12] = tB_xsy.Text.Trim().Replace("'", "-");
                args[13] = tB_bz.Text.Trim().Replace("'", "-");
                args[14] = cB_krly.Text.Trim().Replace("'", "-");
                args[15] = imageb;
                args[16] = xygz;//单位类型
                args[17] = strxyh;
                args[18] = judge_add_edit;
                args[19] = common_file.common_app.xxzs;
                args[20] = tb_sxed.Text.Trim().Replace("'", "-");

                Hotel_app.Server.Yyxzx.Yxydw Yxydw_services = new Hotel_app.Server.Yyxzx.Yxydw();
                string result = Yxydw_services.Yxydw_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(), args[14].ToString(), imageb, args[16].ToString(), args[17].ToString(), args[18].ToString(), args[19].ToString(), args[20].ToString());                            
                //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Yxydw_add_edit", args);
                if (result!=null&&result.ToString() == common_file.common_app.get_suc)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "保存成功！");
                    if (judge_add_edit == common_file.common_app.get_add)
                    {
                        common_file.common_czjl.add_czjl(stryydh, strqymc, common_file.common_app.czy, "添加协议单位", ""+strxyh+"", "", DateTime.Now);
                        common_file.common_form.Yxydw_browse_new.InitializeApp(xygz);
                        tB_xydw.Text = "";
                        tB_xydw.Focus();
                        tB_zjm.Text = "";
                        tB_Email.Text = "";
                        tB_krcz.Text = "";
                        tB_krdh.Text = "";
                        tB_nxr.Text = "";
                        tB_qydz.Text = "";
                        tB_xsy.Text = "";
                        tB_xyh_inner.Text = "";
                        tb_sxed.Text = "0";
                    }
                    else if (judge_add_edit == common_file.common_app.get_edit)
                    {
                        common_file.common_czjl.add_czjl(stryydh, strqymc, common_file.common_app.czy, "修改协议单位", "" + strxyh + "", "", DateTime.Now);
                        //common_file.common_form.Yxydw_browse_new.InitializeApp(xygz);
                        common_file.common_form.Yxydw_browse_new.refresh_app();
                        this.Close();
                    }
                }
                else
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "操作失败！");

            }
 
        }
        private void b_save_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (get_judge_void_local() == true)
            {
                if (Maticsoft.Common.PageValidate.IsDecimal(tb_sxed.Text) || Maticsoft.Common.PageValidate.IsNumber(tb_sxed.Text))
                {
                    SaveNew_xydw();
                }
 
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ofd_photo.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";


            if (this.ofd_photo.FileName != null && ofd_photo.ShowDialog() == DialogResult.OK)
            {
                string ss = ofd_photo.FileName;
              
                Random rdm = new Random();
                int num = rdm.Next(0, 4);
                string saveFileName = Application.StartupPath + "\\image\\" + num.ToString() + ".jpg";
                
                try
                {
                    Yyxzx.Frm_test F_test_TEMP = new Frm_test(ss);
                    F_test_TEMP.Show();
                    System.IO.File.Copy(ss, saveFileName, true);
                   
                }
                catch (Exception ee)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "文件保存出错，请检查磁盘的读写权限");
                }
            }
           



        }

        private void Yxydw_add_edit_Load(object sender, EventArgs e)
        {
            //cB_xyrx.Items.Add(common_file.common_xydw.xyrx_gzdw);
            //cB_xyrx.Items.Add(common_file.common_xydw.krly_xydw);
      

        }
        private void Bindkrly()
        {
            cB_krly.Items.Clear();
             Model.Xkrly M_krly = new Model.Xkrly();
             BLL.Xkrly B_krly = new BLL.Xkrly();
             List<Model.Xkrly> list = B_krly.GetModelList("");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    cB_krly.Items.Add(list[i].krly.ToString());
                }
            }
        }
      

       
       

    }
}