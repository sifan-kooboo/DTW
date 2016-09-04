using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Hotel_app.Model;

namespace Hotel_app.BLL
{
    public class Common
    {
        public Common()
        { }
        private readonly Hotel_app.DAL.Common dal = new Hotel_app.DAL.Common();

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

