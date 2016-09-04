using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.DBUtility;
using System.Data;
namespace Hotel_app.common_file
{
    public static class common_xydw
    {
        public static string krly_xydw = "协议单位";
        public static string xyrx_gzdw = "挂账单位";


        public static string UpdateRx(int id)
        {
            string s = common_app.get_failure;
            string strSql = "update Yxydw set rx='" + xyrx_gzdw + "' where id=" + id + " ";
            DbHelperSQL.ExecuteSql(strSql);
            s = common_app.get_suc;
            return s;

        }
        //判断yydh是否等于本地yydh
        public static bool Isyydh(string yydh)
        {
            bool f = false;
            BLL.Xqyxx B_Yxydw = new Hotel_app.BLL.Xqyxx();
            Model.Xqyxx M_Yxydw = new Hotel_app.Model.Xqyxx();
            DataSet ds = B_Yxydw.GetList("yydh='" + yydh + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                f = true;

            }
            return f;




        }



        ////转换挂账单位
        //public static string Pladd_jzdw(int id)
        //{
        //    string s = common_app.get_failure;
        //    BLL.Yxydw B_Yxydw = new Hotel_app.BLL.Yxydw();
        //    Model.Yxydw M_Yxydw = new Hotel_app.Model.Yxydw();
        //    M_Yxydw = B_Yxydw.GetModel(id);
        //    string strxyh = M_Yxydw.xyh;

        //    //转换时要判断有没有相同的数据存在
        //    if (B_Yxydw.GetModelList("xyh='" + strxyh + "' and rx='" + xyrx_gzdw + "'").Count > 0)
        //    {
        //        string strSql = "delete from Yxydw where xyh='" + strxyh + "' and rx='" + xyrx_gzdw + "' ";
        //        DbHelperSQL.ExecuteSql(strSql);

        //    }



        //    //要判不能有相同的数据

        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("insert into Yxydw(krly,yydh,qymc,xyrx,krgj,pq,xyh,xyh_inner,rx,xydw,zjm,nxr,krdh,krcz,krEmail,krdz,xsy,shsc,bz,lzfs,fkje,xfje,clsj,xzxg,is_top,is_select,shsh,sign_image)");
        //    sb.Append("select krly,yydh,qymc,xyrx,krgj,pq,xyh,xyh_inner,'" + xyrx_gzdw + "',xydw,zjm,nxr,krdh,krcz,krEmail,krdz,xsy,'0',bz,lzfs,fkje,xfje,clsj,xzxg,is_top,is_select,shsh,sign_image from Yxydw where id=" + id + "");
        //    // sb.Append("values('"+xyrx_gzdw+"','"+M_Yxydw.yydh+"','"+M_Yxydw.qymc+"','"+M_Yxydw.xyrx+"','"+M_Yxydw.krgj+"','"+M_Yxydw.pq+"','"+M_Yxydw.xyh+"',"+M_Yxydw.xyh_inner+")");

        //    if (DbHelperSQL.ExecuteSql(sb.ToString()) > 0)
        //    {
        //        s = common_app.get_suc;
        //    }
        //    return s;

        //}


    }
}
