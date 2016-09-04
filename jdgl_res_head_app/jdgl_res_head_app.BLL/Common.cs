using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using jdgl_res_head_app.Model;

namespace jdgl_res_head_app.BLL
{
    public class Common
    {
        public Common()
        { }
        private readonly jdgl_res_head_app.DAL.Common dal = new jdgl_res_head_app.DAL.Common();

        /// 获得数据列表
        public DataSet GetList(string strSelect, string strWhere)
        {
            return dal.GetList(strSelect, strWhere);

        }
        /// 执行数据语句
        public int ExecuteSql(string SQLString)
        {
            return dal.ExecuteSql(SQLString);

        }


    }
}

