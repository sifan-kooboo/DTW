using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_app.common_file
{
   public  class Common_commonFunction
    {
       //通过房间类型的ID获取主单ID
       public static int GetMainRecordIDByFjrbID(string id)
       {
           int result = 0;
           string lsbh = "";
           BLL.Qskyd_fjrb  B_Qskyd_fjrb=new Hotel_app.BLL.Qskyd_fjrb();
           BLL.Qskyd_mainrecord  B_Qskyd_mainrecord=new Hotel_app.BLL.Qskyd_mainrecord();
           if (B_Qskyd_fjrb.GetModel(int.Parse(id))!=null)
           {
               lsbh = B_Qskyd_fjrb.GetModel(int.Parse(id)).lsbh;
           }
           if (B_Qskyd_mainrecord.GetModelList("lsbh='" + lsbh + "'").Count > 0)
           {
               result = B_Qskyd_mainrecord.GetModelList("lsbh='" + lsbh + "'")[0].id;
           }
           return result;
       }

       //主单的删除操作  主单id，调用的URL
       public static string Delete_MainRecord(string id,string url)
       {
           string s=common_app.get_failure;
           //执行删除
           string[] args = new string[59];
           args[0] = id.ToString();
           args[1] = "";
           args[2] = "";
           args[3] = "";
           args[4] = "";
           args[5] = "";
           args[6] = "";
           args[7] = "";
           args[8] = "";
           args[9] = "";
           args[10] = "";
           args[11] = "";
           args[12] = "";
           args[13] = "";
           args[14] = "";
           args[15] = "";
           args[16] = "";
           args[17] = "";
           args[18] = "";
           args[19] = "";
           args[20] = "";
           args[21] = "";
           args[22] = "";
           args[23] = "";
           args[24] = "";
           args[25] = "";
           args[26] = "";
           args[27] = "";
           args[28] = "";
           args[29] = "";
           args[30] = "";
           args[31] = "";
           args[32] = "";
           args[33] = "";
           args[34] = "";
           args[35] = "";
           args[36] = "";
           args[37] = "";
           args[38] = "";
           args[39] = "";
           args[40] = "";
           args[41] = "";
           args[42] = "";
           args[43] = "";
           args[44] = "";
           args[45] = "";
           args[46] = "";
           args[47] = "";
           args[48] = "";
           args[49] = "";
           args[50] = "";
           args[51] = "";
           args[52] = "";
           args[53] = "";
           args[54] = "";
           args[55] = "";
           args[56] = "";
           args[57] = common_file.common_app.get_delete;
           args[58] = "";

           Hotel_app.Server.Qyddj.Qyddj_add_edit_delete Qyddj_add_edit_delete_services = new Hotel_app.Server.Qyddj.Qyddj_add_edit_delete();
           string result = Qyddj_add_edit_delete_services.Qskdj_add_edit_delete(args[0], args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(),
               args[8].ToString(), args[9].ToString(), args[10].ToString(), args[11].ToString(), args[12].ToString(), args[13].ToString(), args[14].ToString(), args[15].ToString(), args[16].ToString(), args[17].ToString(), args[18].ToString(), args[19].ToString(), args[20].ToString(),
               args[21].ToString(), args[22].ToString(), args[23].ToString(), args[24].ToString(), args[25].ToString(), args[26].ToString(), args[27].ToString(), args[28].ToString(), args[29].ToString(), args[30].ToString(), args[31].ToString(), args[32].ToString(), args[33].ToString(),
               args[34].ToString(), args[35].ToString(), args[36].ToString(), args[37].ToString(), args[38].ToString(), args[39].ToString(), args[40].ToString(), args[41].ToString(), args[42].ToString(), args[43].ToString(), args[44].ToString(), args[45].ToString(),
               args[46].ToString(), args[47].ToString(), args[48].ToString(), args[49].ToString(), args[50].ToString(), args[51].ToString(), args[52].ToString(), args[53].ToString(), args[54].ToString(), args[55].ToString());


           //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Qskdj_add_edit_delete", args);
           if(result==common_app.get_suc)
           {s=common_app.get_suc;}
           return s;
       }


       //用于删除fjrb表里面没有排房号的记录
       public static string Delete_Qskyd_fjrb(string id, string url)
       {
           string s = common_app.get_failure;
           //执行删除
           object[] args = new object[26];
           args[0] =int.Parse(id);
           args[1] = "";
           args[2] = "";
           args[3] = "";
           args[4] = "";
           args[5] = "";
           args[6] = "";
           args[7] = "";
           args[8] = "";
           args[9] = DateTime.Now;
           args[10] = DateTime.Now;
           args[11] = decimal.Parse("0");
           args[12] = "";
           args[13] = decimal.Parse("0");
           args[14] = decimal.Parse("0");
           args[15] = "";
           args[16] = decimal.Parse("0");
           args[17] = "";
           args[18] = false;
           args[19] = false;
           args[20] = false;
           args[21] = "";
           args[22] = common_file.common_app.get_delete;// DateTime.Now;
           args[23] = common_app.xxzs;
           args[24] = false;
           args[25] ="0";
           //args[26] = common_file.common_app.get_delete;
          // args[27] = "";

           Hotel_app.Server.Qyddj.Qskyd_fjrb_add_edit_delete  Qfae_services = new Hotel_app.Server.Qyddj.Qskyd_fjrb_add_edit_delete();

           string result = Qfae_services.Qskyd_fjrb_add_edit_delete_app(args[0].ToString(), args[1].ToString(), args[2].ToString(), args[3].ToString(), args[4].ToString(), args[5].ToString(), args[6].ToString(), args[7].ToString(), args[8].ToString(), DateTime.Parse(args[9].ToString()), DateTime.Parse(args[10].ToString()), decimal.Parse(args[11].ToString()), args[12].ToString(), decimal.Parse(args[13].ToString()),
               decimal.Parse(args[14].ToString()), args[15].ToString(),decimal.Parse(args[16].ToString()), args[17].ToString(), args[18].ToString(), DateTime.Parse(args[19].ToString()), args[20].ToString(), args[21].ToString(), args[22].ToString(), args[23].ToString(), args[24].ToString(),decimal.Parse(args[25].ToString()));
           //object result = Hotel_app.我的替换DynamicWebServiceCall.InvokeWebService(url, "Qskyd_fjrb_add_edit_delete_app", args);
           if (result == common_app.get_suc)
           { s = common_app.get_suc; }
           return s;
       }
    }
}
