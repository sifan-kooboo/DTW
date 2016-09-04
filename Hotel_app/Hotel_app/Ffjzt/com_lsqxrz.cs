using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Hotel_app.Ffjzt
{
    //此类用于前厅临时取消入住用的(注意,一定要求其填写取消原因.如果有任何消费产生,则不能操作)
    //开单一小时之内才可以使用临时取消,超过一小时则不行!
   public  class com_lsqxrz
    {

       public void lsqxrz(string lsbh,string czsj)
       {
           BLL.Common B_common = new Hotel_app.BLL.Common();
           string id_del = "-1";
           string url = common_file.common_app.service_url;
           string get_qxyy="";
           string krxm = "";
           string czsj_0 = "";
           DataSet ds_temp_0 = null;





           DataSet ds = B_common.GetList(" select * from View_Qskzd ", " id>=0  and yydh='" + common_file.common_app.yydh + "' and  lsbh='" + lsbh + "' and  main_sec='" + common_file.common_app.main_sec_main + "'");
           if (ds != null && ds.Tables[0].Rows.Count > 0)
           {
               id_del = ds.Tables[0].Rows[0]["id"].ToString();
               krxm = ds.Tables[0].Rows[0]["krxm"].ToString();
               czsj_0 = ds.Tables[0].Rows[0]["ddsj"].ToString();

               if ((DateTime.Parse(czsj_0).AddHours(1.0) < DateTime.Parse(czsj)))
               {
                   common_file.common_app.Message_box_show(common_file.common_app.message_title,"你好,临时取消只应用于开单一小时之内的主单!");
                   return;
               }


               url = common_file.common_app.service_url;
               if (int.Parse(id_del) >= 0)
               {
                   ds_temp_0 = B_common.GetList("select id from Syjcz", "lsbh='" + lsbh + "'");
                   if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                   {
                       common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，客人" + krxm + "有产生预收款了，如果确实要删除请先退还预收款！"); return;
                   }
                   ds_temp_0 = B_common.GetList("select id from Szwmx", "lsbh='" + krxm + "'");
                   if (ds_temp_0 != null && ds_temp_0.Tables[0].Rows.Count > 0)
                   {
                       common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，客人" + krxm + "有产生消费了，不能临时取消,若要退房,请直接做结账处理！"); return;
                   }
                   if (common_file.common_app.message_box_show_select(common_file.common_app.message_title, "你真的要临时取消此主单记录嘛？") == true)
                   {
                       Qyddj.Q_bz_input Q_bz_input_new = new Hotel_app.Qyddj.Q_bz_input();
                       Q_bz_input_new.Text = "请输入操作理由";
                       Q_bz_input_new.Left = 200;
                       Q_bz_input_new.Top = 150;
                       if (Q_bz_input_new.ShowDialog() == DialogResult.OK)
                       {
                           get_qxyy = Q_bz_input_new.get_bz;
                           if (get_qxyy.Trim() == "")
                           { common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起,散客临时取消必须完整填写取消原因,请正确填写取消原因!");
                           return;
                       }
                           
                       }
                       else
                       {
                           return;
                       }
                       Q_bz_input_new.Dispose();


                       common_file.common_app.get_czsj();



                       //url = common_file.common_app.service_url;
                       //url += "Qyddj/Qyddj_app.asmx";
                       object[] args_1 = new object[8];
                       args_1[0] = new string[] { id_del };
                       args_1[1] = "sc";
                       args_1[2] = common_file.common_yddj.yddj_qx;
                       args_1[3] = "临时取消,操作员为:"+common_file.common_app.czy+",操作时间为:"+DateTime.Now.ToString()+",具体原因为:"+get_qxyy;
                       args_1[4] = "";
                       args_1[5] = common_file.common_app.czy;
                       args_1[6] = czsj;
                       args_1[7] = common_file.common_app.xxzs;

                       Hotel_app.Server.Qyddj.Qyddj_add_edit_delete  Qyddj_add_edit_delete_services=new Hotel_app.Server.Qyddj.Qyddj_add_edit_delete();
                       string result_temp = Qyddj_add_edit_delete_services.delete_sk_multi(new string[] { id_del },"sc",common_file.common_yddj.yddj_qx,
                       "临时取消,操作员为:"+common_file.common_app.czy+",操作时间为:"+DateTime.Now.ToString()+",具体原因为:"+get_qxyy,
                       "",common_file.common_app.czy, czsj,common_file.common_app.xxzs);

                       //object result_temp = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "delete_sk_multi", args_1);
                       if (result_temp != null && result_temp== common_file.common_app.get_suc)
                       {
                           common_file.common_app.Message_box_show(common_file.common_app.message_title, "临时取消散客入住成功!");
                       }
                       else
                       {
                           common_file.common_app.Message_box_show(common_file.common_app.message_title, "临时取消失败!");

                       }
                   }
               }

           }
 
       }
    }
}
