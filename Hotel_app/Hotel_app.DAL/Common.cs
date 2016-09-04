using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Hotel_app.DAL
{
   public class Common
    {
       public Common()
		{}
        /// 获得数据列表
        public DataSet GetList(string strSelect,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            if (strSelect.Trim() != "")
            {
                strSql.Append(strSelect);
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// 执行数据语句
        public int ExecuteSql(string SQLString)
        {
            int i = 0;
            StringBuilder strSql = new StringBuilder();
            if (SQLString.Trim() != "")
            {
               i= DbHelperSQL.ExecuteSql(SQLString);
            }
            return i;
        }


    }
}
