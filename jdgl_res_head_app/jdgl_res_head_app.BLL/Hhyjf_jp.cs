using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using jdgl_res_head_app.Model;
namespace jdgl_res_head_app.BLL
{
	/// <summary>
	/// Hhyjf_jp
	/// </summary>
	public partial class Hhyjf_jp
	{
		private readonly jdgl_res_head_app.DAL.Hhyjf_jp dal=new jdgl_res_head_app.DAL.Hhyjf_jp();
		public Hhyjf_jp()
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
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(jdgl_res_head_app.Model.Hhyjf_jp model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(jdgl_res_head_app.Model.Hhyjf_jp model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public jdgl_res_head_app.Model.Hhyjf_jp GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public jdgl_res_head_app.Model.Hhyjf_jp GetModelByCache(int ID)
		{
			
			string CacheKey = "Hhyjf_jpModel-" + ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (jdgl_res_head_app.Model.Hhyjf_jp)objModel;
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
		public List<jdgl_res_head_app.Model.Hhyjf_jp> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<jdgl_res_head_app.Model.Hhyjf_jp> DataTableToList(DataTable dt)
		{
			List<jdgl_res_head_app.Model.Hhyjf_jp> modelList = new List<jdgl_res_head_app.Model.Hhyjf_jp>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				jdgl_res_head_app.Model.Hhyjf_jp model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new jdgl_res_head_app.Model.Hhyjf_jp();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["yydh"]!=null && dt.Rows[n]["yydh"].ToString()!="")
					{
					model.yydh=dt.Rows[n]["yydh"].ToString();
					}
					if(dt.Rows[n]["qymc"]!=null && dt.Rows[n]["qymc"].ToString()!="")
					{
					model.qymc=dt.Rows[n]["qymc"].ToString();
					}
					if(dt.Rows[n]["classname"]!=null && dt.Rows[n]["classname"].ToString()!="")
					{
					model.classname=dt.Rows[n]["classname"].ToString();
					}
					if(dt.Rows[n]["Title"]!=null && dt.Rows[n]["Title"].ToString()!="")
					{
					model.Title=dt.Rows[n]["Title"].ToString();
					}
					if(dt.Rows[n]["jpjf"]!=null && dt.Rows[n]["jpjf"].ToString()!="")
					{
						model.jpjf=decimal.Parse(dt.Rows[n]["jpjf"].ToString());
					}
					if(dt.Rows[n]["simg"]!=null && dt.Rows[n]["simg"].ToString()!="")
					{
					model.simg=dt.Rows[n]["simg"].ToString();
					}
					if(dt.Rows[n]["bimg"]!=null && dt.Rows[n]["bimg"].ToString()!="")
					{
					model.bimg=dt.Rows[n]["bimg"].ToString();
					}
					if(dt.Rows[n]["info"]!=null && dt.Rows[n]["info"].ToString()!="")
					{
					model.info=dt.Rows[n]["info"].ToString();
					}
					if(dt.Rows[n]["bz"]!=null && dt.Rows[n]["bz"].ToString()!="")
					{
					model.bz=dt.Rows[n]["bz"].ToString();
					}
					if(dt.Rows[n]["isTuiJian"]!=null && dt.Rows[n]["isTuiJian"].ToString()!="")
					{
						if((dt.Rows[n]["isTuiJian"].ToString()=="1")||(dt.Rows[n]["isTuiJian"].ToString().ToLower()=="true"))
						{
						model.isTuiJian=true;
						}
						else
						{
							model.isTuiJian=false;
						}
					}
					if(dt.Rows[n]["isshow"]!=null && dt.Rows[n]["isshow"].ToString()!="")
					{
						if((dt.Rows[n]["isshow"].ToString()=="1")||(dt.Rows[n]["isshow"].ToString().ToLower()=="true"))
						{
						model.isshow=true;
						}
						else
						{
							model.isshow=false;
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
					if(dt.Rows[n]["hyjfrx"]!=null && dt.Rows[n]["hyjfrx"].ToString()!="")
					{
					model.hyjfrx=dt.Rows[n]["hyjfrx"].ToString();
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

