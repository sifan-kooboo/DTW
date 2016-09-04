using System;
using System.Collections.Generic;
using System.Text;

namespace jdgl_res_head_app.Com
{
    class ConfigInfo
    {
        public static string url = common_file.Common.ReadXML("add", "url");
        public static string yydh = Common.Getqyxx(1);
        public static string qymc = Common.Getqyxx(2);
        public static string ddly_Site = "网站预订";
    }
}
