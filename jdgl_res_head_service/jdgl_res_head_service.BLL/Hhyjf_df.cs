using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using jdgl_res_head_service.Model;
namespace jdgl_res_head_service.BLL
{
	/// <summary>
	/// Hhyjf_df
	/// </summary>
	public partial class Hhyjf_df
	{
		private readonly jdgl_res_head_service.DAL.Hhyjf_df dal=new jdgl_res_head_service.DAL.Hhyjf_df();
		public Hhyjf_df()
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
		public int  Add(jdgl_res_head_service.Model.Hhyjf_df model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(jdgl_res_head_service.Model.Hhyjf_df model)
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
		public jdgl_res_head_service.Model.Hhyjf_df GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public jdgl_res_head_service.Model.Hhyjf_df GetModelByCache(int id)
		{
			
			string CacheKey = "Hhyjf_dfModel-" + id;
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
			return (jdgl_res_head_service.Model.Hhyjf_df)objModel;
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
		public List<jdgl_res_head_service.Model.Hhyjf_df> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<jdgl_res_head_service.Model.Hhyjf_df> DataTableToList(DataTable dt)
		{
			List<jdgl_res_head_service.Model.Hhyjf_df> modelList = new List<jdgl_res_head_service.Model.Hhyjf_df>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				jdgl_res_head_service.Model.Hhyjf_df model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new jdgl_res_head_service.Model.Hhyjf_df();
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
					if(dt.Rows[n]["lsbh_df"]!=null && dt.Rows[n]["lsbh_df"].ToString()!="")
					{
					model.lsbh_df=dt.Rows[n]["lsbh_df"].ToString();
					}
					if(dt.Rows[n]["hykh"]!=null && dt.Rows[n]["hykh"].ToString()!="")
					{
					model.hykh=dt.Rows[n]["hykh"].ToString();
					}
					if(dt.Rows[n]["hykh_bz"]!=null && dt.Rows[n]["hykh_bz"].ToString()!="")
					{
					model.hykh_bz=dt.Rows[n]["hykh_bz"].ToString();
					}
					if(dt.Rows[n]["krxm"]!=null && dt.Rows[n]["krxm"].ToString()!="")
					{
					model.krxm=dt.Rows[n]["krxm"].ToString();
					}
					if(dt.Rows[n]["dfjf"]!=null && dt.Rows[n]["dfjf"].ToString()!="")
					{
						model.dfjf=decimal.Parse(dt.Rows[n]["dfjf"].ToString());
					}
					if(dt.Rows[n]["dfxm"]!=null && dt.Rows[n]["dfxm"].ToString()!="")
					{
					model.dfxm=dt.Rows[n]["dfxm"].ToString();
					}
					if(dt.Rows[n]["dfsl"]!=null && dt.Rows[n]["dfsl"].ToString()!="")
					{
						model.dfsl=decimal.Parse(dt.Rows[n]["dfsl"].ToString());
					}
					if(dt.Rows[n]["xfrq"]!=null && dt.Rows[n]["xfrq"].ToString()!="")
					{
						model.xfrq=DateTime.Parse(dt.Rows[n]["xfrq"].ToString());
					}
					if(dt.Rows[n]["xfsj"]!=null && dt.Rows[n]["xfsj"].ToString()!="")
					{
						model.xfsj=DateTime.Parse(dt.Rows[n]["xfsj"].ToString());
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
					if(dt.Rows[n]["scsj"]!=null && dt.Rows[n]["scsj"].ToString()!="")
					{
						model.scsj=DateTime.Parse(dt.Rows[n]["scsj"].ToString());
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
					if(dt.Rows[n]["shqx"]!=null && dt.Rows[n]["shqx"].ToString()!="")
					{
						if((dt.Rows[n]["shqx"].ToString()=="1")||(dt.Rows[n]["shqx"].ToString().ToLower()=="true"))
						{
						model.shqx=true;
						}
						else
						{
							model.shqx=false;
						}
					}
					if(dt.Rows[n]["parent_hykh"]!=null && dt.Rows[n]["parent_hykh"].ToString()!="")
					{
					model.parent_hykh=dt.Rows[n]["parent_hykh"].ToString();
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

