using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Hotel_app.Server.Qyddj
{
    /// <summary>
    /// Qyddj_app 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Qyddj_app : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(Description = "散客登记的增删改")]
        public string Qskdj_add_edit_delete(string id, string yydh, string qymc, string lsbh, string ddbh, string hykh, string hyrx, string krxm, string tlkr, string krgj, string krmz, string yxzj, string zjhm, string krxb, string krsr, string krdh, string krsj, string krEmail, string krdz, string krjg, string krdw, string krzy, string cxmd, string qzrx, string qzhm, string zjyxq, string tlyxq, string tjrq, string lzka, string krly, string xyh, string xydw, string xsy, string ddrx, string ddwz, string zyzt, string krrx, string kr_children, string ddsj, string lzts, string lksj, string qtyq, string czy, string czsj, string cznr, string sktt, string yddj, string main_sec, string yddj_rx, string syzd, string vip_type, string tsyq, string add_edit_delete, string xxzs, string ddly, string hykh_bz)
        {
            string s = common_file.common_app.get_failure;
            Qyddj.Qyddj_add_edit_delete Qyddj_add_edit_delete_new = new Qyddj_add_edit_delete();
            s = Qyddj_add_edit_delete_new.Qskdj_add_edit_delete(id,yydh, qymc,lsbh, ddbh, hykh, hyrx, krxm,tlkr,krgj, krmz, yxzj, zjhm, krxb, krsr, krdh, krsj, krEmail, krdz, krjg, krdw, krzy, cxmd, qzrx, qzhm, zjyxq, tlyxq, tjrq, lzka, krly, xyh, xydw, xsy, ddrx, ddwz, zyzt, krrx, kr_children, ddsj, lzts, lksj, qtyq, czy, czsj, cznr, sktt, yddj, main_sec,  yddj_rx,syzd,vip_type,tsyq,add_edit_delete, xxzs,ddly,hykh_bz);
            return s;
        }


       //成批删除散客记录，主要用来webservice一次性调用，内部就不必这样了。
        [WebMethod(Description = "成批删除散客记录")]
        public string delete_sk_multi(string[] id_arg, string czzt, string czbz, string qxyy, string jzbh, string czy, string czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Qyddj.Qyddj_add_edit_delete Qyddj_add_edit_delete_new = new Qyddj_add_edit_delete();
            s = Qyddj_add_edit_delete_new.delete_sk_multi(id_arg,  czzt,  czbz,  qxyy,  jzbh, czy, czsj, xxzs);
            return s;
        }


        [WebMethod(Description = "房间类型的增删改")]
        public string Qskyd_fjrb_add_edit_delete_app(string id, string yydh, string qymc, string lsbh, string krxm, string sktt, string yddj, string fjrb, string fjbh, DateTime ddsj, DateTime lksj, Decimal lzfs, string shqh, decimal fjjg, decimal sjfjjg, string yh, decimal yhbl, string bz, string czy, DateTime czsj, string cznr, string zyzt, string add_edit_delete, string xxzs,string fjbm,decimal jcje)
        {
            string s = common_file.common_app.get_failure;
            Qskyd_fjrb_add_edit_delete Qskyd_fjrb_add_edit_delete_new = new Qskyd_fjrb_add_edit_delete();
            s = Qskyd_fjrb_add_edit_delete_new.Qskyd_fjrb_add_edit_delete_app(id, yydh, qymc, lsbh, krxm, sktt, yddj, fjrb, fjbh, ddsj, lksj, lzfs, shqh, fjjg, sjfjjg, yh, yhbl, bz, czy, czsj, cznr, zyzt, add_edit_delete, xxzs,fjbm,jcje);
            return s;
        }


        [WebMethod(Description = "团体登记的增删改")]
        public string Qttyd_add_edit_delete_app(string id, string yydh, string qymc, string lsbh, string ddbh, string krxm, string krbh, string yddj, string sktt, string krgj, string krdz, string krly, string xyh, string xydw, string xsy, string krdh, string krsj, string kremail, string ydrxm, string ddsj, string lzts, string lksj, string qtyq, string ddrx, string ddwz, string zyzt, string czy, string cznr, string czsj, string syzd, string tsyq, string add_edit_delete, string xxzs,string ddly)
        {
            string s = common_file.common_app.get_failure;
            Qttyd_add_edit_delete Qttyd_add_edit_delete_new = new Qttyd_add_edit_delete();
            s=Qttyd_add_edit_delete_new.Qttyd_add_edit_delete_app(id, yydh, qymc, lsbh, ddbh, krxm, krbh, yddj, sktt, krgj, krdz, krly, xyh, xydw, xsy, krdh, krsj, kremail, ydrxm, ddsj, lzts, lksj, qtyq, ddrx, ddwz, zyzt, czy, cznr, czsj, syzd, tsyq, add_edit_delete, xxzs,ddly);
            return s;
        }


        [WebMethod(Description = "预定时房间类型与联房的增删改")]
        public string Qskyd_fjrb_add_edit_delete_app_1(String id, string yydh, string qymc, string lsbh, string krxm, string sktt, string yddj, string fjrb, string fjbh, DateTime ddsj, DateTime lksj, Decimal lzfs, string shqh, decimal fjjg, decimal sjfjjg, string yh, decimal yhbl, string bz, string czy, DateTime czsj, string cznr, string zyzt, string add_edit_delete, string xxzs,string fjbm,decimal jcje)
        {
            string s = common_file.common_app.get_failure;
            Qskyd_fjrb_add_edd_delete_1 Qskyd_fjrb_add_edit_delete_new = new Qskyd_fjrb_add_edd_delete_1();
            s = Qskyd_fjrb_add_edit_delete_new.Qskyd_fjrb_add_edit_delete_app_1(id,yydh,qymc,lsbh,krxm,sktt,yddj,fjrb,fjbh,ddsj,lksj,lzfs,shqh,fjjg,sjfjjg,yh,yhbl,bz,czy,czsj,cznr,zyzt,add_edit_delete,xxzs,fjbm,jcje);
            return s;
        }

        //[WebMethod(Description = "用于团体排房_一次排一间")]
        //public string Qttyd_pf(string tt_id, string lsbh, string fjrb, string fjbh, string fjjg, string shqh, string yh, string bz, string czy)
        //{
        //    string s = common_file.common_app.get_failure;
        //    Qttyd_add_edit_delete Qttyd_add_edit_delete_new = new Qttyd_add_edit_delete();
        //    s = Qttyd_add_edit_delete_new.tt_pf(tt_id, lsbh, fjrb, fjbh, fjjg, shqh, yh, bz, czy);
        //    return s;
        //}

        [WebMethod(Description = "用于团体排房_同时排多间的情形")]
        public string tt_pf_multi(string tt_id, string lsbh, string fjrb, string[] strs_fjbh, string fjjg, string shqh, string yh, string bz, string czy, string czsj, string cznr, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Qttyd_add_edit_delete Qttyd_add_edit_delete_new = new Qttyd_add_edit_delete();
            s = Qttyd_add_edit_delete_new.tt_pf_multi(tt_id, lsbh, fjrb, strs_fjbh, fjjg, shqh, yh, bz, czy, czsj,cznr,xxzs);
            return s;
        }


        [WebMethod(Description = "预订转登记")]
        public string ydzdj_app(string yydh, string qymc, string lsbh, string sktt, string ddbh, bool shlf, string czy, string cznr, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Qyddj_add_edit_delete_1 Qyddj_add_edit_delete_1_new = new Qyddj_add_edit_delete_1();
            s = Qyddj_add_edit_delete_1_new.ydzdj_app(yydh, qymc,lsbh, sktt, ddbh, shlf,  czy, cznr, czsj, xxzs);
            return s;
        }

        [WebMethod(Description = "出团、入团、散-长、散-钟、团-会等")]
        public string sktt_hz(string yydh, string qymc, string sktt, string lsbh, string krxm,  string ddbh, string ctlt, string old_sktt_bz, string sktt_bz, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Qyddj_add_edit_delete_1 Qyddj_add_edit_delete_1_new = new Qyddj_add_edit_delete_1();
            s = Qyddj_add_edit_delete_1_new.sktt_hz(yydh,qymc,sktt,lsbh,krxm,ddbh,ctlt,old_sktt_bz,sktt_bz,czy,czsj,xxzs);
            return s;
        }

        [WebMethod(Description = "投诉建议")]
        public string Qtsjy_add_edit(string id, string yydh, string qymc, string lsbh, string fjbh, string sktt, string krxm, string krsj, string zjhm, string xyh, string xydw, string hykh, string tsrx, string tsnr, DateTime tssj, string czy, string clbm, string clnr, DateTime clsj, string cly, string add_edit, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Qyddj_other Qyddj_other_new = new Qyddj_other();
            s = Qyddj_other_new.Qtsjy_add_edit(id, yydh, qymc, lsbh, fjbh, sktt, krxm, krsj, zjhm, xyh, xydw, hykh, tsrx, tsnr, tssj, czy, clbm, clnr, clsj, cly, add_edit, xxzs);
            return s;
        }


        [WebMethod(Description = "客人喜好")]
        public string Qkrxh_add_edit_delete(string id, string yydh, string qymc, string krxm, string krsj, string zjhm, string hykh, string xhrx, string krxh, string bz, string czy, DateTime czsj, string add_edit, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Qyddj_other Qyddj_other_new = new Qyddj_other();
            s = Qyddj_other_new.Qkrxh_add_edit_delete(id, yydh, qymc, krxm, krsj, zjhm, hykh, xhrx, krxh, bz, czy, czsj, add_edit, xxzs);
            return s;
        }
        [WebMethod(Description = "同房客人单独开单")]
        public string New_skyd_dl_record(string id, string old_lsbh, string czy, string czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Qyddj_add_edit_delete_1 Qyddj_add_edit_delete_1_new = new Qyddj_add_edit_delete_1();
            s = Qyddj_add_edit_delete_1_new.New_skyd_dl_record(id, old_lsbh, czy, czsj, xxzs);
            return s;
        }

        [WebMethod(Description = "房费绑定费用")]
        public string add_edit_delete_Q_ff_xyxf(string id, string yydh, string qymc, string fyrx, string xfdr, string xfrb, string xfxm, decimal xfsl, decimal xfje, string add_edit_delete, string czy, DateTime czsj, string cznr, string xxzs, decimal jjje,string mxbh)
        {
            string s = common_file.common_app.get_failure;
            Q_ff_xyxf Q_ff_xyxf_new = new Q_ff_xyxf();
            s=Q_ff_xyxf_new.add_edit_delete_Q_ff_xyxf(id,yydh, qymc, fyrx, xfdr, xfrb, xfxm, xfsl, xfje, add_edit_delete, czy, czsj, cznr, xxzs,jjje,mxbh);
            return s;
        
        }


        [WebMethod(Description = "散客预订撤销")]
        public string skyd_cx(string yydh, string qymc, string lsbh, string input_cznr, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Qydcx Qydcx_new = new Qydcx();
            s = Qydcx_new.skyd_cx(yydh, qymc, lsbh, input_cznr, czy, czsj, xxzs);
            return s;
        }


        [WebMethod(Description = "团队预订撤销")]
        public string ttyd_cx(string yydh, string qymc, string lsbh, string input_cznr, string czy, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Qydcx Qydcx_new = new Qydcx();
            s = Qydcx_new.ttyd_cx(yydh, qymc, lsbh, input_cznr, czy, czsj, xxzs);
            return s;

        }

        [WebMethod(Description = "复制预订")]
        public string copy_sk_yd(string yydh, string qymc, string sktt, string old_lsbh, string lsbh_new,string  ddbh_new, string czy, DateTime czsj, string cznr, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Q_copy_yd Q_copy_yd_new = new Q_copy_yd();
            s = Q_copy_yd_new.copy_sk_yd(yydh, qymc, sktt,old_lsbh,lsbh_new,ddbh_new, czy, czsj, cznr, xxzs);
            return s;

        }


        [WebMethod(Description = "用于团体排房-Test1")]

        public string Qttyd_cs(string[] args_1, string[] args_2)
        {
            string s = args_1.Length.ToString();
            s = common_file.common_app.yydh;
            s = common_file.common_app.qymc;
            s = common_file.common_app.qybh;
            s = common_file.common_app.yydh_select;
            return s;
        }


        [WebMethod(Description = "团队合并")]
        public string tt_unit(string yydh, string qymc, string czy, DateTime czsj, string lsbh_old, string ddbh_old, string lsbh_add, string ddbh_add, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Q_tt_unit Q_tt_unit_new = new Q_tt_unit();
            s = Q_tt_unit_new.tt_unit( yydh,  qymc,  czy,  czsj,  lsbh_old,  ddbh_old,  lsbh_add,  ddbh_add,  xxzs);
            return s;
        
        }

        [WebMethod(Description = "催押")]
        public string cy_app(string yydh, string qymc, string czy, string cybl, DateTime czsj, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Q_cy Q_cy_new = new Q_cy();
            s = Q_cy_new.cy_app(yydh, qymc, czy, cybl, czsj, xxzs);
            return s;
        }



        [WebMethod(Description = "Test2")]

        public string Qttyd_cs0(string s1)
        {
            string s = "";
            s = common_file.common_app.yydh;
            s = common_file.common_app.qymc;
            s = common_file.common_app.qybh;
            s = common_file.common_app.yydh_select;
            return s;
        }



    }
}
