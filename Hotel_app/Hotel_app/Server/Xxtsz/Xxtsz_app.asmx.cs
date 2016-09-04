using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using Hotel_app.Model;

namespace Hotel_app.Server.Xxtsz
{
    /// <summary>
    /// Xxtsz_app 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Xxtsz_app : System.Web.Services.WebService
    {

        [WebMethod(Description="测试")]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(Description="用于客人来源的增删改")]
        public string Xkrly_add_edit(string id, string yydh, string qymc, string krly, string zjm, string add_edit_delete, string xxzs)
        {
            string s = Hotel_app.common_file.common_app.get_failure;
            Xxtsz.Xkrly Xkrly_add_edit_new = new Xkrly();
            s = Xkrly_add_edit_new.Xkrly_add_edit(id, yydh, qymc, krly, zjm,add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description = "用于客人民族的增删改")]
        public string Xkrmz_add_edit(string id, string yydh, string qymc, string krmz, string zjm, string add_edit_delete, string xxzs)
        {
            string s = Hotel_app.common_file.common_app.get_failure;
            Xxtsz.Xkrmz Xkrmz_add_edit_new = new Xkrmz();
            s = Xkrmz_add_edit_new.Xkrmz_add_edit(id, yydh, qymc, krmz, zjm, add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description = "用于企业信息的增删改")]
        public string Xqyxx_add_edit(string id, string yydh, string qymc, string zjm,string qybh, string qydh, string qycz, string email, string nxr,string qydz,string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Xqyxx Xqyxx_add_edit_new = new Xqyxx();
            s = Xqyxx_add_edit_new.Xqyxx_add_edit(id, yydh, qymc, zjm,qybh,qydh,qycz,email,nxr,qydz,add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description = "用于签证类型的增删改")]
        public string Xqzrx_add_edit(string id, string yydh, string qymc, string zjm, string qzrx,string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Xqzrx Xqzrx_add_edit_new = new Xqzrx();
            s = Xqzrx_add_edit_new.Xqzrx_add_edit(id, yydh,qymc,zjm,qzrx,add_edit_delete,xxzs);
            return s;
        }
        [WebMethod(Description = "用于国籍的增删改")]
        public string Xkrgj_add_edit(string id, string yydh, string qymc, string krgj, string zjm, string pq, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Xkrgj Xkrgj_add_edit_new = new Xkrgj();
            s = Xkrgj_add_edit_new.Xkrgj_add_edit(id, yydh, qymc,krgj,zjm,pq,add_edit_delete,xxzs);
            return s;
 
        }
        [WebMethod(Description = "用于证件的增删改")]
        public string Xyxzj_add_edit(string id, string yydh, string qymc, string zjm, string yxzj, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Xyxzj Xyxzj_add_edit_new = new Xyxzj();
            s = Xyxzj_add_edit_new.Xyxzj_add_edit(id, yydh, qymc, zjm,yxzj, add_edit_delete, xxzs);
            return s;
        }
       
        [WebMethod(Description = "用于优惠设置的增删改")]
        public string Xyhsz_add_edit(string id, string yydh, string qymc, string yhbl, string yh, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Xyhsz Xyhsz_add_edit_new = new Xyhsz();
            s = Xyhsz_add_edit_new.Xyhsz_add_edit(id, yydh,qymc,yhbl,yh,add_edit_delete,xxzs);

            return s;
        }
        [WebMethod(Description = "用于消费设置的增删改")]
        public string Xxfsz_add_edit(string id, string yydh, string qymc, string drbh, string xfdr, string xrbh, string xfxr, string xfje,bool is_visible_bb,string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Xxfsz Xxfsz_add_edit_new = new Xxfsz();
            s = Xxfsz_add_edit_new.Xxfsz_add_edit(id, yydh, qymc, drbh, xfdr, xrbh, xfxr, xfje,is_visible_bb,add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description = "用于消费明细的增删改")]
        public string Xxfmx_add_edit(string id, string yydh, string qymc, string drbh, string xfdr, string xrbh, string xfxr, string mxbh, string xfmx, string xfje, string zjm, string xfgg, string jjje, string xftm, string xfcd, string xfdw, string jldw,bool is_tj_kc,string kcsl,string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Xxfmx Xxfmx_add_edit_new = new Xxfmx();
            s = Xxfmx_add_edit_new.Xxfmx_add_edit(id, yydh, qymc, drbh, xfdr, xrbh, xfxr, mxbh, xfmx, xfje, zjm, xfgg, jjje, xftm, xfcd, xfdw, jldw,is_tj_kc,kcsl,add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description = "用于消费大类的增删改")]
        public string Xxfdr_add_edit(string id, string yydh, string qymc, string drbh, string xfdr, string xfje,bool is_visible_bb, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Xxfdr Xxfdr_add_edit_new = new Xxfdr();
            s = Xxfdr_add_edit_new.Xxfdr_add_edit(id, yydh, qymc, drbh, xfdr, xfje,is_visible_bb,add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description = "用于支付方式的增删改")]
        public string Xfkfs_add_edit(string id, string yydh, string qymc, string fkfs, string zjm, string add_edit_delete, string xxzs)
        {

            string s = common_file.common_app.get_failure;
            Xxtsz.Xfkfs Xfkfs_add_edit_new = new Xfkfs();
            s = Xfkfs_add_edit_new.Xfkfs_add_edit(id, yydh, qymc, fkfs, zjm, add_edit_delete, xxzs);
            return s;
        }


        [WebMethod(Description = "用于入库明细的增删改")]
        public string Xxfmx_lkmx_add_edit(string id, string yydh, string qymc, string lsbh, string lksj, string czsj, string czy, string bz, string drbh, string xfdr, string xrbh, string xfxr, string xfmx, string mxbh, string xfsl, string xftm, string add_edit_delete, string xxzs,string  dj)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Xxfmx_lkmx Xxfmx_lkmx_new = new Xxfmx_lkmx();
            s = Xxfmx_lkmx_new.Xxfmx_lkmx_add_edit(id, yydh, qymc, lsbh, lksj, czsj, czy, bz, drbh, xfdr, xrbh, xfxr, xfmx, mxbh, xfsl, xftm, add_edit_delete, xxzs, dj);
            return s;
        }
        [WebMethod(Description = "用于入库主单的增删改")]
        public string Xxfmx_lkzd_add_edit(string id, string yydh, string qymc, string lsbh, string czy, string lksj, bool sh_sh, string lknr, string bz, string sh_czy, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Xxfmx_lkzd Xxfmx_lkzd_new = new Xxfmx_lkzd();
            s = Xxfmx_lkzd_new.Xxfmx_lkzd_add_edit(id, yydh, qymc, lsbh, czy, lksj, sh_sh, lknr, bz, sh_czy, add_edit_delete, xxzs);
            return s;
        }
        //[WebMethod(Description = "用于设置时间同步")]
        //public string  Xfkfs_add_edit(ref DateTime sj)
        //{

        //    string s = common_file.common_app.get_failure;
        //    //Xxtsz.Xfkfs Xfkfs_add_edit_new = new Xfkfs();
        //    //s = Xfkfs_add_edit_new.Xfkfs_add_edit(id, yydh, qymc, fkfs, zjm, add_edit_delete, xxzs);
        //    return s = common_file.common_app.get_suc;
        //}



        [WebMethod(Description = "用于客人类型的增删改")]
        public string Xkrrx_add_edit(string id, string yydh, string qymc, string krrx, string zjm, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Xkrrx Xkrrx_add_edit_new = new Xkrrx();
            s = Xkrrx_add_edit_new.Xkrrx_add_edit(id, yydh, qymc, krrx, zjm, add_edit_delete, xxzs);
            return s;
        }


        [WebMethod(Description = "用于增补消费项目主单的增删改")]
        public string Xxfmx_zbzd_add_edit(string id, string yydh, string qymc, string lsbh, string czy, string zbsj, string is_sh, string zbnr, string bz, string sh_czy, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Xxfmx_zbzd Xxfmx_zbzd_new = new Xxfmx_zbzd();
            s = Xxfmx_zbzd_new.Xxfmx_zbzd_add_edit(id, yydh, qymc, lsbh, czy, zbsj, is_sh,zbnr, bz, sh_czy, add_edit_delete, xxzs);
            return s;
        }
        [WebMethod(Description = "用于增补消费项目主单明细的增删改")]
        public string Xxfmx_zbmx_add_edit(string id, string yydh, string qymc, string lsbh, string drbh, string xfdr, string xrbh, string xfxr, string xfmx, string mxbh, string xftm, string zb_sj, string zb_czy,  string zb_sl, string zb_zt, string add_edit_delete, string xxzs,string dj)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Xxfmx_zbmx Xxfmx_zbmx_new = new Xxfmx_zbmx();
            s = Xxfmx_zbmx_new.Xxfmx_zbmx_add_edit(id, yydh, qymc, lsbh, drbh, xfdr, xrbh, xfxr, xfmx, mxbh, xftm, zb_sj, zb_czy,  zb_sl, zb_zt, add_edit_delete, xxzs,dj);
            return s;
 
        }
        [WebMethod(Description = "用于增补消费项目主单位的审核")]
        public string Update_issh(string lsbh, string sh_czy)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Xxfmx_zbzd Xxfmx_zbzd_new = new Xxfmx_zbzd();
            s = Xxfmx_zbzd_new.Update_issh(lsbh, sh_czy);
            return s;
        }
        [WebMethod(Description = "用于入库主单的审核")]
        public string Update_lkzd_issh(string lsbh, string sh_czy)
        {
            string s = common_file.common_app.get_failure;
            Xxtsz.Xxfmx_lkzd Xxfmx_lkzd_new = new Xxfmx_lkzd();
            s = Xxfmx_lkzd_new.Update_lkzd_issh(lsbh, sh_czy);
            return s;
        }
    }
}
