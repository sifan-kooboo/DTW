using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_app.common_file_server
{
    public static class common_jzzt
    {

        public static string czzt_gz_xg = "挂账";
        public static string czzt_jz_xg = "记账";

        public static string czzt_sz = "结账退房";
        public static string czzt_jz = "记账退房";
        public static string czzt_gz = "挂账退房";
        public static string czzt_bfsz = "部分结账";
        public static string czzt_jzzsz = "记账转结账";
        public static string czzt_jzfj = "记账分结";
        public static string czzt_gzzsz = "挂账转结账";
        public static string czzt_gzfj = "挂账分结";
        public static string czzt_jzzzz = "记账转在住";
        public static string czzt_gzzzz = "挂账转在住";
        public static string czzt_gzzjz = "挂账转记账";
        public static string czzt_jzzgz = "记账转挂账";
        public static string czzt_like_sz = " and (czzt <> '结账退房' and czzt <>'部分结账')";
        public static string czzt_bak_not_like_tf = " and (czzt not like  '%退房%' )";
    }
}
