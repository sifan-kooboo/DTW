using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_app.Szwgl
{
    public partial class Sxfrb : Form
    {
        public Sxfrb()
        {
            InitializeComponent();
            Tv_Xfxm.Nodes.Clear();//初始化时清除掉所有节点
            CreateTv_Xxfxm();
        }

        public Hotel_app.Model.Xxfdr M_Xxfdr;
        public Hotel_app.BLL.Xxfdr B_Xxfdr = new Hotel_app.BLL.Xxfdr();
        public Hotel_app.BLL.Xxfxr B_Xxfxr = new Hotel_app.BLL.Xxfxr();
        public DataSet ds_temp;
        public DataSet ds_temp_xfxr;
        public string get_xfxm_bh;

        public void CreateTv_Xxfxm()
        {
           //加载一级节点
            ds_temp = B_Xxfdr.GetList("id>=0  " + common_file.common_app.yydh_select);//选择所有
            if (ds_temp != null && ds_temp.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds_temp.Tables[0].Rows.Count ; i++)
                {
                    TreeNode tn_xfdr = new TreeNode();
                    tn_xfdr.Text = ds_temp.Tables[0].Rows[i]["xfdr"].ToString();
                    tn_xfdr.Name = "消费大类:" + tn_xfdr.Text;
                    tn_xfdr.Tag = (object)("消费大类:" + ds_temp.Tables[0].Rows[i]["drbh"].ToString() + "|" + tn_xfdr.Text);//消费大类:大类编号
                    Tv_Xfxm.Nodes.Add(tn_xfdr); //添加大类
                    GenerateChildNodes(tn_xfdr);//添加大类下面的小类
                }
                Tv_Xfxm.ExpandAll();
            }
        }



        public void GenerateChildNodes(TreeNode tn)
        {
            string[] info = tn.Tag.ToString().Split('|');
            string drbh_temp = info[0].Split(':')[1];
            //由drbh加载消费小类
            ds_temp_xfxr = B_Xxfxr.GetList("id>=0  " + common_file.common_app.yydh_select + "  and  drbh='" + drbh_temp + "'");
            if (ds_temp_xfxr != null && ds_temp_xfxr.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds_temp_xfxr.Tables[0].Rows.Count; i++)
                {
                    TreeNode tn_childnode = new TreeNode();
                    tn_childnode.Text = ds_temp_xfxr.Tables[0].Rows[i]["xfxr"].ToString();
                    tn_childnode.Name = "消费小类:" + tn_childnode.Text;
                    tn_childnode.Tag = (object)("消费小类:" + ds_temp_xfxr.Tables[0].Rows[i]["xrbh"].ToString() + "|" + tn_childnode.Text);
                    Tv_Xfxm.Nodes[tn.Name].Nodes.Add(tn_childnode);
                }
            }
        }

        private void Tv_Xfxm_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //双击节点时有小类就展开，没有小类就直接获取访大类的值
            if (e.Node != null)
            {
                TreeNode selectNode = e.Node;
                if (e.Node.Nodes.Count == 0)//直接获取此类的值
                {
                    //
                    //这里还要判断是否直接选的大类(2.15处理)
                    //
                    
                    get_xfxm_bh = selectNode.Tag.ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}