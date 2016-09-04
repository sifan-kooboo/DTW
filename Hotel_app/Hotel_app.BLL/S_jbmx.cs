using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// S_jbmx
	/// </summary>
	public partial class S_jbmx
	{
		private readonly Hotel_app.DAL.S_jbmx dal=new Hotel_app.DAL.S_jbmx();
		public S_jbmx()
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
		public int  Add(Hotel_app.Model.S_jbmx model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.S_jbmx model)
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
		public Hotel_app.Model.S_jbmx GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.S_jbmx GetModelByCache(int id)
		{
			
			string CacheKey = "S_jbmxModel-" + id;
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
			return (Hotel_app.Model.S_jbmx)objModel;
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
		public List<Hotel_app.Model.S_jbmx> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.S_jbmx> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.S_jbmx> modelList = new List<Hotel_app.Model.S_jbmx>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.S_jbmx model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.S_jbmx();
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
					if(dt.Rows[n]["lsbh"]!=null && dt.Rows[n]["lsbh"].ToString()!="")
					{
					model.lsbh=dt.Rows[n]["lsbh"].ToString();
					}
					if(dt.Rows[n]["syzd"]!=null && dt.Rows[n]["syzd"].ToString()!="")
					{
					model.syzd=dt.Rows[n]["syzd"].ToString();
					}
					if(dt.Rows[n]["syy"]!=null && dt.Rows[n]["syy"].ToString()!="")
					{
					model.syy=dt.Rows[n]["syy"].ToString();
					}
					if(dt.Rows[n]["syy_rb_visible"]!=null && dt.Rows[n]["syy_rb_visible"].ToString()!="")
					{
					model.syy_rb_visible=dt.Rows[n]["syy_rb_visible"].ToString();
					}
					if(dt.Rows[n]["fkfs"]!=null && dt.Rows[n]["fkfs"].ToString()!="")
					{
					model.fkfs=dt.Rows[n]["fkfs"].ToString();
					}
					if(dt.Rows[n]["qtfk"]!=null && dt.Rows[n]["qtfk"].ToString()!="")
					{
						model.qtfk=decimal.Parse(dt.Rows[n]["qtfk"].ToString());
					}
					if(dt.Rows[n]["ysk"]!=null && dt.Rows[n]["ysk"].ToString()!="")
					{
						model.ysk=decimal.Parse(dt.Rows[n]["ysk"].ToString());
					}
					if(dt.Rows[n]["t_ysk"]!=null && dt.Rows[n]["t_ysk"].ToString()!="")
					{
						model.t_ysk=decimal.Parse(dt.Rows[n]["t_ysk"].ToString());
					}
					if(dt.Rows[n]["qtsk_t_ysk"]!=null && dt.Rows[n]["qtsk_t_ysk"].ToString()!="")
					{
						model.qtsk_t_ysk=decimal.Parse(dt.Rows[n]["qtsk_t_ysk"].ToString());
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
					if(dt.Rows[n]["t_ysk_qt"]!=null && dt.Rows[n]["t_ysk_qt"].ToString()!="")
					{
						model.t_ysk_qt=decimal.Parse(dt.Rows[n]["t_ysk_qt"].ToString());
					}
					if(dt.Rows[n]["ysk_fs"]!=null && dt.Rows[n]["ysk_fs"].ToString()!="")
					{
						model.ysk_fs=decimal.Parse(dt.Rows[n]["ysk_fs"].ToString());
					}
					if(dt.Rows[n]["qt_yyk"]!=null && dt.Rows[n]["qt_yyk"].ToString()!="")
					{
						model.qt_yyk=decimal.Parse(dt.Rows[n]["qt_yyk"].ToString());
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

