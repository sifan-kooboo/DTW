using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_app.common_file
{
    class common_generateVerifyCode
    {
        public static  string CreateCode()
        {
            string code = "";//验证码

            int length = common_app.VerifyCode_length;
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
            return code;
        } 

    }
}
