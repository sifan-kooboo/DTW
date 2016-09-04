using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// BB_ysk_cy
	/// </summary>
	public partial class BB_ysk_cy
	{
		private readonly Hotel_app.DAL.BB_ysk_cy dal=new Hotel_app.DAL.BB_ysk_cy();
		public BB_ysk_cy()
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
		public int  Add(Hotel_app.Model.BB_ysk_cy model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.BB_ysk_cy model)
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
		public Hotel_app.Model.BB_ysk_cy GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.BB_ysk_cy GetModelByCache(int id)
		{
			
			string CacheKey = "BB_ysk_cyModel-" + id;
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
			return (Hotel_app.Model.BB_ysk_cy)objModel;
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
		public List<Hotel_app.Model.BB_ysk_cy> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.BB_ysk_cy> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.BB_ysk_cy> modelList = new List<Hotel_app.Model.BB_ysk_cy>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.BB_ysk_cy model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.BB_ysk_cy();
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
					if(dt.Rows[n]["czy"]!=null && dt.Rows[n]["czy"].ToString()!="")
					{
					model.czy=dt.Rows[n]["czy"].ToString();
					}
					if(dt.Rows[n]["krxm"]!=null && dt.Rows[n]["krxm"].ToString()!="")
					{
					model.krxm=dt.Rows[n]["krxm"].ToString();
					}
					if(dt.Rows[n]["lsbh"]!=null && dt.Rows[n]["lsbh"].ToString()!="")
					{
					model.lsbh=dt.Rows[n]["lsbh"].ToString();
					}
					if(dt.Rows[n]["fjbh"]!=null && dt.Rows[n]["fjbh"].ToString()!="")
					{
					model.fjbh=dt.Rows[n]["fjbh"].ToString();
					}
					if(dt.Rows[n]["sjfjjg"]!=null && dt.Rows[n]["sjfjjg"].ToString()!="")
					{
						model.sjfjjg=decimal.Parse(dt.Rows[n]["sjfjjg"].ToString());
					}
					if(dt.Rows[n]["shqh"]!=null && dt.Rows[n]["shqh"].ToString()!="")
					{
					model.shqh=dt.Rows[n]["shqh"].ToString();
					}
					if(dt.Rows[n]["xydw"]!=null && dt.Rows[n]["xydw"].ToString()!="")
					{
					model.xydw=dt.Rows[n]["xydw"].ToString();
					}
					if(dt.Rows[n]["krly"]!=null && dt.Rows[n]["krly"].ToString()!="")
					{
					model.krly=dt.Rows[n]["krly"].ToString();
					}
					if(dt.Rows[n]["sktt"]!=null && dt.Rows[n]["sktt"].ToString()!="")
					{
					model.sktt=dt.Rows[n]["sktt"].ToString();
					}
					if(dt.Rows[n]["shtt"]!=null && dt.Rows[n]["shtt"].ToString()!="")
					{
						if((dt.Rows[n]["shtt"].ToString()=="1")||(dt.Rows[n]["shtt"].ToString().ToLower()=="true"))
						{
						model.shtt=true;
						}
						else
						{
							model.shtt=false;
						}
					}
					if(dt.Rows[n]["ddsj"]!=null && dt.Rows[n]["ddsj"].ToString()!="")
					{
						model.ddsj=DateTime.Parse(dt.Rows[n]["ddsj"].ToString());
					}
					if(dt.Rows[n]["lksj"]!=null && dt.Rows[n]["lksj"].ToString()!="")
					{
						model.lksj=DateTime.Parse(dt.Rows[n]["lksj"].ToString());
					}
					if(dt.Rows[n]["lz"]!=null && dt.Rows[n]["lz"].ToString()!="")
					{
					model.lz=dt.Rows[n]["lz"].ToString();
					}
					if(dt.Rows[n]["lzbh"]!=null && dt.Rows[n]["lzbh"].ToString()!="")
					{
					model.lzbh=dt.Rows[n]["lzbh"].ToString();
					}
					if(dt.Rows[n]["fjdh"]!=null && dt.Rows[n]["fjdh"].ToString()!="")
					{
					model.fjdh=dt.Rows[n]["fjdh"].ToString();
					}
					if(dt.Rows[n]["dhfj"]!=null && dt.Rows[n]["dhfj"].ToString()!="")
					{
					model.dhfj=dt.Rows[n]["dhfj"].ToString();
					}
					if(dt.Rows[n]["fkje"]!=null && dt.Rows[n]["fkje"].ToString()!="")
					{
						model.fkje=decimal.Parse(dt.Rows[n]["fkje"].ToString());
					}
					if(dt.Rows[n]["xfje"]!=null && dt.Rows[n]["xfje"].ToString()!="")
					{
						model.xfje=decimal.Parse(dt.Rows[n]["xfje"].ToString());
					}
					if(dt.Rows[n]["yj_xfje"]!=null && dt.Rows[n]["yj_xfje"].ToString()!="")
					{
						model.yj_xfje=decimal.Parse(dt.Rows[n]["yj_xfje"].ToString());
					}
					if(dt.Rows[n]["ye"]!=null && dt.Rows[n]["ye"].ToString()!="")
					{
						model.ye=decimal.Parse(dt.Rows[n]["ye"].ToString());
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

