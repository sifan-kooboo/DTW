using System;
using System.Data;
using System.Configuration;

namespace Hotel_app.Server.Ffjzt
{


    public partial class Flfsz_add_edit
    {
        public string Flfsz_add_edit_delete(string id, string yydh, string qymc, string lfbh, string lsbh, string fjbh, string krxm, string sktt, string yddj, string czy, string czsj, bool shlz, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Model.Flfsz M_flfsz = new Model.Flfsz();
            BLL.Flfsz B_flfsz = new BLL.Flfsz();
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            if (add_edit_delete == common_file.common_app.get_add)
            {

                M_flfsz.yydh = yydh;
                M_flfsz.yddj = yddj;
                M_flfsz.sktt = sktt;
                M_flfsz.qymc = qymc;
                M_flfsz.lsbh = lsbh;
                M_flfsz.lfbh = lfbh;
                M_flfsz.krxm = krxm;
                M_flfsz.fjbh = fjbh;
                M_flfsz.czy = czy;
                M_flfsz.czsj = Convert.ToDateTime(czsj);
                M_flfsz.shlz = shlz;

                if (M_flfsz.fjbh.ToString() != "" && M_flfsz.yddj.ToString() == common_file.common_yddj.yddj_dj && shlz==true)
                {
                    B_Common.ExecuteSql("update Ffjzt set shlf=1, czsj='" + DateTime.Now.ToString() + "' where fjbh='" + M_flfsz.fjbh.ToString() + "'");
                }

                int IsAdd = B_flfsz.Add(M_flfsz);
                if (IsAdd > 0)
                {
                    s = common_file.common_app.get_suc;
                    common_file.common_czjl.add_czjl(yydh,qymc,czy,"联房",krxm+"_"+fjbh,lsbh+"_"+lfbh,DateTime.Parse(czsj));
                }

            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_flfsz = B_flfsz.GetModel(int.Parse(id));
                    //M_flfsz.id = int.Parse(id);
                    M_flfsz.yydh = yydh;
                    M_flfsz.yddj = yddj;
                    M_flfsz.sktt = sktt;
                    M_flfsz.qymc = qymc;
                    M_flfsz.lsbh = lsbh;
                    M_flfsz.lfbh = lfbh;
                    M_flfsz.krxm = krxm;
                    M_flfsz.fjbh = fjbh;
                    M_flfsz.shlz = shlz;
                    M_flfsz.czy = czy;
                    M_flfsz.czsj = Convert.ToDateTime(czsj);
                    if (M_flfsz.fjbh.ToString() != "" && M_flfsz.yddj.ToString() == common_file.common_yddj.yddj_dj && shlz == true)
                    {
                        B_Common.ExecuteSql("update Ffjzt set shlf=1, czsj='" + DateTime.Now.ToString() + "' where fjbh='" + M_flfsz.fjbh.ToString() + "'");
                    }
                    if (B_flfsz.Update(M_flfsz))
                    {
                        s = common_file.common_app.get_suc;
                        common_file.common_czjl.add_czjl(yydh, qymc, czy, "修改联房", krxm + "_" + fjbh, lsbh + "_" + lfbh, DateTime.Parse(czsj));
                    }

                }
                else
                {
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "" && id != null)
                        {
                            int strid = int.Parse(id);
                            M_flfsz = B_flfsz.GetModel(int.Parse(id));
                            //BLL.Common B_Common = new Hotel_app.BLL.Common();
                            B_Common.ExecuteSql("insert into Flfsz_temp(yydh,qymc,lfbh,lsbh,fjbh,krxm,sktt,yddj,shlz,is_top,is_select,czy,czsj) select yydh,qymc,lfbh,lsbh,fjbh,krxm,sktt,yddj,shlz,is_top,is_select,'"+czy+"','"+czsj+"' from Flfsz where id='"+id+"'");
                            common_file.common_czjl.add_czjl(M_flfsz.yydh, M_flfsz.qymc, czy, "删除联房", M_flfsz.krxm + "_" + M_flfsz.fjbh, M_flfsz.lsbh + "_" + M_flfsz.lfbh, DateTime.Parse(czsj));
                            B_flfsz.Delete(strid);
                            s = common_file.common_app.get_suc;
                            
                        }

                    }
                }

            return s;


        }

        /// <summary>
        /// 成批添加联房信息
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="old_lsbh"></param>
        /// <param name="lfbh"></param>//如果联房编号为空，就表示原来都还没联房，如果有就用新的联房编号
        /// <param name="id_arg"></param>
        /// <param name="czy"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// <returns></returns>
        public string set_pl_lf(string yydh, string qymc, string old_lsbh, string lfbh, string[] id_arg, bool shlz, string czy, string czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            DataSet ds_temp = B_Common.GetList("select * from View_Qskzd", " lsbh='" + old_lsbh + "'");
            DataSet ds_temp_1 = B_Common.GetList("select * from View_Qskzd", " lsbh='" + old_lsbh + "'");
            string lfbh_app = "";
            if (lfbh == "")
            {
                lfbh_app = common_file.common_ddbh.ddbh("lf", "lfdate", "lfcounter", 6);
                //ds_temp = B_Common.GetList("select * from View_Qskzd", " lsbh='" + old_lsbh + "'");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    Flfsz_add_edit_delete("", yydh, qymc, lfbh_app, old_lsbh, ds_temp.Tables[0].Rows[0]["fjbh"].ToString(), ds_temp.Tables[0].Rows[0]["krxm"].ToString(), ds_temp.Tables[0].Rows[0]["sktt"].ToString(), ds_temp.Tables[0].Rows[0]["yddj"].ToString(), czy, czsj, shlz, common_file.common_app.get_add, xxzs);
                }

            }
            else
            {
                lfbh_app = lfbh;
            }

            foreach (string id_0 in id_arg)
            {
                if (id_0 != null)
                {
                    ds_temp = B_Common.GetList("select * from View_Qskzd", " id='" + id_0 + "'");
                    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                    {
                        ds_temp_1 = B_Common.GetList("select * from Flfsz ", "lsbh='" + ds_temp.Tables[0].Rows[0]["lsbh"].ToString() + "'");
                        if (ds_temp_1 != null && ds_temp_1.Tables[0].Rows.Count > 0)
                        {
                            s = Flfsz_add_edit_delete(ds_temp_1.Tables[0].Rows[0]["id"].ToString(), yydh, qymc, lfbh_app, old_lsbh, ds_temp.Tables[0].Rows[0]["fjbh"].ToString(), ds_temp.Tables[0].Rows[0]["krxm"].ToString(), ds_temp.Tables[0].Rows[0]["sktt"].ToString(), ds_temp.Tables[0].Rows[0]["yddj"].ToString(), czy, czsj, shlz, common_file.common_app.get_delete, xxzs);
                        
                        }
                        s = Flfsz_add_edit_delete("", yydh, qymc, lfbh_app, ds_temp.Tables[0].Rows[0]["lsbh"].ToString(), ds_temp.Tables[0].Rows[0]["fjbh"].ToString(), ds_temp.Tables[0].Rows[0]["krxm"].ToString(), ds_temp.Tables[0].Rows[0]["sktt"].ToString(), ds_temp.Tables[0].Rows[0]["yddj"].ToString(), czy, czsj, shlz, common_file.common_app.get_add, xxzs);

                    }
                }
            }
            ds_temp.Dispose();
            ds_temp_1.Dispose();
            return s;

        }

    }
}
