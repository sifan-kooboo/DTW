using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using jdgl_res_head_app.Model;
namespace jdgl_res_head_app.BLL
{
	/// <summary>
	/// Ssyxfmx_cz
	/// </summary>
	public partial class Ssyxfmx_cz
	{
		private readonly jdgl_res_head_app.DAL.Ssyxfmx_cz dal=new jdgl_res_head_app.DAL.Ssyxfmx_cz();
		public Ssyxfmx_cz()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(jdgl_res_head_app.Model.Ssyxfmx_cz model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(jdgl_res_head_app.Model.Ssyxfmx_cz model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public jdgl_res_head_app.Model.Ssyxfmx_cz GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public jdgl_res_head_app.Model.Ssyxfmx_cz GetModelByCache(int id)
		{
			
			string CacheKey = "Ssyxfmx_czModel-" + id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (jdgl_res_head_app.Model.Ssyxfmx_cz)objModel;
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
		public List<jdgl_res_head_app.Model.Ssyxfmx_cz> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<jdgl_res_head_app.Model.Ssyxfmx_cz> DataTableToList(DataTable dt)
		{
			List<jdgl_res_head_app.Model.Ssyxfmx_cz> modelList = new List<jdgl_res_head_app.Model.Ssyxfmx_cz>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				jdgl_res_head_app.Model.Ssyxfmx_cz model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new jdgl_res_head_app.Model.Ssyxfmx_cz();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["yydh"]!=null && dt.Rows[n]["yydh"].ToString()!="")
					{
					model.yydh=dt.Rows[n]["yydh"].ToString();
					}
					if(dt.Rows[n]["qymc"]!=null && dt.Rows[n]["qymc"].ToString()!="")
					{
					model.qymc=dt.Rows[n]["qymc"].ToString();
					}
					if(dt.Rows[n]["id_app"]!=null && dt.Rows[n]["id_app"].ToString()!="")
					{
					model.id_app=dt.Rows[n]["id_app"].ToString();
					}
					if(dt.Rows[n]["krly"]!=null && dt.Rows[n]["krly"].ToString()!="")
					{
					model.krly=dt.Rows[n]["krly"].ToString();
					}
					if(dt.Rows[n]["yxzj"]!=null && dt.Rows[n]["yxzj"].ToString()!="")
					{
					model.yxzj=dt.Rows[n]["yxzj"].ToString();
					}
					if(dt.Rows[n]["zjhm"]!=null && dt.Rows[n]["zjhm"].ToString()!="")
					{
					model.zjhm=dt.Rows[n]["zjhm"].ToString();
					}
					if(dt.Rows[n]["krsj"]!=null && dt.Rows[n]["krsj"].ToString()!="")
					{
					model.krsj=dt.Rows[n]["krsj"].ToString();
					}
					if(dt.Rows[n]["xyh"]!=null && dt.Rows[n]["xyh"].ToString()!="")
					{
					model.xyh=dt.Rows[n]["xyh"].ToString();
					}
					if(dt.Rows[n]["xydw"]!=null && dt.Rows[n]["xydw"].ToString()!="")
					{
					model.xydw=dt.Rows[n]["xydw"].ToString();
					}
					if(dt.Rows[n]["xsy"]!=null && dt.Rows[n]["xsy"].ToString()!="")
					{
					model.xsy=dt.Rows[n]["xsy"].ToString();
					}
					if(dt.Rows[n]["hykh"]!=null && dt.Rows[n]["hykh"].ToString()!="")
					{
					model.hykh=dt.Rows[n]["hykh"].ToString();
					}
					if(dt.Rows[n]["krgj"]!=null && dt.Rows[n]["krgj"].ToString()!="")
					{
					model.krgj=dt.Rows[n]["krgj"].ToString();
					}
					if(dt.Rows[n]["pq"]!=null && dt.Rows[n]["pq"].ToString()!="")
					{
					model.pq=dt.Rows[n]["pq"].ToString();
					}
					if(dt.Rows[n]["gj_sf"]!=null && dt.Rows[n]["gj_sf"].ToString()!="")
					{
					model.gj_sf=dt.Rows[n]["gj_sf"].ToString();
					}
					if(dt.Rows[n]["gj_cs"]!=null && dt.Rows[n]["gj_cs"].ToString()!="")
					{
					model.gj_cs=dt.Rows[n]["gj_cs"].ToString();
					}
					if(dt.Rows[n]["gj_dq"]!=null && dt.Rows[n]["gj_dq"].ToString()!="")
					{
					model.gj_dq=dt.Rows[n]["gj_dq"].ToString();
					}
					if(dt.Rows[n]["is_select"]!=null && dt.Rows[n]["is_select"].ToString()!="")
					{
						if((dt.Rows[n]["is_select"].ToString()=="1")||(dt.Rows[n]["is_select"].ToString().ToLower()=="true"))
						{
						model.is_select=true;
						}
						else
						{
							model.is_select=false;
						}
					}
					if(dt.Rows[n]["is_top"]!=null && dt.Rows[n]["is_top"].ToString()!="")
					{
						if((dt.Rows[n]["is_top"].ToString()=="1")||(dt.Rows[n]["is_top"].ToString().ToLower()=="true"))
						{
						model.is_top=true;
						}
						else
						{
							model.is_top=false;
						}
					}
					if(dt.Rows[n]["shsc"]!=null && dt.Rows[n]["shsc"].ToString()!="")
					{
						if((dt.Rows[n]["shsc"].ToString()=="1")||(dt.Rows[n]["shsc"].ToString().ToLower()=="true"))
						{
						model.shsc=true;
						}
						else
						{
							model.shsc=false;
						}
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

