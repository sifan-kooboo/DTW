using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// Xxfmx
	/// </summary>
	public partial class Xxfmx
	{
		private readonly Hotel_app.DAL.Xxfmx dal=new Hotel_app.DAL.Xxfmx();
		public Xxfmx()
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
		public int  Add(Hotel_app.Model.Xxfmx model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.Xxfmx model)
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
		public Hotel_app.Model.Xxfmx GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.Xxfmx GetModelByCache(int id)
		{
			
			string CacheKey = "XxfmxModel-" + id;
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
			return (Hotel_app.Model.Xxfmx)objModel;
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
		public List<Hotel_app.Model.Xxfmx> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.Xxfmx> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.Xxfmx> modelList = new List<Hotel_app.Model.Xxfmx>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.Xxfmx model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.Xxfmx();
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
					if(dt.Rows[n]["drbh"]!=null && dt.Rows[n]["drbh"].ToString()!="")
					{
					model.drbh=dt.Rows[n]["drbh"].ToString();
					}
					if(dt.Rows[n]["xfdr"]!=null && dt.Rows[n]["xfdr"].ToString()!="")
					{
					model.xfdr=dt.Rows[n]["xfdr"].ToString();
					}
					if(dt.Rows[n]["xrbh"]!=null && dt.Rows[n]["xrbh"].ToString()!="")
					{
					model.xrbh=dt.Rows[n]["xrbh"].ToString();
					}
					if(dt.Rows[n]["xfxr"]!=null && dt.Rows[n]["xfxr"].ToString()!="")
					{
					model.xfxr=dt.Rows[n]["xfxr"].ToString();
					}
					if(dt.Rows[n]["mxbh"]!=null && dt.Rows[n]["mxbh"].ToString()!="")
					{
					model.mxbh=dt.Rows[n]["mxbh"].ToString();
					}
					if(dt.Rows[n]["xfmx"]!=null && dt.Rows[n]["xfmx"].ToString()!="")
					{
					model.xfmx=dt.Rows[n]["xfmx"].ToString();
					}
					if(dt.Rows[n]["zjm"]!=null && dt.Rows[n]["zjm"].ToString()!="")
					{
					model.zjm=dt.Rows[n]["zjm"].ToString();
					}
					if(dt.Rows[n]["xfgg"]!=null && dt.Rows[n]["xfgg"].ToString()!="")
					{
					model.xfgg=dt.Rows[n]["xfgg"].ToString();
					}
					if(dt.Rows[n]["jjje"]!=null && dt.Rows[n]["jjje"].ToString()!="")
					{
						model.jjje=decimal.Parse(dt.Rows[n]["jjje"].ToString());
					}
					if(dt.Rows[n]["xfje"]!=null && dt.Rows[n]["xfje"].ToString()!="")
					{
						model.xfje=decimal.Parse(dt.Rows[n]["xfje"].ToString());
					}
					if(dt.Rows[n]["xftm"]!=null && dt.Rows[n]["xftm"].ToString()!="")
					{
					model.xftm=dt.Rows[n]["xftm"].ToString();
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
					if(dt.Rows[n]["xf_cd"]!=null && dt.Rows[n]["xf_cd"].ToString()!="")
					{
					model.xf_cd=dt.Rows[n]["xf_cd"].ToString();
					}
					if(dt.Rows[n]["xf_dw"]!=null && dt.Rows[n]["xf_dw"].ToString()!="")
					{
					model.xf_dw=dt.Rows[n]["xf_dw"].ToString();
					}
					if(dt.Rows[n]["jldw"]!=null && dt.Rows[n]["jldw"].ToString()!="")
					{
					model.jldw=dt.Rows[n]["jldw"].ToString();
					}
					if(dt.Rows[n]["is_tj_kc"]!=null && dt.Rows[n]["is_tj_kc"].ToString()!="")
					{
						if((dt.Rows[n]["is_tj_kc"].ToString()=="1")||(dt.Rows[n]["is_tj_kc"].ToString().ToLower()=="true"))
						{
						model.is_tj_kc=true;
						}
						else
						{
							model.is_tj_kc=false;
						}
					}
					if(dt.Rows[n]["kcsl"]!=null && dt.Rows[n]["kcsl"].ToString()!="")
					{
						model.kcsl=decimal.Parse(dt.Rows[n]["kcsl"].ToString());
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

