using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// View_zdkr_mx_temp
	/// </summary>
	public partial class View_zdkr_mx_temp
	{
		private readonly Hotel_app.DAL.View_zdkr_mx_temp dal=new Hotel_app.DAL.View_zdkr_mx_temp();
		public View_zdkr_mx_temp()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.View_zdkr_mx_temp model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.View_zdkr_mx_temp model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Hotel_app.Model.View_zdkr_mx_temp GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.View_zdkr_mx_temp GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "View_zdkr_mx_tempModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Hotel_app.Model.View_zdkr_mx_temp)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.View_zdkr_mx_temp> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.View_zdkr_mx_temp> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.View_zdkr_mx_temp> modelList = new List<Hotel_app.Model.View_zdkr_mx_temp>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.View_zdkr_mx_temp model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.View_zdkr_mx_temp();
					if(dt.Rows[n]["jdlh_name"]!=null && dt.Rows[n]["jdlh_name"].ToString()!="")
					{
					model.jdlh_name=dt.Rows[n]["jdlh_name"].ToString();
					}
					if(dt.Rows[n]["jdcs_name"]!=null && dt.Rows[n]["jdcs_name"].ToString()!="")
					{
					model.jdcs_name=dt.Rows[n]["jdcs_name"].ToString();
					}
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["qymc"]!=null && dt.Rows[n]["qymc"].ToString()!="")
					{
					model.qymc=dt.Rows[n]["qymc"].ToString();
					}
					if(dt.Rows[n]["yydh"]!=null && dt.Rows[n]["yydh"].ToString()!="")
					{
					model.yydh=dt.Rows[n]["yydh"].ToString();
					}
					if(dt.Rows[n]["lsbh"]!=null && dt.Rows[n]["lsbh"].ToString()!="")
					{
					model.lsbh=dt.Rows[n]["lsbh"].ToString();
					}
					if(dt.Rows[n]["krxm"]!=null && dt.Rows[n]["krxm"].ToString()!="")
					{
					model.krxm=dt.Rows[n]["krxm"].ToString();
					}
					if(dt.Rows[n]["xydw"]!=null && dt.Rows[n]["xydw"].ToString()!="")
					{
					model.xydw=dt.Rows[n]["xydw"].ToString();
					}
					if(dt.Rows[n]["krly"]!=null && dt.Rows[n]["krly"].ToString()!="")
					{
					model.krly=dt.Rows[n]["krly"].ToString();
					}
					if(dt.Rows[n]["xsy"]!=null && dt.Rows[n]["xsy"].ToString()!="")
					{
					model.xsy=dt.Rows[n]["xsy"].ToString();
					}
					if(dt.Rows[n]["ddsj"]!=null && dt.Rows[n]["ddsj"].ToString()!="")
					{
						model.ddsj=DateTime.Parse(dt.Rows[n]["ddsj"].ToString());
					}
					if(dt.Rows[n]["lksj"]!=null && dt.Rows[n]["lksj"].ToString()!="")
					{
						model.lksj=DateTime.Parse(dt.Rows[n]["lksj"].ToString());
					}
					if(dt.Rows[n]["czy"]!=null && dt.Rows[n]["czy"].ToString()!="")
					{
					model.czy=dt.Rows[n]["czy"].ToString();
					}
					if(dt.Rows[n]["sktt"]!=null && dt.Rows[n]["sktt"].ToString()!="")
					{
					model.sktt=dt.Rows[n]["sktt"].ToString();
					}
					if(dt.Rows[n]["fjrb"]!=null && dt.Rows[n]["fjrb"].ToString()!="")
					{
					model.fjrb=dt.Rows[n]["fjrb"].ToString();
					}
					if(dt.Rows[n]["fjbh"]!=null && dt.Rows[n]["fjbh"].ToString()!="")
					{
					model.fjbh=dt.Rows[n]["fjbh"].ToString();
					}
					if(dt.Rows[n]["lzrs"]!=null && dt.Rows[n]["lzrs"].ToString()!="")
					{
						model.lzrs=decimal.Parse(dt.Rows[n]["lzrs"].ToString());
					}
					if(dt.Rows[n]["lzfs"]!=null && dt.Rows[n]["lzfs"].ToString()!="")
					{
						model.lzfs=decimal.Parse(dt.Rows[n]["lzfs"].ToString());
					}
					if(dt.Rows[n]["dqff"]!=null && dt.Rows[n]["dqff"].ToString()!="")
					{
						model.dqff=decimal.Parse(dt.Rows[n]["dqff"].ToString());
					}
					if(dt.Rows[n]["ddbh"]!=null && dt.Rows[n]["ddbh"].ToString()!="")
					{
					model.ddbh=dt.Rows[n]["ddbh"].ToString();
					}
					if(dt.Rows[n]["zjhm"]!=null && dt.Rows[n]["zjhm"].ToString()!="")
					{
					model.zjhm=dt.Rows[n]["zjhm"].ToString();
					}
					if(dt.Rows[n]["bz"]!=null && dt.Rows[n]["bz"].ToString()!="")
					{
					model.bz=dt.Rows[n]["bz"].ToString();
					}
					if(dt.Rows[n]["czy_temp"]!=null && dt.Rows[n]["czy_temp"].ToString()!="")
					{
					model.czy_temp=dt.Rows[n]["czy_temp"].ToString();
					}
					if(dt.Rows[n]["main_sec"]!=null && dt.Rows[n]["main_sec"].ToString()!="")
					{
					model.main_sec=dt.Rows[n]["main_sec"].ToString();
					}
					if(dt.Rows[n]["krxb"]!=null && dt.Rows[n]["krxb"].ToString()!="")
					{
					model.krxb=dt.Rows[n]["krxb"].ToString();
					}
					if(dt.Rows[n]["sjfjjg"]!=null && dt.Rows[n]["sjfjjg"].ToString()!="")
					{
						model.sjfjjg=decimal.Parse(dt.Rows[n]["sjfjjg"].ToString());
					}
					if(dt.Rows[n]["yddj"]!=null && dt.Rows[n]["yddj"].ToString()!="")
					{
					model.yddj=dt.Rows[n]["yddj"].ToString();
					}
					if(dt.Rows[n]["shqh"]!=null && dt.Rows[n]["shqh"].ToString()!="")
					{
					model.shqh=dt.Rows[n]["shqh"].ToString();
					}
					if(dt.Rows[n]["Expr1"]!=null && dt.Rows[n]["Expr1"].ToString()!="")
					{
					model.Expr1=dt.Rows[n]["Expr1"].ToString();
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

