using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// Qttyd_mainrecord
	/// </summary>
	public partial class Qttyd_mainrecord
	{
		private readonly Hotel_app.DAL.Qttyd_mainrecord dal=new Hotel_app.DAL.Qttyd_mainrecord();
		public Qttyd_mainrecord()
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
		public int  Add(Hotel_app.Model.Qttyd_mainrecord model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Hotel_app.Model.Qttyd_mainrecord model)
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
		public Hotel_app.Model.Qttyd_mainrecord GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Hotel_app.Model.Qttyd_mainrecord GetModelByCache(int id)
		{
			
			string CacheKey = "Qttyd_mainrecordModel-" + id;
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
			return (Hotel_app.Model.Qttyd_mainrecord)objModel;
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
		public List<Hotel_app.Model.Qttyd_mainrecord> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Hotel_app.Model.Qttyd_mainrecord> DataTableToList(DataTable dt)
		{
			List<Hotel_app.Model.Qttyd_mainrecord> modelList = new List<Hotel_app.Model.Qttyd_mainrecord>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Hotel_app.Model.Qttyd_mainrecord model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Hotel_app.Model.Qttyd_mainrecord();
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
					if(dt.Rows[n]["ddbh"]!=null && dt.Rows[n]["ddbh"].ToString()!="")
					{
					model.ddbh=dt.Rows[n]["ddbh"].ToString();
					}
					if(dt.Rows[n]["krxm"]!=null && dt.Rows[n]["krxm"].ToString()!="")
					{
					model.krxm=dt.Rows[n]["krxm"].ToString();
					}
					if(dt.Rows[n]["krbh"]!=null && dt.Rows[n]["krbh"].ToString()!="")
					{
					model.krbh=dt.Rows[n]["krbh"].ToString();
					}
					if(dt.Rows[n]["yddj"]!=null && dt.Rows[n]["yddj"].ToString()!="")
					{
					model.yddj=dt.Rows[n]["yddj"].ToString();
					}
					if(dt.Rows[n]["sktt"]!=null && dt.Rows[n]["sktt"].ToString()!="")
					{
					model.sktt=dt.Rows[n]["sktt"].ToString();
					}
					if(dt.Rows[n]["krgj"]!=null && dt.Rows[n]["krgj"].ToString()!="")
					{
					model.krgj=dt.Rows[n]["krgj"].ToString();
					}
					if(dt.Rows[n]["krdz"]!=null && dt.Rows[n]["krdz"].ToString()!="")
					{
					model.krdz=dt.Rows[n]["krdz"].ToString();
					}
					if(dt.Rows[n]["krly"]!=null && dt.Rows[n]["krly"].ToString()!="")
					{
					model.krly=dt.Rows[n]["krly"].ToString();
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
					if(dt.Rows[n]["krdh"]!=null && dt.Rows[n]["krdh"].ToString()!="")
					{
					model.krdh=dt.Rows[n]["krdh"].ToString();
					}
					if(dt.Rows[n]["krsj"]!=null && dt.Rows[n]["krsj"].ToString()!="")
					{
					model.krsj=dt.Rows[n]["krsj"].ToString();
					}
					if(dt.Rows[n]["krEmail"]!=null && dt.Rows[n]["krEmail"].ToString()!="")
					{
					model.krEmail=dt.Rows[n]["krEmail"].ToString();
					}
					if(dt.Rows[n]["ydrxm"]!=null && dt.Rows[n]["ydrxm"].ToString()!="")
					{
					model.ydrxm=dt.Rows[n]["ydrxm"].ToString();
					}
					if(dt.Rows[n]["ddsj"]!=null && dt.Rows[n]["ddsj"].ToString()!="")
					{
						model.ddsj=DateTime.Parse(dt.Rows[n]["ddsj"].ToString());
					}
					if(dt.Rows[n]["ddyy"]!=null && dt.Rows[n]["ddyy"].ToString()!="")
					{
					model.ddyy=dt.Rows[n]["ddyy"].ToString();
					}
					if(dt.Rows[n]["lzts"]!=null && dt.Rows[n]["lzts"].ToString()!="")
					{
						model.lzts=int.Parse(dt.Rows[n]["lzts"].ToString());
					}
					if(dt.Rows[n]["lksj"]!=null && dt.Rows[n]["lksj"].ToString()!="")
					{
						model.lksj=DateTime.Parse(dt.Rows[n]["lksj"].ToString());
					}
					if(dt.Rows[n]["qtyq"]!=null && dt.Rows[n]["qtyq"].ToString()!="")
					{
					model.qtyq=dt.Rows[n]["qtyq"].ToString();
					}
					if(dt.Rows[n]["ddrx"]!=null && dt.Rows[n]["ddrx"].ToString()!="")
					{
					model.ddrx=dt.Rows[n]["ddrx"].ToString();
					}
					if(dt.Rows[n]["ddwz"]!=null && dt.Rows[n]["ddwz"].ToString()!="")
					{
					model.ddwz=dt.Rows[n]["ddwz"].ToString();
					}
					if(dt.Rows[n]["zyzt"]!=null && dt.Rows[n]["zyzt"].ToString()!="")
					{
					model.zyzt=dt.Rows[n]["zyzt"].ToString();
					}
					if(dt.Rows[n]["czy"]!=null && dt.Rows[n]["czy"].ToString()!="")
					{
					model.czy=dt.Rows[n]["czy"].ToString();
					}
					if(dt.Rows[n]["cznr"]!=null && dt.Rows[n]["cznr"].ToString()!="")
					{
					model.cznr=dt.Rows[n]["cznr"].ToString();
					}
					if(dt.Rows[n]["czsj"]!=null && dt.Rows[n]["czsj"].ToString()!="")
					{
						model.czsj=DateTime.Parse(dt.Rows[n]["czsj"].ToString());
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
					if(dt.Rows[n]["ffshys"]!=null && dt.Rows[n]["ffshys"].ToString()!="")
					{
						if((dt.Rows[n]["ffshys"].ToString()=="1")||(dt.Rows[n]["ffshys"].ToString().ToLower()=="true"))
						{
						model.ffshys=true;
						}
						else
						{
							model.ffshys=false;
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
					if(dt.Rows[n]["sdcz"]!=null && dt.Rows[n]["sdcz"].ToString()!="")
					{
						if((dt.Rows[n]["sdcz"].ToString()=="1")||(dt.Rows[n]["sdcz"].ToString().ToLower()=="true"))
						{
						model.sdcz=true;
						}
						else
						{
							model.sdcz=false;
						}
					}
					if(dt.Rows[n]["syzd"]!=null && dt.Rows[n]["syzd"].ToString()!="")
					{
					model.syzd=dt.Rows[n]["syzd"].ToString();
					}
					if(dt.Rows[n]["tsyq"]!=null && dt.Rows[n]["tsyq"].ToString()!="")
					{
					model.tsyq=dt.Rows[n]["tsyq"].ToString();
					}
					if(dt.Rows[n]["ddly"]!=null && dt.Rows[n]["ddly"].ToString()!="")
					{
					model.ddly=dt.Rows[n]["ddly"].ToString();
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

