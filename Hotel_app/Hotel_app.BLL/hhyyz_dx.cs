using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// hhyyz_dx
	/// </summary>
	public partial class hhyyz_dx
	{
		private readonly Hotel_app.DAL.hhyyz_dx dal=new Hotel_app.DAL.hhyyz_dx();
		public hhyyz_dx()
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
		public int  Add(Hotel_app.Model.hhyyz_dx model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.hhyyz_dx model)
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
		public Hotel_app.Model.hhyyz_dx GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.hhyyz_dx GetModelByCache(int id)
		{
			
			string CacheKey = "hhyyz_dxModel-" + id;
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
			return (Hotel_app.Model.hhyyz_dx)objModel;
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
		public List<Hotel_app.Model.hhyyz_dx> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.hhyyz_dx> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.hhyyz_dx> modelList = new List<Hotel_app.Model.hhyyz_dx>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.hhyyz_dx model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.hhyyz_dx();
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
					if(dt.Rows[n]["hy_action_flage"]!=null && dt.Rows[n]["hy_action_flage"].ToString()!="")
					{
					model.hy_action_flage=dt.Rows[n]["hy_action_flage"].ToString();
					}
					if(dt.Rows[n]["msm_content"]!=null && dt.Rows[n]["msm_content"].ToString()!="")
					{
					model.msm_content=dt.Rows[n]["msm_content"].ToString();
					}
					if(dt.Rows[n]["enable"]!=null && dt.Rows[n]["enable"].ToString()!="")
					{
						if((dt.Rows[n]["enable"].ToString()=="1")||(dt.Rows[n]["enable"].ToString().ToLower()=="true"))
						{
						model.enable=true;
						}
						else
						{
							model.enable=false;
						}
					}
					if(dt.Rows[n]["dxycsj"]!=null && dt.Rows[n]["dxycsj"].ToString()!="")
					{
						model.dxycsj=int.Parse(dt.Rows[n]["dxycsj"].ToString());
					}
					if(dt.Rows[n]["msm_content_2"]!=null && dt.Rows[n]["msm_content_2"].ToString()!="")
					{
					model.msm_content_2=dt.Rows[n]["msm_content_2"].ToString();
					}
					if(dt.Rows[n]["msm_content_3"]!=null && dt.Rows[n]["msm_content_3"].ToString()!="")
					{
					model.msm_content_3=dt.Rows[n]["msm_content_3"].ToString();
					}
					if(dt.Rows[n]["msm_content_4"]!=null && dt.Rows[n]["msm_content_4"].ToString()!="")
					{
					model.msm_content_4=dt.Rows[n]["msm_content_4"].ToString();
					}
					if(dt.Rows[n]["msm_content_5"]!=null && dt.Rows[n]["msm_content_5"].ToString()!="")
					{
					model.msm_content_5=dt.Rows[n]["msm_content_5"].ToString();
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

