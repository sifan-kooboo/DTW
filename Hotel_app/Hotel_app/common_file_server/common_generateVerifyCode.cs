using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;

namespace Hotel_app.common_file_server
{
    public class common_generateVerifyCode
    {
        public static string CreateCode()
        {
            string code = "";//验证码
            int length = int.Parse(ConfigurationManager.AppSettings["VerifyCode_length"].ToString());
            if (length <= 0)
            {
                return string.Empty;
            }
            Random random = new Random();
            StringBuilder builder = new StringBuilder();
            //产生随机的验证码并拼接起来 
            for (int i = 0; i < length; i++)
            {
                builder.Append(random.Next(0, 10));
            }
            code = builder.ToString();
            return   code;
        } 



    }
}
