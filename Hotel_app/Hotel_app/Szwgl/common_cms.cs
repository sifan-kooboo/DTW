using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace Hotel_app.Szwgl
{
    //帐务里面有用到的右键菜单类(根据不同的窗体，以及不同的结帐状态，动态加载加成)
    class common_cms
    {
        string jjTyp = "";//动态事件中用到
        public string lsbh="";//帐务的临时编号
        public string id_app="";//帐务标识符
        string sk_tt = "";//标示是sk,tt
        string jzzt = "";//结帐主体
        string jzbh = "";//结帐编号
        DataSet ds_temp;

        //以下参数用于操作后的刷新
        //string jjzt_type,string lsbh, string sk_tt,string openFrom

        string openFrom = "";
        //返回右键菜单(jjType是结帐的类型，lsbh，id_app指当前那条记录的)


        //退订的功能:
        private  void Tsmi_tuiding_Click(object sender, EventArgs e)
        {
            BLL.Syjcz B_Syjcz = new Hotel_app.BLL.Syjcz();
            ds_temp = B_Syjcz.GetList("id>=0 and yydh='" + common_file.common_app.yydh + "'  and id_app='" + this.id_app + "'");
            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
            {
                if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你真的要退订此款项嘛？") == true)
                {
                    string temp = ds_temp.Tables[0].Rows[0]["xfrb"].ToString();
                    if (temp.Equals(common_file.common_app.dj_ysk))//付款方式为预授权(包含押金和预授权)
                    {
                        if (del_ysq(ds_temp.Tables[0].Rows[0]["id"].ToString()) == common_file.common_app.get_suc)
                        {
                            common_file.common_form.ShowFrm_Szwcz_new(jjTyp, lsbh,"", sk_tt, openFrom);
                        }
                    }
                    else
                    {
                        common_file.common_app.message_box_show_select(common_file.common_app.message_title, "此功能不能应用于此项");
                    }
                }
            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "此功能不能应用于此项");
            }
        }



        //记转挂。挂转记
        private  void Tsmi_changeType_Click(object sender, EventArgs e)
        {
            if (openFrom == "Sjjzwll")
            {
                GetZwChangType(this.jjTyp);
            }
        }

        //退房房间信息
        private  void  Tsmi_zwDetail_Click(object sender, EventArgs e)
        {
            if (lsbh != ""&&jzbh.Trim()!="")
            {
                Szw_tfInfo Frm_szw_tfInfo = new Szw_tfInfo();
                Frm_szw_tfInfo.InitalApp(lsbh, sk_tt);
                Frm_szw_tfInfo.StartPosition = FormStartPosition.CenterScreen;
                Frm_szw_tfInfo.ShowDialog();
            }
        }

        //记挂互转(这个只能是在记帐，挂帐完成之后才能转,还要传一个openForm过来识别)
        private void GetZwChangType(string _jjType)
        {
            string ss_temp = "";
            if (jjTyp == common_file.common_jzzt.czzt_jz)
            {
                ss_temp = "你真的要转成挂帐嘛？";
            }
            else
            { ss_temp = "你真的要转成记帐嘛？"; }
                
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, ss_temp) == true)
                {
                    if (jjTyp == common_file.common_jzzt.czzt_jz)
                    {
                        Sjzcz Frm_Sjzcz = new Sjzcz(); 
                        Frm_Sjzcz.initalApp(common_file.common_jzzt.czzt_gz,lsbh,"", sk_tt,true,"0");
                        Frm_Sjzcz.StartPosition = FormStartPosition.CenterScreen;
                        if (Frm_Sjzcz.ShowDialog() == DialogResult.OK)
                        {
                            jzzt = Frm_Sjzcz.get_jzzt;
                        }
                        else
                        {
                            common_file.common_app.Message_box_show(common_file.common_app.message_title, "请选择挂账单位");
                            return ;
                        }
                    }
                    common_file.common_app.get_czsj();
                    //lsbh, qymc, yydh, jzzt, czy, syzd, czsj, jjType, xxzs
                    string  url = common_file.common_app.service_url;
                    url += "Szwgl/Szwgl_app.asmx";
                    object[] args_1 = new object[9];
                    args_1[0] = lsbh;
                    args_1[1] = common_file.common_app.qymc;
                    args_1[2] = common_file.common_app.yydh;
                    args_1[3] = jzzt;
                    args_1[4] = common_file.common_app.czy;
                    args_1[5] = common_file.common_app.syzd;
                    args_1[6] = DateTime.Now.ToString();
                    args_1[7] = jjTyp;
                    args_1[8] = common_file.common_app.xxzs;

                    Hotel_app.Server.Szwgl.Szw_ChangZwType Szw_ChangZwType_services = new Hotel_app.Server.Szwgl.Szw_ChangZwType();
                    string result_temp = Szw_ChangZwType_services.Szw_GetChangZwType(args_1[0].ToString(), args_1[1].ToString(), args_1[2].ToString(), args_1[3].ToString(), args_1[4].ToString(), args_1[5].ToString(), args_1[6].ToString(), args_1[7].ToString(), args_1[8].ToString(), args_1[9].ToString());
                    //object result_temp = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Fun_Szw_GetChangZwType", args_1);
                    if (result_temp != null && result_temp == common_file.common_app.get_suc)
                    {
                        string ss = "";
                        if (jjTyp == common_file.common_jzzt.czzt_gz)
                        { ss = "挂帐转记帐成功"; }
                        if (jjTyp == common_file.common_jzzt.czzt_jz)
                        { ss = "记帐转挂帐成功"; }
                        common_file.common_app.Message_box_show(common_file.common_app.message_title, ss);
                    }
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    return;
                }
        }

        //退订预授权
        public  static  string del_ysq(string id)//ID为押金或者预授权的ID
        {
            common_file.common_app.get_czsj();
            string s = common_file.common_app.get_failure;
            //id, yydh, qymc, id_app, jzbh, lsbh, krxm, fjrb, fjbh, sktt, xfrq, 
            //xfsj, czy, xfdr, xfrb, xfxm, xfbz, xfzy, fkfs, xfje, sjxfje, czy_bc, syzd, add_edit_delete, xxzs
            string url = common_file.common_app.service_url + "Szwgl/Szwgl_app.asmx";
            object[] args = new object[26];
            args[0] = id;
            args[1] = common_file.common_app.yydh;
            args[2] = common_file.common_app.qymc;
            args[3] = "";
            args[4] = "";//结帐前jzbh为空
            args[5] = "";
            args[6] ="";
            args[7] = "";
            args[8] = "";
            args[9] = "";
            args[10] = DateTime.Now.ToString("yyyy-MM-dd");
            args[11] = DateTime.Now.ToString();
            args[12] = common_file.common_app.czy;
            args[13] = common_file.common_app.fkdr;
            args[14] = common_file.common_app.dj_ysk;
            args[15] = "";
            args[16] = "";
            args[17] = "";
            args[18] = "";
            args[19] = "";
            args[20] = "";
            args[21] = common_file.common_app.czy_bc;
            args[22] = common_file.common_app.syzd;
            args[23] =common_file.common_app.get_delete;//删除
            args[24] = common_file.common_app.xxzs;
            args[25] = DateTime.Now.ToString();

            Hotel_app.Server.Szwgl.Syjcz Syjcz_services = new Hotel_app.Server.Szwgl.Syjcz();
            string result = Syjcz_services.Syjcz_add_edit(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(), args[14].ToString(), args[15].ToString(), args[16].ToString(), args[17].ToString(), args[18].ToString(), args[19].ToString(), args[20].ToString(), args[21].ToString(), args[22].ToString(), args[23].ToString(), args[24].ToString(), args[25].ToString());
            //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Syjcz_add_edit", args);
            if (result != null && result== common_file.common_app.get_suc)
            {
                //common_file.common_app.Message_box_show(common_file.common_app.message_title, "退订成功,可以继续结帐操作");
                s = common_file.common_app.get_suc;
            }
            Cursor.Current = Cursors.Default;
            return s;
        }

        //以下为帐务浏览部分
        //帐务处理
        private void Tsmi_zwcl_Click(object sender, EventArgs e)
        {
            common_file.common_app.Message_box_show(common_file.common_app.message_title, "帐务浏览啊");
            common_file.common_form.ShowFrm_Szwcz_new(jjTyp, lsbh,"", sk_tt, openFrom);
        }
        //呆帐删除
        private void Tsmi_dzsc_Click(object sender, EventArgs e)
        {
            if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你确定要删除此记录嘛？") == true)
            {
                if (id_app.Trim() != "")
                {
                    //将当前lsbh下的所有帐务都删除掉
                }
            }
        }
        //凭证备注
        private void Tsmi_fpbz_Click(object sender, EventArgs e)
        {
            common_file.common_app.Message_box_show(common_file.common_app.message_title, "凭证备注");
        }

        //批量结帐(记帐，挂帐的成批结,注意，只能选择Jzzt是同一个人的，不相同的不能同时处理)
        private void Tsmi_cpjz_Click(object sender, EventArgs e)
        {
            Szw_pljz Frm_pljz_new = new Szw_pljz();
            Frm_pljz_new.Show();
        }

        //窗体刷新
        //private void refresh_frms()
        //{
        //    if (common_file.common_form.Szwcz_new != null)
        //    {
        //        common_file.common_form.Szwcz_new.InitalApp(jjTyp, lsbh,"", sk_tt, openFrom);
        //    }
        //    if (jzbh.Trim() == "")
        //    {
        //        if (common_file.common_form.Szwcl_new != null)
        //        {
        //            common_file.common_form.Szwcl_new.Inital_app(lsbh, sk_tt, common_file.common_app.czy);
        //            common_file.common_form.Szwcl_new.BindData(lsbh, common_file.common_app.czy);
        //        }
        //    }
        //}
    }
}
