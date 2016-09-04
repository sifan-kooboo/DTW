using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace jdgl_res_head_service.Qyddj
{
    public class web_skyd
    {
        //供特定门店下载预定中心的信息
        public DataSet yddj_download_DS(string qymc, out  int rows, out  bool status)
        {
            DataSet DS_skyd = new DataSet();
            rows = 0;
            status = false;
            BLL.Web_skyd B_Web_skyd = new BLL.Web_skyd();

            DS_skyd = B_Web_skyd.GetList("qymc='" + qymc + "'  and  sfqr='1'  and  shsc='0'");
            if (DS_skyd != null)
            {
                rows = DS_skyd.Tables[0].Rows.Count;
                status = true;
            
            }
            return DS_skyd;
        }

        //Web_Qskyd_fjrb供特定门店下载预定房间房型的信息
        public DataSet WebQskyd_fjrb_DS(string qymc,string lsbh,out int rows)
        {
            DataSet DS_WebQskyd_fjrb = new DataSet();
            rows = 0;
            BLL.Web_Qskyd_fjrb B_Web_Qskyd_fjrb = new BLL.Web_Qskyd_fjrb();
            DS_WebQskyd_fjrb = B_Web_Qskyd_fjrb.GetList("qymc='" + qymc + "' and lsbh='"+lsbh+"'");
            if (DS_WebQskyd_fjrb != null)
            {
                rows = DS_WebQskyd_fjrb.Tables[0].Rows.Count;

            }
            return DS_WebQskyd_fjrb;
        }
        //向InsertToQyddjlsbhbg_yy添加数据
        public string InsertToQyddjlsbhbg_yy(string yclsbh, string bdlsbh, string bdyydh)
        {
            string ss = common_file.common_app.get_failure;
            SqlParameter[] sp ={ 
            new SqlParameter("@yclsbh",SqlDbType.VarChar),
            new SqlParameter("@bdlsbh",SqlDbType.VarChar),
            new SqlParameter("@bdyydh",SqlDbType.VarChar),
            new SqlParameter("@rows",SqlDbType.Int)
            };
            sp[0].Value = yclsbh;
            sp[1].Value = bdlsbh;
            sp[2].Value = bdyydh;
            sp[3].Direction = ParameterDirection.Output;
            DbHelperSQLP helperSQLP = new DbHelperSQLP();
            helperSQLP.RunProcedure("InsertToQyddjlsbhbg_yy", sp);
            int result = Convert.ToInt32(sp[3].Value.ToString());
            if (result > 0)
            {
                ss = common_file.common_app.get_suc;
            }
            return ss;
        }

        //修改Web_Qskyd_fjrb订单状态shsc=1
        public string Web_Qskyd_fjrb_Updateshsc(int id)
        {
            string ss = common_file.common_app.get_failure;
            SqlParameter[] sp ={ 
            new SqlParameter("@id",SqlDbType.Int)
   
           
            };
            sp[0].Value = id;
            int result = result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Web_Qskyd_fjrb_Updateshsc", sp);
            if (result > 0)
            {
                ss = common_file.common_app.get_suc;
            }
            return ss;
        }


        //门店下载网上预定数据后，修改订单状态
        public string yddj_ydownloadDataStatus(DataSet DS_yddj_downloadData)
        {
            string ss = common_file.common_app.get_failure;

            BLL.Web_skyd B_Web_skyd = new BLL.Web_skyd();
            Model.Web_skyd M_Web_skyd = new Model.Web_skyd();
            foreach (DataRow dr in DS_yddj_downloadData.Tables[0].Rows)
            {
                string id = dr[0].ToString();
                M_Web_skyd.id = Convert.ToInt32(id);
                int result = 0;
                //执行存储过程修改状态
               
                SqlParameter[] pa ={ new SqlParameter("@id", SqlDbType.VarChar) };
                pa[0].Value = dr[0].ToString();

                result= SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "ydownloadDataStatus", pa);
                //成功继续
                if (result > 0)
                {
                    ss = common_file.common_app.get_suc;
                    continue;
                }
                //否则中断
                else
                {
                    ss = common_file.common_app.get_failure;
                    break;
                }
            }
            return ss;
        }
    }
}
