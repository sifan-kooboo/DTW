using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Hotel_app.Server.Xxtsz
{
    public class Xfkfs
    {
        public string Xfkfs_add_edit(string id, string yydh, string qymc, string fkfs, string zjm, string add_edit_delete, string xxzs)
        {
            string s = common_file.common_app.get_failure;
            BLL.Xfkfs B_Xfkfs = new Hotel_app.BLL.Xfkfs();
            Model.Xfkfs M_Xfkfs = new Hotel_app.Model.Xfkfs();
            if (xxzs == common_file.common_app.xxzs_xxvalue) { }
            if (xxzs == common_file.common_app.xxzs_zsvalue) { }
            if (add_edit_delete == common_file.common_app.get_add)
            {
                M_Xfkfs.yydh = yydh;
                M_Xfkfs.qymc = qymc;
                M_Xfkfs.fkfs = fkfs;
                M_Xfkfs.zjm = zjm;
                if (B_Xfkfs.Add(M_Xfkfs) > 0)
                {
                    s = common_file.common_app.get_suc;
                }
            }
            else
                if (add_edit_delete == common_file.common_app.get_edit)
                {
                    M_Xfkfs = B_Xfkfs.GetModel(Convert.ToInt32(id));
                    M_Xfkfs.fkfs =fkfs;
                    M_Xfkfs.zjm = zjm;
                    M_Xfkfs.id = Convert.ToInt32(id);
                    B_Xfkfs.Update(M_Xfkfs);
                    s = common_file.common_app.get_suc;
                }
                else
                    if (add_edit_delete == common_file.common_app.get_delete)
                    {
                        if (id != "")
                        {
                            B_Xfkfs.Delete(Convert.ToInt32(id));
                            s = common_file.common_app.get_suc;
                        }
                    }
            return s;
        }
    }
}
