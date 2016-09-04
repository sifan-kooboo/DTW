using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using Hotel_app.Server.Szwgl;

namespace Hotel_app.Server.Szwgl
{
    /// <summary>
    /// Szwgl_app 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Szwgl_app : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(Description = "用于预付款与押金的增删改")]
        public string Syjcz_add_edit(string id, string yydh, string qymc, string id_app, string jzbh, string lsbh, string krxm, string fjrb, string fjbh, string sktt, string xfrq, string xfsj,
            string czy, string xfdr, string xfrb, string xfxm, string xfbz, string xfzy, string fkfs, string xfje, string sjxfje, string czy_bc, string syzd, string add_edit_delete, string xxzs,string czsj)
        {
            string s = Hotel_app.common_file.common_app.get_failure;
            Szwgl.Syjcz Syjcz_add_edit_new = new Syjcz();
            s = Syjcz_add_edit_new.Syjcz_add_edit(id, yydh, qymc, id_app, jzbh, lsbh, krxm, fjrb, fjbh, sktt, xfrq, xfsj, czy, xfdr, xfrb, xfxm, xfbz, xfzy, fkfs, xfje, sjxfje, czy_bc, syzd, add_edit_delete, xxzs,czsj);
            return s;
 
        }
        [WebMethod(Description = "用于消费项目与帐务明细的增删改")]
        public string Szwmx_add_edit(string zd_id, string sktt, string old_id_app, string yydh, string qymc, string id_app,
        string xfrq, string xfsj, string czy, string xfdr, string xfrb, string xfxm, string xfbz, string xfzy, string xfje, string yh, string sjxfje, string xfsl,
        string czy_bc, string czzt, string czsj, string syzd, string add_edit_delete, string xxzs, string jjje, string fjrb, string fjbh, string mxbh, string ddsj, string lksj)
        {
            string s = common_file.common_app.get_failure;
            Szwgl.Szwmx Szwmx_add_edit_new = new Szwmx();
            s = Szwmx_add_edit_new.Szwmx_add_edit(zd_id, sktt, old_id_app, yydh, qymc, id_app, xfrq, xfsj, czy, xfdr, xfrb, xfxm, xfbz, xfzy, xfje, yh, sjxfje, xfsl, czy_bc, czzt, czsj, syzd, add_edit_delete, xxzs, jjje, fjrb, fjbh,mxbh, ddsj, lksj);
            return s;
        }

        [WebMethod(Description = "用于将电话费导入到房费")]
        public string InsertDHFtoSzwmx(string sk_tt,string is_addToSingle, string yydh, string qymc, string lsbh,string czy,string czy_bc, string czsj, string syzd, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Szwgl.Szwmx Szwmx_add_edit_new = new Szwmx();
            s = Szwmx_add_edit_new.InsertDHFtoZw(sk_tt, is_addToSingle, yydh, qymc, lsbh, czy, czy_bc, czsj, syzd, add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description = "用于其它消费导入到房费")] //i
        public string InsertOtherFeetoSzwmx(string sk_tt, string is_addToSingle, string yydh, string qymc, string lsbh, string czy, string czy_bc, string czsj, string syzd, string add_edit_delete, string xxzs,string  importType)
        {
            string s = common_file.common_app.get_failure;
            Szwgl.Szwmx Szwmx_add_edit_new = new Szwmx();
            s = Szwmx_add_edit_new.InsertOtherFeetoZw(sk_tt, is_addToSingle, yydh, qymc, lsbh, czy, czy_bc, czsj, syzd, add_edit_delete, xxzs, importType);
            return s;
        }

        [WebMethod(Description = "账务明细")]
        public DataSet Get_Zwmx(string lsbh, string yddj, string sktt, string czy,string  czy_GUID)
        {
            DataSet ds_zwmx = new DataSet();
            Szwcl_GetData Zzwcl_new = new Szwcl_GetData();
            return ds_zwmx = Zzwcl_new.Zzwcl_Search(lsbh, yddj, sktt, czy,czy_GUID);
        }
        [WebMethod(Description = "消费项目")]
        public DataSet Get_xfxm(string lsbh, string yddj, string sktt, string czy)
        {
            DataSet ds_xfxm = new DataSet();
            Szwcl_GetData Zzwcl_new = new Szwcl_GetData();
            return ds_xfxm = Zzwcl_new.Zzwcl_hz(lsbh, yddj, sktt, czy);
        }

        //
        [WebMethod(Description = "用于算帐，记帐，挂帐的帐务处理")]
        public string FunCommon_zwcl(string lsbh, string sktt, string xydw, string krly,string yydh,string czzt, string jzzt, string czy,string czy_bc, string cznr, string czsj, string syzd, string xxzs,string  czy_GUID)
        {
            string s = common_file.common_app.get_failure;
            Szwgl.Szw_jzOrgzOrSZ Szw_jzOrgzOrSZ_new = new Szw_jzOrgzOrSZ();
             s = Szw_jzOrgzOrSZ_new.Func_zwcl(lsbh, sktt, xydw, krly, yydh, czzt, jzzt, czy, czy_bc, cznr, czsj, syzd, xxzs,czy_GUID);
            if(s.Equals(common_file.common_app.get_suc))
            {
                if (krly.Equals(common_file.common_krly.krly_hyuan))
                {
 
                }
            }
             return s;
        }

        [WebMethod(Description = "挂转结，记转结的处理过程")]
        public string Fun_jzOrgzToSZ(string lsbh, string jzbh,string yydh,string czzt, string sk_tt, string czy, string czsj,string syzd,string czy_bc,string fkje,string xfje,string xxzs,string qymc,string czy_GUID)
        {
            string s = common_file.common_app.get_failure;
            Szwgl.Szw_jzOrgzToSz Szw_jzOrgzToSz_new = new Szw_jzOrgzToSz();
            return s = Szw_jzOrgzToSz_new.GetjzOrgzToSzResult(lsbh, jzbh, yydh, czzt, sk_tt, czy, czsj, syzd, czy_bc, fkje, xfje,xxzs,qymc,czy_GUID);
        }

        [WebMethod(Description="挂/记--转帐的处理过程")]
        public string Fun_jzOrgzOrZaiZToZz(string lsbh_old, string jzbh_old, string lsbh_new, string sk_tt, string Zz_Type, string yydh, string czy, string czy_bc, string czsj, string syzd, string xxzs, string qymc, string czy_GUID)
        {
            string  s=common_file.common_app.get_failure;
            Szwgl.Szw_jzOrgzOrZaiZToZz Szw_jzOrgzOrZaizToZz_new = new Szw_jzOrgzOrZaiZToZz();
            return s = Szw_jzOrgzOrZaizToZz_new.GetjzOrgzOrZaizToZzResult(lsbh_old, jzbh_old, lsbh_new, sk_tt, Zz_Type, yydh, czy, czy_bc, czsj, syzd, xxzs, qymc, czy_GUID);
            //GetjzOrgzOrZaizToZzResult( lsbh_old, jzbh_old,  lsbh_new, string sk_tt, string Zz_Type, string yydh, string czy, string czy_bc, string czsj, string syzd, string xxzs,string qymc)
        }

        [WebMethod(Description = "挂/记/算--分结的处理过程")]
        public string Fun_jzOrgzToFj(string lsbh, string jjType, string sk_tt, string czy, string czsj, string syzd, string czy_bc, string fkje, string xfje, string xxzs,string yydh,string jzbh_old,string  czy_GUID)
        {
            string s = common_file.common_app.get_failure;
            Szwgl.Szw_jzOrgzOrszToFj Szw_jzOrgzOrszToFj_new = new Szw_jzOrgzOrszToFj();
            return s = Szw_jzOrgzOrszToFj_new.GetjzOrgzOrszToFjResult(lsbh, jjType, sk_tt, czy, czsj, syzd, czy_bc, fkje, xfje, xxzs, yydh, jzbh_old, czy_GUID);
        }

        [WebMethod(Description = "记/挂互转")]
        public string Fun_Szw_GetChangZwType(string lsbh, string qymc, string yydh, string jzzt, string czy, string syzd, string czsj, string jjType, string xxzs,string jzbh)
        {
            string s = common_file.common_app.get_failure;
            Szwgl.Szw_ChangZwType Szw_ChangZwType_new = new Szw_ChangZwType();
            return s = Szw_ChangZwType_new.Szw_GetChangZwType(lsbh, qymc, yydh, jzzt, czy, syzd, czsj, jjType, xxzs,jzbh);
        }

        [WebMethod(Description = "平帐时的处理方法")]
        public string Fun_PZ(string id, string yydh, string qymc, string id_app, string jzbh, string lsbh, string krxm, string fjrb, string fjbh, string sktt,
    string xfrq, string xfsj, string czy, string xfdr, string xfrb, string xfxm, string xfbz, string xfzy, string xfje, string yh, string sjxfje, string xfsl,
    string czy_bc, string czzt, string czsj, string syzd, string add_edit_delete, string xxzs,string fkfs,string czy_GUID)
        {
            string s = common_file.common_app.get_failure;
            Szwgl.Szw_jzOrgzOrSZ Szw_jzOrgzOrSZ_new = new Szw_jzOrgzOrSZ();
            return s = Szw_jzOrgzOrSZ_new.Sjzmx_pz(id, yydh, qymc, id_app, jzbh, lsbh, krxm, fjrb, fjbh, sktt, xfrq, xfsj, czy, xfdr, xfrb, xfxm, xfbz, xfzy, xfje, yh, sjxfje, xfsl, czy_bc, czzt, czsj, syzd, add_edit_delete, xxzs, fkfs, czy_GUID);
        }


        [WebMethod(Description = "房间费用的处理方法")]
        public string New_fjfy(string yydh, string qymc, string lsbh, string fffs, string xfsj_bd, string czy_bc, string syzd, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Szwgl.Szwmx Szwmx_new = new Szwmx();
            s=Szwmx_new.New_fjfy( yydh, qymc, lsbh, fffs, xfsj_bd, czy_bc, syzd, czy, czsj, xxzs);
            return s;

        }
        [WebMethod(Description = "多间房间费用的处理方法")]
        public string New_muli_fjfy(string yydh, string qymc, string[] lsbh, string fffs, string xfsj_bd, string czy_bc, string syzd, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Szwgl.Szwmx Szwmx_new = new Szwmx();
            s = Szwmx_new.New_muli_fjfy(yydh, qymc, lsbh, fffs, xfsj_bd, czy_bc, syzd, czy, czsj, xxzs);
            return s;
        }
        [WebMethod(Description = "团体房间费用的处理方法")]
        public string New_tt_fjfy(string yydh, string qymc, string ddbh, string xfsj_bd, string czy_bc, string syzd, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Szwgl.Szwmx Szwmx_new = new Szwmx();
            s=Szwmx_new.New_tt_fjfy( yydh,  qymc,  ddbh,  xfsj_bd,  czy_bc,  syzd,  czy,  czsj,  xxzs);
            return s;
        }
        [WebMethod(Description = "所有费用")]
        public string New_all_fjfy(string yydh, string qymc, string czy_bc, string syzd, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Szwgl.Szwmx Szwmx_new = new Szwmx();
            s=Szwmx_new.New_all_fjfy( yydh,  qymc,  czy_bc,  syzd,  czy,  czsj,  xxzs);
            return s;
        }

        [WebMethod(Description = "帐务撤消功能模块")]
        public string Fun_zw_cx_temp(string lsbh, string jzbh, string sk_tt, string shlz_temp, string lzbh, string yydh, string qymc, string czzt, string czy, string syzd, string czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Szwgl.Szw_cx Szw_cx_new = new Szw_cx();
           // s = Szw_cx_new.Fun_zwcx(lsbh, jzbh, sk_tt, shlz_temp, lzbh, yydh, qymc, czzt, czy, syzd, czsj, xxzs);
            return s;
        }

        [WebMethod(Description = "帐务撤消功能模块_当前测试")]
        public string Fun_zw_cx(string lsbh, string jzbh, string sk_tt, string yydh, string qymc, string czzt, string czy, string syzd, string czsj, string xxzs, string czy_GUID)
        {
            string s = common_file.common_app.get_failure;
            Szwgl.Szw_cx  Szw_cx_new = new Szw_cx();
            s = Szw_cx_new.Fun_zwcx(lsbh, jzbh, sk_tt, yydh, qymc, czzt, czy, syzd, czsj, xxzs, czy_GUID);
            return s;
        }

        [WebMethod(Description = "批量结账")]
        public string Fun_gzpj(string jzzt, string jzbh_last, string jzType, string yydh, string qymc, string czy, string syzd, string czy_bc, string czsj, string xxzs, string czy_GUID)
        {
            string s = common_file.common_app.get_failure;
            Szwgl.Szw_gzpj Szw_gzpj_new = new Szw_gzpj();
            s = Szw_gzpj_new.Fun_gzpj(jzzt, jzbh_last, jzType, yydh, qymc, czy, syzd, czy_bc, czsj, xxzs, czy_GUID);
            return s;
        }
        [WebMethod(Description = "交班")]
        public string add_jb_app(string yydh, string qymc, string syzd, string czy_jb, string czy_sb, string j_s_bc, DateTime czsj, string czy, string bz, string jb_jk_rx, string xxzs, string czy_GUID)
        {
            string s = common_file.common_app.get_failure;
            Szwgl.S_jb_jk_fx S_jb_jk_fx_new = new S_jb_jk_fx();
            //string yydh, string qymc, string syzd, string czy_jb, string czy_sb, string j_s_bc, DateTime czsj, string czy, string bz, string jb_jk_rx, string xxzs
            s = S_jb_jk_fx_new.add_jb_app(yydh, qymc, syzd, czy_jb, czy_sb, j_s_bc, czsj, czy, bz, jb_jk_rx, xxzs, czy_GUID);
            return s;
        }


        [WebMethod(Description = "重做交款")]
        public string cz_jk_app(string yydh, string qymc, string czy_jb, string czy_sb, string j_s_bc, DateTime czsj, string czy, string bz, string jb_jk_rx, string xxzs, string czy_GUID)
        {
            string s = common_file.common_app.get_failure;
            Szwgl.S_jb_jk_fx S_jb_jk_fx_new = new S_jb_jk_fx();
            //string yydh, string qymc, string syzd, string czy_jb, string czy_sb, string j_s_bc, DateTime czsj, string czy, string bz, string jb_jk_rx, string xxzs
            s = S_jb_jk_fx_new.cz_jk_app(yydh, qymc,  czy_jb, czy_sb, j_s_bc, czsj, czy, bz, jb_jk_rx, xxzs,czy_GUID);
            return s;
        }


    }
}
