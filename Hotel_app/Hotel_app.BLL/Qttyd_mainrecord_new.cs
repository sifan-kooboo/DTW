using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;

namespace Hotel_app.BLL
{
    public partial class Qttyd_mainrecord_new
    {
        private readonly Hotel_app.DAL.Qttyd_mainrecord_new dal = new Hotel_app.DAL.Qttyd_mainrecord_new();
        public Qttyd_mainrecord_new()
		{}

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
            return dal.Pladd(id, cznr, qxyy, czy, czsj, czzt, jzbh);

        }

    }
}
