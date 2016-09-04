using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;
namespace Hotel_app.BLL
{
	/// <summary>
	/// Qskyd_mainrecord
	/// </summary>
	public partial class Qskyd_mainrecord_new
	{
		private readonly Hotel_app.DAL.Qskyd_mainrecord_new dal=new Hotel_app.DAL.Qskyd_mainrecord_new();
		public Qskyd_mainrecord_new()
		{}
		#region  Method

		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Hotel_app.Model.Qskyd_mainrecord model)
		{
			return dal.Add(model);
		}

        /// <summary>
        /// 删除或结账时的成批备份
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cznr"></param>一定要从静态类common_app里去选！
        /// <param name="qxyy"></param>取消原因
        /// <param name="czy"></param>
        /// <param name="czsj"></param>
        /// <param name="czzt"></param>状态有三种，修改"xg",删除"sc",结账退房"jz"(包含结账、挂账、记账)
        /// <param name="jzbh"></param>
        /// <returns></returns>
        public int Pladd(int id, string cznr, string qxyy, string czy, string czsj, string czzt, string jzbh)
        {
            return dal.Pladd(id, cznr,qxyy, czy, czsj, czzt, jzbh);

        }
		
		#endregion  Method
	}
}

