using System;
using System.Configuration;
namespace Maticsoft.DBUtility
{
    
    public class PubConstant
    {

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["conStr"];       
                //string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                //if (ConStringEncrypt == "true")
                //{
                //    _connectionString = DESEncrypt.Decrypt(_connectionString);
                //}
                //string _connectionString = "Persist Security Info=False;server=.;database=Hotel_data;uid=sa;pwd=sa;";
                return _connectionString;

            }
        }

        /// <summary>
        /// 获取连接字符串,通过app.config配置文件来读取连接字符串
        /// </summary>
        public static string config_ConnectionString
        {           
            get 
            {
                string _connectionString = ConfigurationManager.AppSettings["aaa"];       
                string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (ConStringEncrypt == "true")
                {
                    _connectionString = DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString; 
            }
        }

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.AppSettings[configName];
            string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
            if (ConStringEncrypt == "true")
            {
                connectionString = DESEncrypt.Decrypt(connectionString);
            }
            return connectionString;
        }
    }
}
