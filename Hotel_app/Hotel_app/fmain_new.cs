using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Hotel_app
{
    class fmain_new
    {
        public Fmain Fmain = null;
        public void CloseClick(object obj, EventArgs ea)
        {
            //MessageBox.Show("Closed was Clicked");
        }

        public void TitleClick(object obj, EventArgs ea)
        {
            //MessageBox.Show("Title was Clicked");
        }

        public void ContentClick(object obj, EventArgs ea)
        {
            DataSet ds_0 = null;
            DataSet ds_1 = null;
            BLL.Common B_common = new Hotel_app.BLL.Common();
            ds_0 = B_common.GetList(" select * from  View_Qskzd", " id>=0  and  ddyy='" + common_file.common_app.ydzx_flag + "' and  yddj='" + common_file.common_yddj.yddj_yd + "' and shsc=1 ");
            ds_1 = B_common.GetList(" select   * from View_Qttzd ", " id>=0  and ddyy='" + common_file.common_app.ydzx_flag + "'  and yddj='" + common_file.common_yddj.yddj_yd + "'  and shsc=1  ");

            if ((ds_0 != null && ds_0.Tables[0].Rows.Count > 0) || (ds_1 != null && ds_1.Tables[0].Rows.Count > 0))
            {
                Qyddj.Q_ydzx_notice noticeNew = new Hotel_app.Qyddj.Q_ydzx_notice();
                noticeNew.Show();
            }

            //MessageBox.Show("Content was Clicked" + " " + obj.ToString());

        }

        public void ContentClick_GetNewVersion(Object obj, EventArgs ea)
        {
            updateFrm f = new updateFrm(Fmain);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }
    }
}
