using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

namespace Hotel_app.Server.BBfx
{
    public class B_xsy_krly_xydw
    {

        string s_space = "  ";
        string b_space = "        ";

        public void insert_s(BLL.Common B_Common, string yydh, string qymc, string type, string fxdr, string fxrb, float zyye, float zfh, float czfs, string pjczl, string xd_pjczl, float pjfj, float jcb,string  pjbl,string xd_pjbl, string czy, string cssj, string jssj)
        {
            string sql_s="";
            try
            {
                sql_s = "insert into BQ_syxffx(yydh,qymc,type,fxdr,fxrb,zyye,zfh,czfs,pjczl,xd_pjczl,pjfj,jcb,pjbl, xd_pjbl,czy_temp,cssj,jssj)";
                sql_s = sql_s + " values ('" + yydh + "','" + qymc + "','" + type + "','" + fxdr + "','" + fxrb + "','" + zyye + "','" + zfh + "','" + czfs + "','" + pjczl + "','" + xd_pjczl + "','" + pjfj + "','" + jcb + "','" + pjbl + "','" + xd_pjbl + "','" + czy + "','" + cssj + "','" + jssj + "')";
                B_Common.ExecuteSql(sql_s);
                string logPsssath = ConfigurationManager.AppSettings["ErrorLogPath"];

            }
            catch 
            {
                common_file.common_czjl.add_errorlog(sql_s, "", DateTime.Now.ToString());

            }

        }

        public void clear_cs(ref string fxdr, ref string fxrb, ref float zyye, ref float zfh, ref float czfs,  ref float pjczl, ref float xd_pjczl, ref float pjfj, ref float jcb,ref float pjbl,ref float xd_pjbl)
        {
            fxdr = ""; fxrb = ""; zyye = 0; zfh = 0; czfs = 0; pjczl = 0; xd_pjczl = 0; pjfj = 0; jcb = 0; pjbl = 0; xd_pjbl = 0;
        }






        /// <summary>
        /// 
        /// </summary>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="xsy_krly_xydw"></param>一级分析字段，如三个值分析到底是销售员xsy；客人来源krly；协议单位xydw，从common_bb获取，一定要字段的名称（也允许分析其他字段如片区、省份）
        /// <param name="xsy_krly_xydw_value"></param>是否有具体要分析哪一家,主要是用来处理一级字段如果有限定,就用来对一级字段的模糊查询
        /// <param name="is_second"></param>分析二级情况，例如有两种情况，一种是销售员下面带协议单位，一种是客人来源还协议单位
        /// <param name="second_value"></param>要分析的二级字段的名称
        /// <param name="other_cond"></param>是否有包含其他的查询条件（例如要查省份时一定要绑定国家是中国）
        /// <param name="czy"></param>
        /// <param name="cssj"></param>
        /// <param name="jssj"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        /// 
        public string bbfx_add_app(string yydh, string qymc, string xsy_krly_xydw, string xsy_krly_xydw_value, bool is_second, string second_value, string other_cond, string czy, string cssj, string jssj, DateTime czsj, string xxzs)
        {
            string get_result = common_file.common_app.get_failure;
            string sel_cond = " yydh='" + yydh + "' and czy_temp='" + czy + "' and xfdr!='" + Szwgl.common_zw.dr_ds + "' and (xfsj between '" + cssj + "' and '" + jssj + "')" + other_cond;
            if (xsy_krly_xydw_value != "")
            {
                sel_cond = sel_cond + " and " + xsy_krly_xydw + " like '%" + xsy_krly_xydw_value + "%'";
            }
            string sub_sel_con = "";
            float zfs = 1; string fxdr = ""; string fxrb = ""; float zyye = 0; float zfh = 0; float czfs = 0; float xd_czzfs = 1; float xd_czzfs_out = 1; float pjczl = 0; float xd_pjczl = 0; float pjfj = 0; float jcb = 0;
            float pjbl = 0; float xd_pjbl = 0;

            float ljzfh = 0;
            float ljczfs = 0;
            float ljzyye = 0;
           
            BLL.Common B_Common = new Hotel_app.BLL.Common();
            string sql_s = "delete from BQ_syxffx where czy_temp='" + czy + "' and type='" + xsy_krly_xydw + "'";
            B_Common.ExecuteSql(sql_s);
            DataSet DS_temp;
            DataSet DS_temp_0;

            //获取总房数
            DS_temp_0 = B_Common.GetList("select sum(zfs) as zfs from BSzhrbbfl", " yydh='" + yydh + "' and bbrq between '" + cssj + "' and '" + jssj + "'");
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                if (DS_temp_0.Tables[0].Rows[0]["zfs"].ToString() != "")
                {
                    zfs = float.Parse(DS_temp_0.Tables[0].Rows[0]["zfs"].ToString());
                }
            }

            //获取营业额
            string sel_cond_0 = " yydh='" + yydh + "' and xfdr!='" + Szwgl.common_zw.dr_ds + "' and (xfsj between '" + cssj + "' and '" + jssj + "')";
            float zyye_z = 1;
            DS_temp_0 = B_Common.GetList("select sum(sjxfje) as sjxfje from Ssyxfmx", sel_cond_0);
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                if (DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                {
                    zyye_z = float.Parse(DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString());
                }
            }


            xd_czzfs_out = 1;
            DS_temp_0 = B_Common.GetList("select sum(xfsl) as xfsl from BQ_syxfmx_ls", sel_cond + " and xfdr='" + Szwgl.common_zw.dr_ff + "'");
            if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
            {
                if (DS_temp_0.Tables[0].Rows[0]["xfsl"].ToString() != "")
                {
                    xd_czzfs_out = float.Parse(DS_temp_0.Tables[0].Rows[0]["xfsl"].ToString());
                }
            }
            
            B_syxfmx_ls_add B_syxfmx_ls_add_new = new B_syxfmx_ls_add();
            B_syxfmx_ls_add_new.Ssyxfmx_ls_add_app(yydh, qymc, czy, cssj, jssj, xsy_krly_xydw, xxzs);

            int i_0 = 0;

            DS_temp = B_Common.GetList("select " + xsy_krly_xydw + ",sum(sjxfje) as sjxfje from BQ_syxfmx_ls", sel_cond + " group by " + xsy_krly_xydw + " order by sjxfje desc");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {
                    clear_cs(ref  fxdr, ref  fxrb, ref  zyye, ref  zfh, ref  czfs, ref  pjczl, ref  xd_pjczl, ref  pjfj, ref jcb,ref  pjbl,ref  xd_pjbl);
                    if (DS_temp.Tables[0].Rows[i_0][xsy_krly_xydw].ToString() != "")
                    {
                        fxdr = DS_temp.Tables[0].Rows[i_0][xsy_krly_xydw].ToString();
                        fxrb = fxdr;
                    }
                    else
                    {
                        fxdr = "其他";
                        fxrb = fxdr;
                    }
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        zyye = float.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString());
                    }
                    DS_temp_0 = B_Common.GetList("select sum(sjxfje) as sjxfje from BQ_syxfmx_ls", sel_cond + " and xfdr='" + Szwgl.common_zw.dr_ff + "' and " + xsy_krly_xydw + "='" + DS_temp.Tables[0].Rows[i_0][xsy_krly_xydw].ToString() + "'");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                    {
                        if (DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                        {
                            zfh = float.Parse(DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString());
                        }
                    }
                    DS_temp_0 = B_Common.GetList("select sum(xfsl) as xfsl from BQ_syxfmx_ls", sel_cond + " and xfdr='" + Szwgl.common_zw.dr_ff + "' and " + xsy_krly_xydw + "='" + DS_temp.Tables[0].Rows[i_0][xsy_krly_xydw].ToString() + "' ");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                    {
                        if (DS_temp_0.Tables[0].Rows[0]["xfsl"].ToString() != "")
                        {
                            czfs = float.Parse(DS_temp_0.Tables[0].Rows[0]["xfsl"].ToString());
                        }
                    }
                    if (zfh <= 0 || czfs <= 0)
                    {
                        pjfj = 0;
                    }
                    else
                    {
                        pjfj = float.Parse(Convert.ToString(Math.Floor(zfh / czfs * 100) / 100));

                    }
                    ljzfh = ljzfh + zfh;
                    ljczfs = ljczfs + czfs;
                    ljzyye = ljzyye + zyye;
                    pjczl = float.Parse(Convert.ToString(Math.Floor(czfs / zfs * 10000) / 10000));
                    xd_pjczl = float.Parse(Convert.ToString(Math.Floor(czfs / xd_czzfs_out * 10000) / 10000));
                    pjbl = float.Parse(Convert.ToString(Math.Floor(zyye  / zyye_z * 10000) / 10000));
                    xd_pjbl = float.Parse(Convert.ToString(Math.Floor(zyye / zyye_z * 10000) / 10000));
                    jcb =  float.Parse(Convert.ToString(Math.Floor(pjczl * pjfj * 100) / 100));
                    insert_s(B_Common, yydh, qymc, xsy_krly_xydw, s_space + fxdr, s_space + fxrb, zyye, zfh, czfs, Convert.ToString(pjczl * 100) + "%", Convert.ToString(xd_pjczl * 100) + "%", pjfj, jcb, Convert.ToString(pjbl * 100) + "%", Convert.ToString(xd_pjbl * 100) + "%", czy, cssj, jssj);
                    //如果要分析二级情况
                    if (is_second == true)
                    {
                        sub_sel_con = sel_cond + "and " + xsy_krly_xydw + "='" + DS_temp.Tables[0].Rows[i_0][xsy_krly_xydw].ToString() + "' ";
                        bbfx_add_sub(B_Common, DS_temp_0, yydh, qymc, xsy_krly_xydw, fxdr, second_value, sub_sel_con, czfs,zyye, zfs,zyye_z, czy, cssj, jssj, czsj, xxzs);
                    }
                }
                pjczl = float.Parse(Convert.ToString(Math.Floor(ljczfs / zfs * 10000) / 10000));

                if (ljczfs <= 0)
                {
                    pjfj = 0;
                }
                else
                {
                    pjfj = float.Parse(Convert.ToString(Math.Floor(ljzfh / ljczfs * 100) / 100));

                }
                xd_pjczl = float.Parse(Convert.ToString(Math.Floor(ljczfs / xd_czzfs_out * 10000) / 10000));
                pjbl = float.Parse(Convert.ToString(Math.Floor(ljzyye / zyye_z * 10000) / 10000));
                xd_pjbl = float.Parse(Convert.ToString(Math.Floor(ljzyye / zyye_z * 10000) / 10000));
                jcb =  float.Parse(Convert.ToString(Math.Floor(pjczl * pjfj * 100) / 100));
                insert_s(B_Common, yydh, qymc, xsy_krly_xydw, s_space + "合计", s_space + "合计", ljzyye, ljzfh, ljczfs, Convert.ToString(pjczl * 100) + "%", Convert.ToString(xd_pjczl * 100) + "%", pjfj, jcb, Convert.ToString(pjbl * 100) + "%", Convert.ToString(xd_pjbl * 100) + "%", czy, cssj, jssj);

            }
            DS_temp_0.Clear();
            DS_temp_0.Dispose();
            DS_temp.Clear();
            DS_temp.Dispose();
            get_result = common_file.common_app.get_suc;
            return get_result;

        }

        /// <summary>
        /// 二级分析
        /// </summary>
        /// <param name="B_Common"></param>
        /// <param name="DS_temp_0"></param>
        /// <param name="yydh"></param>
        /// <param name="qymc"></param>
        /// <param name="xsy_krly_xydw"></param>
        /// <param name="xsy_krly_xydw_value"></param>
        /// <param name="second_value"></param>
        /// <param name="parent_cond"></param>
        /// <param name="xd_czzfs"></param>
        /// <param name="zfs"></param>
        /// <param name="czy"></param>
        /// <param name="cssj"></param>
        /// <param name="jssj"></param>
        /// <param name="czsj"></param>
        /// <param name="xxzs"></param>
        public void bbfx_add_sub(BLL.Common B_Common, DataSet DS_temp_0, string yydh, string qymc, string xsy_krly_xydw, string xsy_krly_xydw_value, string second_value, string parent_cond, float xd_czzfs, float xd_zyye_z, float zfs, float zyye_z, string czy, string cssj, string jssj, DateTime czsj, string xxzs)
        {

            string fxdr = ""; string fxrb = ""; float zyye = 0; float zfh = 0; float czfs = 0; float pjczl = 0; float xd_pjczl = 0; float pjfj = 0; float jcb = 0;
            float pjbl = 0; float xd_pjbl = 0;
            //B_syxfmx_ls_add B_syxfmx_ls_add_new = new B_syxfmx_ls_add();
            //B_syxfmx_ls_add_new.Ssyxfmx_ls_add_app(yydh, qymc, czy, cssj, jssj, xsy_krly_xydw, xxzs);

            int i_0 = 0;
            DataSet DS_temp;
            DS_temp = B_Common.GetList("select " + second_value + ",sum(sjxfje) as sjxfje from BQ_syxfmx_ls", parent_cond + " group by " + second_value + " order by sjxfje desc");
            if (DS_temp != null && DS_temp.Tables[0].Rows.Count > 0)
            {
                for (i_0 = 0; i_0 < DS_temp.Tables[0].Rows.Count; i_0++)
                {


                    clear_cs(ref  fxdr, ref  fxrb, ref  zyye, ref  zfh, ref  czfs, ref  pjczl, ref  xd_pjczl, ref  pjfj, ref jcb,ref  pjbl,ref  xd_pjbl);
                    if (DS_temp.Tables[0].Rows[i_0][second_value].ToString() != "")
                    {
                        fxdr = DS_temp.Tables[0].Rows[i_0][second_value].ToString();
                        fxrb = fxdr;
                    }
                    else
                    {
                        fxdr = "其他";
                        fxrb = fxdr;
                    }
                    if (DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString() != "")
                    {
                        zyye = float.Parse(DS_temp.Tables[0].Rows[i_0]["sjxfje"].ToString());
                    }
                    DS_temp_0 = B_Common.GetList("select sum(sjxfje) as sjxfje from BQ_syxfmx_ls", parent_cond + " and xfdr='" + Szwgl.common_zw.dr_ff + "' and " + second_value + "='" + DS_temp.Tables[0].Rows[i_0][second_value].ToString() + "'");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                    {
                        if (DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString() != "")
                        {
                            zfh = float.Parse(DS_temp_0.Tables[0].Rows[0]["sjxfje"].ToString());
                        }
                    }
                    DS_temp_0 = B_Common.GetList("select sum(xfsl) as xfsl from BQ_syxfmx_ls", parent_cond + " and xfdr='" + Szwgl.common_zw.dr_ff + "' and " + second_value + "='" + DS_temp.Tables[0].Rows[i_0][second_value].ToString() + "' ");
                    if (DS_temp_0 != null && DS_temp_0.Tables[0].Rows.Count > 0)
                    {
                        if (DS_temp_0.Tables[0].Rows[0]["xfsl"].ToString() != "")
                        {
                            czfs = float.Parse(DS_temp_0.Tables[0].Rows[0]["xfsl"].ToString());
                        }
                    }
                    if (zfh <= 0 || czfs <= 0)
                    {
                        pjfj = 0;
                    }
                    else
                    {
                        pjfj = float.Parse(Convert.ToString(Math.Floor(zfh / czfs * 100) / 100));

                    }
                    pjczl = float.Parse(Convert.ToString(Math.Floor(czfs / zfs * 10000) / 10000));
                    //pjfj = float.Parse(Convert.ToString(Math.Floor(zfh / czfs * 100) / 100));
                    xd_pjczl = float.Parse(Convert.ToString(Math.Floor(czfs / xd_czzfs * 10000) / 10000));
                    //jcb = pjczl * pjfj;
                    pjbl = float.Parse(Convert.ToString(Math.Floor(zyye / zyye_z * 10000) / 10000));
                    xd_pjbl = float.Parse(Convert.ToString(Math.Floor(zyye / xd_zyye_z * 10000) / 10000));
                    jcb = float.Parse(Convert.ToString(Math.Floor(pjczl * pjfj * 100) / 100));
                    insert_s(B_Common, yydh, qymc, xsy_krly_xydw, s_space + xsy_krly_xydw_value, b_space + fxrb, zyye, zfh, czfs, Convert.ToString(pjczl * 100) + "%", Convert.ToString(xd_pjczl * 100) + "%", pjfj, jcb, Convert.ToString(pjbl * 100) + "%", Convert.ToString(xd_pjbl * 100) + "%", czy, cssj, jssj);
                }
            }
            DS_temp.Clear();
            DS_temp.Dispose();




        }



    }
}
