using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.Qyddj
{

    public class Qttyd_fjrb_add_edit_delete
    {
        Model.Qttyd_mainrecord M_Qttyd_mainrecord = new Model.Qttyd_mainrecord();
        BLL.Qttyd_mainrecord B_Qttyd_mainrecord = new BLL.Qttyd_mainrecord();
        Qttyd_add_edit_delete Qttyd_add_edit_delete_new = new Qttyd_add_edit_delete();

        public string Qttyd_fjrb_add_edit_delete_app(int id, string yydh, string qymc, string lsbh, string krxm, string sktt, string yddj, string fjrb, string fjbh, DateTime ddsj, DateTime lksj, Decimal lzfs, string shqh, decimal fjjg, decimal sjfjjg, string yh, decimal yhbl, string bz, bool istop, bool isselect, bool shsc, string czy, DateTime czsj, string cznr, bool sdcz, string zyzt, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            if (sktt == common_file.common_sktt.sktt_tt || sktt == common_file.common_sktt.sktt_hy)
            {
                #region  团体预定新增
                if (add_edit_delete == common_file.common_app.get_add)
                {
                    
                    //1.新增房类记录
                    if (yddj == common_file.common_yddj.yddj_yd)
                    {

                        
                    }


                }

                #endregion



                #region   团体预定修改

                else
                    if (add_edit_delete == common_file.common_app.get_edit)
                    {

                    }

                #endregion

            }
            return s;
 
        }
    }

}
