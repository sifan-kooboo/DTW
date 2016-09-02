<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.cart" ValidateRequest="false" %>

<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="DTcms.Common" %>

<script runat="server">
    override protected void OnInit(EventArgs e)
    {

        /* 
            This page was created by DTcms Template Engine at 2015/9/16 14:02:33.
            本页面代码由DTcms模板引擎生成于 2015/9/16 14:02:33. 
        */

        base.OnInit(e);
        StringBuilder templateBuilder = new StringBuilder(220000);
        templateBuilder.Append("<!DOCTYPE html>");
templateBuilder.Append("<!--HTML5 doctype-->");
templateBuilder.Append("<html>");
templateBuilder.Append("<head>");
templateBuilder.Append("    <meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\">");
templateBuilder.Append("    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=0\">");
templateBuilder.Append("    <meta name=\"apple-mobile-web-app-capable\" content=\"yes\" />");
templateBuilder.Append("    <title>{site.seo_title}</title>");
templateBuilder.Append("    <script type=\"text/javascript\" charset=\"utf-8\" src=\"{config.webpath}scripts/jquery/jquery-1.11.2.min.js\"></script>");
templateBuilder.Append("    <script src=\"http://res.wx.qq.com/open/js/jweixin-1.0.0.js\"></script>");
templateBuilder.Append("    <script src=\"{config.webpath}scripts/weixin/WxCommon.js\"></script>");
templateBuilder.Append("</head>");
templateBuilder.Append("<body>");
templateBuilder.Append("    <input type=\"hidden\" id=\"hidajaxurl\" value=\"{config.webpath}tools/submit_ajax.ashx\" />");
templateBuilder.Append("    <input type=\"button\" id=\"btnGetLocation\" value=\"获取当前位置\" onclick=\"GetLocation();\" />");
templateBuilder.Append("    <script>");
templateBuilder.Append("        $(function () {");
templateBuilder.Append("            WxCommon.Common.GetJsConfig();");
templateBuilder.Append("            GetLocation();");
templateBuilder.Append("        });");
templateBuilder.Append("");
templateBuilder.Append("        function GetLocation() {");
templateBuilder.Append("            wx.getLocation({");
templateBuilder.Append("                type: \'wgs84\', // 默认为wgs84的gps坐标，如果要返回直接给openLocation用的火星坐标，可传入\'gcj02\'");
templateBuilder.Append("                success: function (res) {");
templateBuilder.Append("                    var latitude = res.latitude; // 纬度，浮点数，范围为90 ~ -90");
templateBuilder.Append("                    var longitude = res.longitude; // 经度，浮点数，范围为180 ~ -180。");
templateBuilder.Append("                    var speed = res.speed; // 速度，以米/每秒计");
templateBuilder.Append("                    var accuracy = res.accuracy; // 位置精度");
templateBuilder.Append("                    $(\"#dvlocation\").html(\"当前纬度：\" + latitude + \"<br />当前经度：\" + longitude + \"<br />当前速度：\" + speed + \"<br />当前精度：\" + accuracy);");
templateBuilder.Append("                }");
templateBuilder.Append("            });");
templateBuilder.Append("        }");
templateBuilder.Append("    </script>");
templateBuilder.Append("    <div id=\"dvlocation\"></div>");
templateBuilder.Append("</body>");
templateBuilder.Append("</html>");
templateBuilder.Append("");
    }
</script>
