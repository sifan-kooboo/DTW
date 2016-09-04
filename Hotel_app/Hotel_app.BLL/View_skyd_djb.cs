using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// View_skyd_djb
	/// </summary>
	public partial class View_skyd_djb
	{
		private readonly Hotel_app.DAL.View_skyd_djb dal=new Hotel_app.DAL.View_skyd_djb();
		public View_skyd_djb()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Hotel_app.Model.View_skyd_djb model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.View_skyd_djb model)
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
		public Hotel_app.Model.View_skyd_djb GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.View_skyd_djb GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "View_skyd_djbModel-" ;
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
			return (Hotel_app.Model.View_skyd_djb)objModel;
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
		public List<Hotel_app.Model.View_skyd_djb> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.View_skyd_djb> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.View_skyd_djb> modelList = new List<Hotel_app.Model.View_skyd_djb>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.View_skyd_djb model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.View_skyd_djb();
					if(dt.Rows[n]["yydh"]!=null && dt.Rows[n]["yydh"].ToString()!="")
					{
					model.yydh=dt.Rows[n]["yydh"].ToString();
					}
					if(dt.Rows[n]["qymc"]!=null && dt.Rows[n]["qymc"].ToString()!="")
					{
					model.qymc=dt.Rows[n]["qymc"].ToString();
					}
					if(dt.Rows[n]["krxm"]!=null && dt.Rows[n]["krxm"].ToString()!="")
					{
					model.krxm=dt.Rows[n]["krxm"].ToString();
					}
					if(dt.Rows[n]["ddly"]!=null && dt.Rows[n]["ddly"].ToString()!="")
					{
					model.ddly=dt.Rows[n]["ddly"].ToString();
					}
					if(dt.Rows[n]["krxb"]!=null && dt.Rows[n]["krxb"].ToString()!="")
					{
					model.krxb=dt.Rows[n]["krxb"].ToString();
					}
					if(dt.Rows[n]["krjg"]!=null && dt.Rows[n]["krjg"].ToString()!="")
					{
					model.krjg=dt.Rows[n]["krjg"].ToString();
					}
					if(dt.Rows[n]["krzy"]!=null && dt.Rows[n]["krzy"].ToString()!="")
					{
					model.krzy=dt.Rows[n]["krzy"].ToString();
					}
					if(dt.Rows[n]["krmz"]!=null && dt.Rows[n]["krmz"].ToString()!="")
					{
					model.krmz=dt.Rows[n]["krmz"].ToString();
					}
					if(dt.Rows[n]["fjbh"]!=null && dt.Rows[n]["fjbh"].ToString()!="")
					{
					model.fjbh=dt.Rows[n]["fjbh"].ToString();
					}
					if(dt.Rows[n]["krsr"]!=null && dt.Rows[n]["krsr"].ToString()!="")
					{
						model.krsr=DateTime.Parse(dt.Rows[n]["krsr"].ToString());
					}
					if(dt.Rows[n]["krsj"]!=null && dt.Rows[n]["krsj"].ToString()!="")
					{
					model.krsj=dt.Rows[n]["krsj"].ToString();
					}
					if(dt.Rows[n]["lzts"]!=null && dt.Rows[n]["lzts"].ToString()!="")
					{
						model.lzts=int.Parse(dt.Rows[n]["lzts"].ToString());
					}
					if(dt.Rows[n]["ddsj"]!=null && dt.Rows[n]["ddsj"].ToString()!="")
					{
						model.ddsj=DateTime.Parse(dt.Rows[n]["ddsj"].ToString());
					}
					if(dt.Rows[n]["lksj"]!=null && dt.Rows[n]["lksj"].ToString()!="")
					{
						model.lksj=DateTime.Parse(dt.Rows[n]["lksj"].ToString());
					}
					if(dt.Rows[n]["xydw"]!=null && dt.Rows[n]["xydw"].ToString()!="")
					{
					model.xydw=dt.Rows[n]["xydw"].ToString();
					}
					if(dt.Rows[n]["lsbh"]!=null && dt.Rows[n]["lsbh"].ToString()!="")
					{
					model.lsbh=dt.Rows[n]["lsbh"].ToString();
					}
					if(dt.Rows[n]["yxzj"]!=null && dt.Rows[n]["yxzj"].ToString()!="")
					{
					model.yxzj=dt.Rows[n]["yxzj"].ToString();
					}
					if(dt.Rows[n]["zjhm"]!=null && dt.Rows[n]["zjhm"].ToString()!="")
					{
					model.zjhm=dt.Rows[n]["zjhm"].ToString();
					}
					if(dt.Rows[n]["krdz"]!=null && dt.Rows[n]["krdz"].ToString()!="")
					{
					model.krdz=dt.Rows[n]["krdz"].ToString();
					}
					if(dt.Rows[n]["krdw"]!=null && dt.Rows[n]["krdw"].ToString()!="")
					{
					model.krdw=dt.Rows[n]["krdw"].ToString();
					}
					if(dt.Rows[n]["sjfjjg"]!=null && dt.Rows[n]["sjfjjg"].ToString()!="")
					{
						model.sjfjjg=decimal.Parse(dt.Rows[n]["sjfjjg"].ToString());
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

