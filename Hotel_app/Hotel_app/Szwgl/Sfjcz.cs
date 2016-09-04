using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maticsoft.DBUtility;
using System.Collections;

namespace Hotel_app.Szwgl
{
    public partial class Sfjcz : Form
    {

        //parameters
        string lsbh = "";
        string czzt = "";//转帐,结帐分结，记帐分结，挂帐分结(zz-fj,jz-fj,sz-fj)
        public string jzbh = "";//分结的时候
        string sk_tt = "";
        ///string jzbh = ""; 
        StringBuilder strsql;
        DataSet ds_xyjl_temp = null;
        DataSet ds_xzjl_temp = null;
        int dg_xyjl_count = 0;//记录现有记录的行数
        int dg_xzjl_count = 0;//记录选择记录的行数

        DateTime dt1;
        DateTime dt2;

        BLL.Common B_common = new Hotel_app.BLL.Common();
        BLL.Szwmx B_Szwmx = new Hotel_app.BLL.Szwmx();
        Model.Szwmx M_Szwmx;
        DataSet ds_temp;
        //拆帐时用到的parameters
        string id_app_temp_1 = "";//要进行拆帐的那条记录的ID_App的值 
        decimal fjje = 0;
        decimal ljje = 0;
        decimal je_need = 0;//要拆出的金额（ljje与fjje的差额）
        decimal je_last = 0;//拆出后剩下的金额数
        List<string> lists_id__app = new List<string>();   //处理多选的情况,记录选择到的记录的id_app
        Hashtable ht = new Hashtable();
        decimal percent = 0; //分结比例
        string id = "";//在住转帐时的主单的ID（Qskyd_mainrecord)

        public Sfjcz()
        {
            InitializeComponent();
        }

        private void Szzcl_Load(object sender, EventArgs e)
        {
            tb_fz.Visible = false;
            tb_fm.Visible = false;
            lbl_operate.Visible = false;
            b_fjfs.Text = "比例";
        }

        internal void InitalApp(string czzt, string lsbh, string sk_tt,string _jzbh)
        {
            this.czzt = czzt;
            this.sk_tt = sk_tt;
            this.jzbh = _jzbh;
            if (czzt == common_file.common_jzzt.czzt_jz||czzt==common_file.common_jzzt.czzt_gzzjz)
            {
                this.Text = "记帐分结"; b_zz.Text = "分结";
            }
            if (czzt == common_file.common_jzzt.czzt_gz||czzt==common_file.common_jzzt.czzt_jzzgz)
            {
                this.Text = "挂帐分结"; b_zz.Text = "分结";
            }
            if (czzt == common_file.common_jzzt.czzt_bfsz)
            { this.Text = "部分结帐"; b_zz.Text = "分结"; }
            if (czzt == common_file.common_jzzt.czzt_zz)
            { this.Text = "转帐"; b_zz.Text = "转帐"; }
            this.lsbh = lsbh;
            BindData_dg_xyjl();
            BindData_dg_xzjl();
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_SelectAll_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            lists_id__app.Clear();//注意这里要先清除所有的
            for (int i = 0; i < ds_xyjl_temp.Tables[0].Rows.Count; i++)
            { lists_id__app.Add(ds_xyjl_temp.Tables[0].Rows[i]["id_app"].ToString()); }
            if (lists_id__app.Count > 0)
            {
                Btn_operate(lists_id__app, "SelectAll");
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_CancelAll_Click(object sender, EventArgs e)
        {
            //Btn_operate(lists_id__app, "CancelAll");
            common_file.common_app.get_czsj();
            lists_id__app.Clear();//注意这里要先清除所有的
            for (int i = 0; i < ds_xzjl_temp.Tables[0].Rows.Count; i++)
            { lists_id__app.Add(ds_xzjl_temp.Tables[0].Rows[i]["id_app"].ToString()); }

            if (lists_id__app.Count > 0)
            {
                Btn_operate(lists_id__app, "CancelAll");
            }
        }

        private void b_SelectMulti_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            lists_id__app.Clear();//注意这里要先清除所有的
            DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
            foreach (DataGridViewRow dgvr in dg_xyjl.Rows)
            {
                if (this.dg_xyjl.Rows[dgvr.Index].Cells[0].GetEditedFormattedValue(dgvr.Index, ss) != null && Convert.ToBoolean(this.dg_xyjl.Rows[dgvr.Index].Cells[0].GetEditedFormattedValue(dgvr.Index, ss)) == true)
                {
                    int i_0 = dgvr.Index;

                    DataRowView dgr = dg_xyjl.Rows[i_0].DataBoundItem as DataRowView;
                    i_0 = ds_xyjl_temp.Tables[0].Rows.IndexOf(dgr.Row);

                    lists_id__app.Add(ds_xyjl_temp.Tables[0].Rows[i_0]["id_app"].ToString());
                }
            }
            if (lists_id__app.Count > 0)
            {
                Btn_operate(lists_id__app, "SelectMulti");
            }
            else
            {
                // common_file.common_app.Message_box_show(common_file.common_app.message_title, "没有选择任何记录");
            }
            Cursor.Current = Cursors.Default;
        }

        private void b_CancelMulti_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            lists_id__app.Clear();//注意这里要先清除所有的
            DataGridViewDataErrorContexts ss = new DataGridViewDataErrorContexts();
            foreach (DataGridViewRow dgvr in dg_xzjl.Rows)
            {
                if (this.dg_xzjl.Rows[dgvr.Index].Cells[0].GetEditedFormattedValue(dgvr.Index, ss) != null && Convert.ToBoolean(this.dg_xzjl.Rows[dgvr.Index].Cells[0].GetEditedFormattedValue(dgvr.Index, ss)) == true)
                {
                    int j_0 = 0;

                    DataRowView dgr = dgvr.DataBoundItem as DataRowView;
                    j_0 = ds_xzjl_temp.Tables[0].Rows.IndexOf(dgr.Row);

                    lists_id__app.Add(ds_xzjl_temp.Tables[0].Rows[j_0]["id_app"].ToString());
                }
            }
            if (lists_id__app.Count > 0)
            {
                Btn_operate(lists_id__app, "CancelMulti");
            }
            else
            {
                // common_file.common_app.Message_box_show(common_file.common_app.message_title, "没有选择任何记录");
            }
            Cursor.Current = Cursors.Default;
        }

        //自定义方法

        //窗体初始化绑定数据
        //是否清空Szw_zz_fj_temp表
        private void BindData_dg_xyjl()
        {
            dg_xyjl.AutoGenerateColumns = false;

            if (jzbh.Trim() == "")
            {
                BLL.Common B_Common = new Hotel_app.BLL.Common();
                if (czzt == common_file.common_jzzt.czzt_bfsz)
                {
                    DataSet ds_00 = B_Common.GetList(" select * from Flfsz  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'   and shlz='1'  )   and shlz='1' ");
                    if (ds_00 != null && ds_00.Tables[0].Rows.Count > 0)
                    {
                        string temp = " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and (lsbh in (select lsbh from Flfsz where lfbh in (select lfbh from Flfsz where lsbh='" + lsbh + "' and yydh='" + common_file.common_app.yydh + "' and shlz=1 ))  and shlz=1  )   and  id_app  not in  (select  id_app  from  Szw_zz_fj_temp  where  yydh='" + common_file.common_app.yydh + "'  and czy='" + common_file.common_app.czy_GUID + "')  order by fjbh,xfsj   asc ";
                        ds_xyjl_temp = B_common.GetList("select  *  from  Szwmx  ", " id>=0  and  yydh='" + common_file.common_app.yydh + "'     and (lsbh in (select lsbh from Flfsz where lfbh in (select lfbh from Flfsz where lsbh='" + lsbh + "' and yydh='" + common_file.common_app.yydh + "' and shlz=1 )   and shlz=1))   and  id_app  not in  (select  id_app  from  Szw_zz_fj_temp  where  yydh='" + common_file.common_app.yydh + "'  and czy='" + common_file.common_app.czy_GUID + "')  order by xfsj   asc,fjbh ");
                    }
                    else
                    {
                        ds_xyjl_temp = B_common.GetList("select  *  from  Szwmx  ", " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  lsbh='" + lsbh + "'  and  id_app  not in  (select  id_app  from  Szw_zz_fj_temp  where  yydh='" + common_file.common_app.yydh + "'  and czy='" + common_file.common_app.czy_GUID + "')  order by  fjbh,xfsj asc ");
                    }
                }
                if (czzt != common_file.common_jzzt.czzt_bfsz)
                {
                    ds_xyjl_temp = B_common.GetList("select  *  from  Szwmx  ", " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  lsbh='" + lsbh + "'  and  id_app  not in  (select  id_app  from  Szw_zz_fj_temp  where  yydh='" + common_file.common_app.yydh + "'  and czy='" + common_file.common_app.czy_GUID + "')  order by  fjbh,xfsj asc ");
                }


            }
            if (jzbh != "")
            {
                ds_xyjl_temp = B_common.GetList("select  *  from  Szwmx  ", " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and jzbh='" + jzbh + "'   and  id_app  not in  (select  id_app  from  Szw_zz_fj_temp  where  yydh='" + common_file.common_app.yydh + "'  and czy='" + common_file.common_app.czy_GUID + "')  order by xfsj   asc ");

            }
            if (ds_xyjl_temp != null && ds_xyjl_temp.Tables[0].Rows.Count > 0)
            {
                BS_xyjl.DataSource = ds_xyjl_temp.Tables[0];
                dg_xyjl_count = ds_xyjl_temp.Tables[0].Rows.Count;
                dg_xyjl.DataSource = BS_xyjl;
            }
            else
            {
                dg_xyjl_count = 0;
                dg_xyjl.DataSource = null;
            }
        }
        private void BindData_dg_xzjl()
        {
            dg_xzjl.AutoGenerateColumns = false;
            BLL.Common B_Common = new Hotel_app.BLL.Common();

            if (jzbh == "")
            {

                if (czzt == common_file.common_jzzt.czzt_bfsz)
                {
                    DataSet ds_00 = B_Common.GetList(" select * from Flfsz  ", "  id>=0  and  yydh='" + common_file.common_app.yydh + "'  and     lfbh  in  (select  lfbh  from  Flfsz  where lsbh='" + lsbh + "'  and  yydh='" + common_file.common_app.yydh + "'   and shlz='1'  )   and shlz='1' ");
                    if (ds_00 != null && ds_00.Tables[0].Rows.Count > 0)
                    {
                        string temp = " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and (lsbh in (select lsbh from Flfsz where lfbh in (select lfbh from Flfsz where lsbh='" + lsbh + "' and yydh='" + common_file.common_app.yydh + "' and shlz=1 ))  and shlz=1  )   and  id_app  not in  (select  id_app  from  Szw_zz_fj_temp  where  yydh='" + common_file.common_app.yydh + "'  and czy='" + common_file.common_app.czy_GUID + "')  order by fjbh,xfsj   asc ";
                        ds_xzjl_temp = B_common.GetList("select  *  from  Szwmx  ", " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and (lsbh in (select lsbh from Flfsz where lfbh in (select lfbh from Flfsz where lsbh='" + lsbh + "' and yydh='" + common_file.common_app.yydh + "' and shlz=1 )   and shlz=1))   and  id_app   in  (select  id_app  from  Szw_zz_fj_temp  where  yydh='" + common_file.common_app.yydh + "'  and czy='" + common_file.common_app.czy_GUID + "')  order by xfsj   asc,fjbh ");
                    }
                    else
                    {
                        ds_xzjl_temp = B_common.GetList("select  *  from  Szwmx  ", " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  lsbh='" + lsbh + "'  and  id_app   in  (select  id_app  from  Szw_zz_fj_temp  where  yydh='" + common_file.common_app.yydh + "'  and czy='" + common_file.common_app.czy_GUID + "')  order by  fjbh,xfsj asc ");

                    }
                }
                if (czzt != common_file.common_jzzt.czzt_bfsz)
                {
                    ds_xzjl_temp = B_common.GetList("select  *  from  Szwmx  ", " id>=0  and  yydh='" + common_file.common_app.yydh + "'  and  lsbh='" + lsbh + "'  and  id_app   in  (select  id_app  from  Szw_zz_fj_temp  where  yydh='" + common_file.common_app.yydh + "'  and czy='" + common_file.common_app.czy_GUID + "')  order by  fjbh,xfsj asc ");
                }
            }
            if (jzbh != "")
            {
                ds_xzjl_temp = B_common.GetList(" select * from Szwmx ", "id>=0  and  yydh='" + common_file.common_app.yydh + "'  and jzbh='" + jzbh + "'  and id_app  in (select id_app from Szw_zz_fj_temp  where yydh='" + common_file.common_app.yydh + "'  and czy='" + common_file.common_app.czy_GUID + "')  order by fjbh,xfsj asc");
            }

            if (ds_xzjl_temp != null && ds_xzjl_temp.Tables[0].Rows.Count > 0)
            {
                BS_xzjl.DataSource = ds_xzjl_temp.Tables[0];
                dg_xzjl_count = ds_xzjl_temp.Tables[0].Rows.Count;
                dg_xzjl.DataSource = BS_xzjl;
            }
            else
            {
                dg_xzjl.DataSource = null;
                dg_xzjl_count = 0;
            }
        }


        //选择的行，operateType要进行的操作类型(全选(selectAll),全消(cancelAll),选择多行(selectMulti),取消多行(cancelMulti))
        //list指要传递的包含id_app的字符串数组
        private void Btn_operate(List<string> lists, string operateType)
        {
            string id_app_temp = "";
            //有消费记录,将当前所有的记录都插入到Szw_zz_fj_temp表
            if (operateType == "SelectAll")
            {
                foreach (string _id_app in lists)
                {
                    id_app_temp = _id_app;
                    strsql = new StringBuilder();
                    strsql.Append(" insert into  Szw_zz_fj_temp(yydh,qymc,jzbh,id_app,lsbh,czy,czsj)");
                    strsql.Append("  select   yydh,qymc,jzbh,id_app,lsbh,'" + common_file.common_app.czy_GUID + "','" + DateTime.Now.ToString() + "' from  Szwmx ");
                    strsql.Append(" where id>=0  and yydh='" + common_file.common_app.yydh + "' and  id_app='" + id_app_temp + "'");
                    B_common.ExecuteSql(strsql.ToString());
                }
            }
            if (operateType == "CancelAll")
            {
                foreach (string _id_app in lists)
                {
                    id_app_temp = _id_app;
                    Fun_chaiZhang_cx(id_app_temp);
                }
            }

            //取消多条
            if (operateType == "CancelMulti")
            {
                foreach (string _id_app in lists)
                {
                    id_app_temp = _id_app;
                    Fun_chaiZhang_cx(id_app_temp);
                }
            }

            //选择多条
            if (operateType == "SelectMulti")
            {
                foreach (string _id_app in lists)
                {
                    id_app_temp = _id_app;
                    strsql = new StringBuilder();
                    strsql.Append(" insert into  Szw_zz_fj_temp(yydh,qymc,jzbh,id_app,lsbh,czy,czsj)");
                    strsql.Append("  select   yydh,qymc,jzbh,id_app,lsbh,'" + common_file.common_app.czy_GUID + "','" + DateTime.Now.ToString() + "' from  Szwmx ");
                    strsql.Append(" where id>=0  and yydh='" + common_file.common_app.yydh + "' and  id_app='" + id_app_temp + "'");
                    B_common.ExecuteSql(strsql.ToString());
                }
            }

            //通过时间选择记录
            if (operateType == "selectByTime")
            {
                //找出消费时间在dt1和dt2之间的记录，添加到Szw_zz_fj_temp中
                strsql = new StringBuilder();
                strsql.Append(" insert into  Szw_zz_fj_temp(yydh,qymc,jzbh,id_app,lsbh,czy,czsj)");
                strsql.Append("  select   yydh,qymc,jzbh,id_app,lsbh,'" + common_file.common_app.czy_GUID + "','" + DateTime.Now.ToString() + "' from  Szwmx ");
                strsql.Append(" where id>=0  and yydh='" + common_file.common_app.yydh + "' and  xfsj>='" + dt1 + "'  and  xfsj<='" + dt2 + "'  and  id_app not in (select id_app  from Szw_zz_fj_temp  where  czy='" + common_file.common_app.czy_GUID + "')  ");
                B_common.ExecuteSql(strsql.ToString());
                //绑定
                BindData_dg_xyjl();
                BindData_dg_xzjl();
            }

            //通过比例计算出消费金额，然后按金额的方法进行拆帐处理
            if (operateType == "selectByPercent")//通过比例选择记录
            {
                decimal sum = 0;
                for (int i = 0; i < dg_xyjl.Rows.Count; i++)
                {
                    if (dg_xyjl.Rows[i].Cells["sjxfje"].Value != null)
                    {
                        sum += decimal.Parse(dg_xyjl.Rows[i].Cells["sjxfje"].Value.ToString());
                    }
                }
                Fun_chaiZ(sum * percent);
                tb_fz.Text = ""; //清空分子
                tb_fm.Text = "";//清空分母
            }

            //通过金额选择记录
            if (operateType == "selectByMoney")
            {
                Fun_chaiZ(decimal.Parse(tb_fjje.Text.Trim()));
                tb_fjje.Text = "";
            }
            BindData_dg_xyjl();
            BindData_dg_xzjl();
        }

        private void b_fjfs_Click(object sender, EventArgs e)
        {
            if (b_fjfs.Text == "比例")
            {
                b_fjfs.Text = "时间";
                tb_fz.Visible = true;
                tb_fm.Visible = true;
                lbl_operate.Visible = true;
                dT_begin.Visible = false;
                dt_end.Visible = false;
                return;
            }
            if (b_fjfs.Text == "时间")
            {
                b_fjfs.Text = "比例";
                dT_begin.Visible = true;
                dt_end.Visible = true;
                tb_fz.Visible = false;
                tb_fm.Visible = false;
                lbl_operate.Visible = false;
                return;
            }
        }

        private void b_save_je_Click(object sender, EventArgs e)
        {
            if (((Maticsoft.Common.PageValidate.IsDecimal(tb_fjje.Text.Trim())) || (Maticsoft.Common.PageValidate.IsNumber(tb_fjje.Text.Trim()))) == false)
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的金额不是有效数字！");
                tb_fjje.Focus();
                tb_fjje.SelectAll();
                return;
            }
            Btn_operate(lists_id__app, "selectByMoney");
        }

        private void b_save_fjfs_Click(object sender, EventArgs e)
        {
            if (b_fjfs.Text == "比例")
            {
                dt1 = dT_begin.Value.Date;                //要结帐务起始时间
                dt2 = dt_end.Value.Date.AddDays(1);   //要结帐务终止时间
                if (dt2 < dt1)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "请正确选择终止时间");
                    return;
                }
                Btn_operate(lists_id__app, "selectByTime");
            }
            if (b_fjfs.Text == "时间")
            {
                if (((Maticsoft.Common.PageValidate.IsDecimal(tb_fz.Text.Trim())) || (Maticsoft.Common.PageValidate.IsNumber(tb_fz.Text.Trim()))) == false)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的金额不是有效数字！");
                    tb_fz.Focus();
                    tb_fz.SelectAll();
                    return;
                }
                if (((Maticsoft.Common.PageValidate.IsDecimal(tb_fm.Text.Trim())) || (Maticsoft.Common.PageValidate.IsNumber(tb_fm.Text.Trim()))) == false)
                {
                    common_file.common_app.Message_box_show(common_file.common_app.message_title, "对不起，所输入的金额不是有效数字！");
                    tb_fm.Focus();
                    tb_fm.SelectAll();
                    return;
                }
                //计算出根据比例算出来的金额
                percent = decimal.Parse(tb_fz.Text.Trim()) / decimal.Parse(tb_fm.Text.Trim());
                Btn_operate(lists_id__app, "selectByPercent");
            }
        }

        //判断哪条记录要进行分拆,然后调用chaizhang方法
        private void Fun_chaiZ(decimal _fjje)
        {
            id_app_temp_1 = "";//要进行拆帐的那条记录的ID_App的值 
            fjje = _fjje;//decimal.Parse(tb_fjje.Text.Trim());
            ljje = 0;
            je_need = 0;//要拆出的金额（ljje与fjje的差额）
            je_last = 0;//拆出后剩下的金额数
            lists_id__app = new List<string>();
            //循环dg_xyjl4
            for (int i = 0; i < dg_xyjl.Rows.Count; i++)
            {
                if (dg_xyjl.Rows[i].Cells["sjxfje"].Value != null && dg_xyjl.Rows[i].Cells["sjxfje"].Value.ToString().Trim() != "")
                {
                    id_app_temp_1 = dg_xyjl.Rows[i].Cells["id_app"].Value.ToString();
                    ljje += decimal.Parse(dg_xyjl.Rows[i].Cells["sjxfje"].Value.ToString());
                    if (ljje > fjje)//累计金额>分结金额时,就要拆帐
                    {
                        //获取当前的这条记录的id_app进行拆帐
                        M_Szwmx = B_Szwmx.GetModelList(" id>=0  and yydh='" + common_file.common_app.yydh + "'  and  id_app='" + id_app_temp_1 + "'")[0];
                        je_need = fjje - (ljje - M_Szwmx.sjxfje);// fjje - ljje;//要拆出来的金额
                        je_last = M_Szwmx.sjxfje - je_need;
                        //金额找出来后
                        //生成新的union_bh,id_app
                        string Union_bh_new = common_file.common_ddbh.ddbh("lzbh", "szdate", "szcounter", 6);//算帐操作
                        string id_app_new = "";
                        if (czzt == common_file.common_jzzt.czzt_bfsz)//部分算帐
                        {
                            id_app_new = common_file.common_ddbh.ddbh("bfjz", "jzdate", "jzcounter", 6);//前缀保留成部分结帐
                        }
                        if (czzt == common_file.common_jzzt.czzt_gz||czzt==common_file.common_jzzt.czzt_jzzgz)
                        {
                            id_app_new = common_file.common_ddbh.ddbh("gzfj", "jzdate", "jzcounter", 6);//前缀保留成挂帐分结
                        }
                        if (czzt == common_file.common_jzzt.czzt_jz||czzt==common_file.common_jzzt.czzt_gzzjz)//记帐分结
                        {
                            id_app_new = common_file.common_ddbh.ddbh("jzfj", "jzdate", "jzcounter", 6);
                        }
                        if (czzt == common_file.common_jzzt.czzt_zz)//在住转帐的时候
                        {                           //标识为部分转帐
                            id_app_new = common_file.common_ddbh.ddbh("bfzz", "jzdate", "jzcounter", 6);
                        }
                        //将原来的一条拆成两条(包括Szwmx以及Ssyxfxm，向Szw_union写入两条记录，除金额不一样,其它保持一致
                        if (czzt == common_file.common_jzzt.czzt_bfsz)
                        {
                            SfjczHelper.Fun_fj_chaizhang(id_app_temp_1, id_app_new, Union_bh_new, je_need, je_last, common_file.common_jzzt.czzt_bfsz, DateTime.Now.ToString(),"1");
                        }
                        if (czzt == common_file.common_jzzt.czzt_jz || czzt == common_file.common_jzzt.czzt_gzzjz)
                        { SfjczHelper.Fun_fj_chaizhang(id_app_temp_1, id_app_new, Union_bh_new, je_need, je_last, common_file.common_jzzt.czzt_jzfj, DateTime.Now.ToString(),"1"); }
                        if (czzt == common_file.common_jzzt.czzt_gz || czzt == common_file.common_jzzt.czzt_jzzgz)
                        {
                            SfjczHelper.Fun_fj_chaizhang(id_app_temp_1, id_app_new, Union_bh_new, je_need, je_last, common_file.common_jzzt.czzt_gzfj, DateTime.Now.ToString(),"1");
                        }
                        if (czzt == common_file.common_jzzt.czzt_zz)
                        {
                            SfjczHelper.Fun_fj_chaizhang(id_app_temp_1, id_app_new, Union_bh_new, je_need, je_last, common_file.common_jzzt.czzt_zz, DateTime.Now.ToString(),"1");
                        }
                    }
                    else if (ljje <= fjje)
                    {
                        //将这条记录写入到Szw_zz_fj_temp
                        strsql = new StringBuilder();
                        strsql.Append("insert into  Szw_zz_fj_temp(yydh,qymc,jzbh,id_app,lsbh,czy,czsj)");
                        strsql.Append("   select  yydh,qymc,jzbh,'" + id_app_temp_1 + "',lsbh,'" + common_file.common_app.czy_GUID + "','" + DateTime.Now.ToString() + "'  from  Szwmx ");
                        strsql.Append("  where  id_app='" + id_app_temp_1 + "'");
                        B_common.ExecuteSql(strsql.ToString());
                        if (ljje < fjje)
                        {
                            continue;//这里先把数据加进去(最后再绑定数据)
                        }
                    }
                    break;//刷新的时候就直接跳出去
                }
            }
            BindData_dg_xyjl();
            BindData_dg_xzjl();
        }

        private void Fun_chaiZhang_cx(string id_app_1)
        {
            SfjczHelper.Fun_fj_chaizhang_cx(id_app_1, czzt,jzbh);
        }

        private void b_zz_Click(object sender, EventArgs e)
        {
            common_file.common_app.get_czsj();
            if (dg_xzjl.Rows.Count > 0)
            {
                if (czzt != common_file.common_jzzt.czzt_zz)
                {
                    Szwcz Frm_Szwcz_new = new Szwcz();
                    Frm_Szwcz_new.InitalApp(czzt, lsbh, jzbh, sk_tt, "Sfjcz");
                    Frm_Szwcz_new.StartPosition = FormStartPosition.CenterScreen;
                    if (Frm_Szwcz_new.ShowDialog() == DialogResult.OK)
                    {
                        BindData_dg_xyjl();
                        BindData_dg_xzjl();
                    }
                }

                if (czzt == common_file.common_jzzt.czzt_zz)//在住转帐
                {
                    string load_type = "";
                    if (this.sk_tt == "sk")
                    {
                        id = DbHelperSQL.GetSingle("select ID  FROM  Qskyd_mainrecord where lsbh='" + lsbh + "' and yydh='" + common_file.common_app.yydh + "'").ToString();
                        load_type = "skzz";//散客转帐
                    }
                    if (this.sk_tt == "tt")
                    {
                        id = DbHelperSQL.GetSingle("select id from  Qttyd_mainrecord where lsbh='" + lsbh + "'  and yydh='" + common_file.common_app.yydh + "'").ToString();
                        load_type = "ttzz";//团体转帐
                    }
                    //这里传散客或团体主单的ID
                    Qyddj.Q_sk_tt_app Q_sk_tt_app_new = new Hotel_app.Qyddj.Q_sk_tt_app(id, common_file.common_yddj.yddj_dj, load_type);
                    Q_sk_tt_app_new.StartPosition = FormStartPosition.CenterScreen;
                    if (Q_sk_tt_app_new.ShowDialog() == DialogResult.OK)
                    {
                        BindData_dg_xyjl();
                        BindData_dg_xzjl();
                    }
                }
            }
            else
            {
                common_file.common_app.Message_box_show(common_file.common_app.message_title, "没有选择要分结的帐务或者金额");
            }
            Cursor.Current = Cursors.Default;
        }

        private void Sfjcz_FormClosing(object sender, FormClosingEventArgs e)
        {
            //注意，在关闭这个窗体的时候，同时关闭Szw_Common_check这个
            if (common_file.common_form.Szw_Common_check_new != null || (common_file.common_form.Szw_Common_check_new != null && common_file.common_form.Szw_Common_check_new.IsDisposed == false))
            {
                //hbfcjl();
                common_file.common_form.Szw_Common_check_new.Dispose();
            }
            if (czzt == common_file.common_jzzt.czzt_bfsz)
            {
                if (common_file.common_form.Szwcl_new != null || (common_file.common_form.Szwcl_new != null && common_file.common_form.Szwcl_new.IsDisposed == false))
                {
                    hbfcjl();
                    common_file.common_form.ShowFrm_Szwcl_new(lsbh, sk_tt, common_file.common_app.czy_GUID,false);
                }
            }
            if (czzt == common_file.common_jzzt.czzt_gzfj || czzt == common_file.common_jzzt.czzt_jzfj)
            {
                hbfcjl();
            }
            if (czzt == common_file.common_jzzt.czzt_zz)
            {
                if (common_file.common_form.Szwcl_new != null || (common_file.common_form.Szwcl_new != null && common_file.common_form.Szwcl_new.IsDisposed == false))
                {
                    hbfcjl();
                    common_file.common_form.ShowFrm_Szwcl_new(lsbh, sk_tt, common_file.common_app.czy_GUID,false);
                }
            }
        }

        //合并分拆的记录,
        private void hbfcjl()
        {
            if (jzbh != "")
            {
                ds_temp = B_common.GetList(" select  id_app  from  Szw_union", " id_app  in (select id_app  from Szwmx where  lsbh='"+lsbh+"'  and   jzbh='" + jzbh + "'  and jzbh!='')");
                if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
                {
                    //执行全选和全消的过程
                    lists_id__app.Clear();//注意这里要先清除所有的
                    for (int i = 0; i < ds_xyjl_temp.Tables[0].Rows.Count; i++)
                    {


                        lists_id__app.Add(ds_xyjl_temp.Tables[0].Rows[i]["id_app"].ToString());
                    }
                    if (lists_id__app.Count > 0)
                    {
                        Btn_operate(lists_id__app, "SelectAll");
                    }
                    lists_id__app.Clear();//注意这里要先清除所有的
                    for (int i = 0; i < ds_xzjl_temp.Tables[0].Rows.Count; i++)
                    { lists_id__app.Add(ds_xzjl_temp.Tables[0].Rows[i]["id_app"].ToString()); }

                    if (lists_id__app.Count > 0)
                    {
                        Btn_operate(lists_id__app, "CancelAll");
                    }
                    hbfcjl();
                }
            }
            //if (jzbh.Trim() == "")
            //{
            //    ds_temp = B_common.GetList(" select  id_app  from  Szw_union", " id_app  in (select id_app  from Szw_zz_fj_temp  where  id>=0   and jzbh=''  and  czy='" + common_file.common_app.czy + "')");
            //    //执行全选和全消的过程
            //    if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
            //    {
            //        lists_id__app.Clear();//注意这里要先清除所有的
            //        for (int i = 0; i < ds_xyjl_temp.Tables[0].Rows.Count; i++)
            //        {


            //            lists_id__app.Add(ds_xyjl_temp.Tables[0].Rows[i]["id_app"].ToString());
            //        }
            //        if (lists_id__app.Count > 0)
            //        {
            //            Btn_operate(lists_id__app, "SelectAll");
            //        }
            //        lists_id__app.Clear();//注意这里要先清除所有的
            //        for (int i = 0; i < ds_xzjl_temp.Tables[0].Rows.Count; i++)
            //        { lists_id__app.Add(ds_xzjl_temp.Tables[0].Rows[i]["id_app"].ToString()); }

            //        if (lists_id__app.Count > 0)
            //        {
            //            Btn_operate(lists_id__app, "CancelAll");
            //        }
            //    }
            //    //hbfcjl();
            //}
        }

        private void b_dc_Click(object sender, EventArgs e)
        {
            //
            if (dg_xyjl.CurrentRow != null && dg_xyjl.CurrentRow.Index > -1)
            {

                int i_000 = 0;
                i_000 = dg_xyjl.CurrentRow.Index;

                DataRowView dgr = dg_xyjl.Rows[i_000].DataBoundItem as DataRowView;
                i_000 = ds_xyjl_temp.Tables[0].Rows.IndexOf(dgr.Row);
                object obj_temp = ds_xyjl_temp.Tables[0].Rows[i_000]["id_app"];
                if (obj_temp != null)
                { 
                    string id_app_old = obj_temp.ToString();
                    //执行拆账的操作
                    string Union_bh_new = common_file.common_ddbh.ddbh("lzbh", "szdate", "szcounter", 6);//算帐操作
                    string id_app_new = "";
                    if (czzt == common_file.common_jzzt.czzt_bfsz)//部分算帐
                    {
                        id_app_new = common_file.common_ddbh.ddbh("bfjz", "jzdate", "jzcounter", 6);//前缀保留成部分结帐
                    }
                    if (czzt == common_file.common_jzzt.czzt_gz || czzt == common_file.common_jzzt.czzt_jzzgz)
                    {
                        id_app_new = common_file.common_ddbh.ddbh("gzfj", "jzdate", "jzcounter", 6);//前缀保留成挂帐分结
                    }
                    if (czzt == common_file.common_jzzt.czzt_jz || czzt == common_file.common_jzzt.czzt_gzzjz)//记帐分结
                    {
                        id_app_new = common_file.common_ddbh.ddbh("jzfj", "jzdate", "jzcounter", 6);
                    }
                    if (czzt == common_file.common_jzzt.czzt_zz)//在住转帐的时候
                    {                           //标识为部分转帐
                        id_app_new = common_file.common_ddbh.ddbh("bfzz", "jzdate", "jzcounter", 6);
                    }
                    S_dc s_dc_new = new S_dc();

                    int i_00 = 0;
                    i_00 = dg_xyjl.CurrentRow.Index;
                    DataRowView dgr_0 = dg_xyjl.Rows[i_00].DataBoundItem as DataRowView;
                    i_00 = ds_xyjl_temp.Tables[0].Rows.IndexOf(dgr_0.Row);


                    s_dc_new.inital(ds_xyjl_temp.Tables[0].Rows[i_00]["xfxm"].ToString(), ds_xyjl_temp.Tables[0].Rows[i_00]["sjxfje"].ToString(), ds_xyjl_temp.Tables[0].Rows[i_00]["xfsj"].ToString(), id_app_old, id_app_new, Union_bh_new, czzt);
    
                    if (s_dc_new.ShowDialog() == DialogResult.OK)
                    {
                        BindData_dg_xyjl();
                        BindData_dg_xzjl();
                    }
                    //SfjczHelper.Fun_fj_chaizhang(id_app_old,id_app_new,Union_bh_new,
                }
            }
        }
    }
}