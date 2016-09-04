using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// YH_lo_ex_trace
	/// </summary>
	public partial class YH_lo_ex_trace
	{
		private readonly Hotel_app.DAL.YH_lo_ex_trace dal=new Hotel_app.DAL.YH_lo_ex_trace();
		public YH_lo_ex_trace()
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
		public int  Add(Hotel_app.Model.YH_lo_ex_trace model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.YH_lo_ex_trace model)
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
		public Hotel_app.Model.YH_lo_ex_trace GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.YH_lo_ex_trace GetModelByCache(int id)
		{
			
			string CacheKey = "YH_lo_ex_traceModel-" + id;
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
			return (Hotel_app.Model.YH_lo_ex_trace)objModel;
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
		public List<Hotel_app.Model.YH_lo_ex_trace> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.YH_lo_ex_trace> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.YH_lo_ex_trace> modelList = new List<Hotel_app.Model.YH_lo_ex_trace>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.YH_lo_ex_trace model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.YH_lo_ex_trace();
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
					if(dt.Rows[n]["syzd"]!=null && dt.Rows[n]["syzd"].ToString()!="")
					{
					model.syzd=dt.Rows[n]["syzd"].ToString();
					}
					if(dt.Rows[n]["yhbh"]!=null && dt.Rows[n]["yhbh"].ToString()!="")
					{
					model.yhbh=dt.Rows[n]["yhbh"].ToString();
					}
					if(dt.Rows[n]["yhxm"]!=null && dt.Rows[n]["yhxm"].ToString()!="")
					{
					model.yhxm=dt.Rows[n]["yhxm"].ToString();
					}
					if(dt.Rows[n]["lo_ex"]!=null && dt.Rows[n]["lo_ex"].ToString()!="")
					{
					model.lo_ex=dt.Rows[n]["lo_ex"].ToString();
					}
					if(dt.Rows[n]["login_time"]!=null && dt.Rows[n]["login_time"].ToString()!="")
					{
						model.login_time=DateTime.Parse(dt.Rows[n]["login_time"].ToString());
					}
					if(dt.Rows[n]["exit_time"]!=null && dt.Rows[n]["exit_time"].ToString()!="")
					{
						model.exit_time=DateTime.Parse(dt.Rows[n]["exit_time"].ToString());
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

