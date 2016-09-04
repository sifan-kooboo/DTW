using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// S_jbzd
	/// </summary>
	public partial class S_jbzd
	{
		private readonly Hotel_app.DAL.S_jbzd dal=new Hotel_app.DAL.S_jbzd();
		public S_jbzd()
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
		public int  Add(Hotel_app.Model.S_jbzd model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.S_jbzd model)
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
		public Hotel_app.Model.S_jbzd GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.S_jbzd GetModelByCache(int id)
		{
			
			string CacheKey = "S_jbzdModel-" + id;
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
			return (Hotel_app.Model.S_jbzd)objModel;
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
		public List<Hotel_app.Model.S_jbzd> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.S_jbzd> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.S_jbzd> modelList = new List<Hotel_app.Model.S_jbzd>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.S_jbzd model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.S_jbzd();
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
					if(dt.Rows[n]["czy_jb"]!=null && dt.Rows[n]["czy_jb"].ToString()!="")
					{
					model.czy_jb=dt.Rows[n]["czy_jb"].ToString();
					}
					if(dt.Rows[n]["czy_sb"]!=null && dt.Rows[n]["czy_sb"].ToString()!="")
					{
					model.czy_sb=dt.Rows[n]["czy_sb"].ToString();
					}
					if(dt.Rows[n]["j_s_bc"]!=null && dt.Rows[n]["j_s_bc"].ToString()!="")
					{
					model.j_s_bc=dt.Rows[n]["j_s_bc"].ToString();
					}
					if(dt.Rows[n]["cssj"]!=null && dt.Rows[n]["cssj"].ToString()!="")
					{
						model.cssj=DateTime.Parse(dt.Rows[n]["cssj"].ToString());
					}
					if(dt.Rows[n]["czsj"]!=null && dt.Rows[n]["czsj"].ToString()!="")
					{
						model.czsj=DateTime.Parse(dt.Rows[n]["czsj"].ToString());
					}
					if(dt.Rows[n]["czy"]!=null && dt.Rows[n]["czy"].ToString()!="")
					{
					model.czy=dt.Rows[n]["czy"].ToString();
					}
					if(dt.Rows[n]["bz"]!=null && dt.Rows[n]["bz"].ToString()!="")
					{
					model.bz=dt.Rows[n]["bz"].ToString();
					}
					if(dt.Rows[n]["ysk"]!=null && dt.Rows[n]["ysk"].ToString()!="")
					{
						model.ysk=decimal.Parse(dt.Rows[n]["ysk"].ToString());
					}
					if(dt.Rows[n]["t_ysk"]!=null && dt.Rows[n]["t_ysk"].ToString()!="")
					{
						model.t_ysk=decimal.Parse(dt.Rows[n]["t_ysk"].ToString());
					}
					if(dt.Rows[n]["qtfk"]!=null && dt.Rows[n]["qtfk"].ToString()!="")
					{
						model.qtfk=decimal.Parse(dt.Rows[n]["qtfk"].ToString());
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
					if(dt.Rows[n]["jb_jk_rx"]!=null && dt.Rows[n]["jb_jk_rx"].ToString()!="")
					{
					model.jb_jk_rx=dt.Rows[n]["jb_jk_rx"].ToString();
					}
					if(dt.Rows[n]["t_ysk_qt"]!=null && dt.Rows[n]["t_ysk_qt"].ToString()!="")
					{
						model.t_ysk_qt=decimal.Parse(dt.Rows[n]["t_ysk_qt"].ToString());
					}
					if(dt.Rows[n]["ysk_fs"]!=null && dt.Rows[n]["ysk_fs"].ToString()!="")
					{
						model.ysk_fs=decimal.Parse(dt.Rows[n]["ysk_fs"].ToString());
					}
					if(dt.Rows[n]["jb_jk"]!=null && dt.Rows[n]["jb_jk"].ToString()!="")
					{
					model.jb_jk=dt.Rows[n]["jb_jk"].ToString();
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

