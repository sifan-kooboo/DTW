using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using Microsoft.Win32;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Data;
namespace Hotel_app.common_file
{
    public static class Common_initalSystem
    {

       //读配置文件的值
       public static string ReadXML(string node, string appKey)
       {
           string CurrentVlaue = "";
           XmlDocument xmlDoc = new XmlDocument();
           string path = Application.StartupPath + "\\XmlSystemInfo.xml";
           xmlDoc.Load(path);
           XmlNodeList nodes = xmlDoc.GetElementsByTagName(node);
           //XmlNodeList nodes = xmlDoc.SelectSingleNode(node).ChildNodes;
           for (int i = 0; i < nodes.Count; i++)
           {
               //得到当前属性KEY的值
               XmlAttribute att = nodes[i].Attributes["key"];
               if (att.Value == appKey)
               {
                   att = nodes[i].Attributes["value"];
                   CurrentVlaue = att.Value.ToString();
                   break;
               }
           }
           return CurrentVlaue;
       }


       //根据节点信息自动读取
       public static string ReadValue(string sectionName, string key)
       {
           string value = "";
           XmlDocument Doc = new XmlDocument();
           string path = Application.StartupPath.ToString() + "\\Hotel_app.exe.config";
           Doc.Load(path);
           string type = "";
           //XmlNodeList nodes = Doc.GetElementsByTagName("section");
           XmlNodeList nodes = Doc.GetElementsByTagName(sectionName);

           for (int i = 0; i < nodes.Count; i++)
           {
               //获取sectionName对应的TYPE值
               XmlNode node_temp = (XmlNode)nodes[i];
               string p = node_temp.ChildNodes.Count.ToString();
               XmlAttribute att = nodes[i].Attributes["name"];
               if (att.Value == sectionName)
               {
                   type = nodes[i].Attributes["type"].Value.ToString();
                   if (type == "System.Configuration.DictionarySectionHandler")
                   {
                       value = ReadDictionarySectionValue(sectionName, key); break;
                   }
                   if (type == "System.Configuration.NameValueSectionHandler")
                   {
                       value = ReadNameValueSectionValue(sectionName, key); break;
                   }
                   if (type == "System.Configuration.SingleTagSectionHandler")
                   {
                       value = ReadAPPConfig(sectionName, key); break;
                   }
               }
           }
           return value;
       }


       //singleTagSectionHandler
       public static string ReadAPPConfig(string sectinName, string key)
       {
           string ss = "";
           IDictionary IDTest1 = (IDictionary)ConfigurationManager.GetSection(sectinName);
           return ss = IDTest1[key].ToString();
       }

       //DictionarySectionHandler
       public static string ReadDictionarySectionValue(string SectionName, string key)
       {
           string value = "";
           IDictionary Test1 = (IDictionary)ConfigurationManager.GetSection(SectionName);
           foreach (string s in Test1.Keys)
           {
               if (s == key)
               {
                   value = Test1[key].ToString();
                   break;
               }
               else
                   continue;
           }
           return value;
       }

       //NameValueSectionHandler
       public static string ReadNameValueSectionValue(string SectionName, string Key)
       {
           string Value = "";
           NameValueCollection Test3 = (NameValueCollection)ConfigurationManager.GetSection(SectionName);
           foreach (string s in Test3.AllKeys)
           {
               if (s == Key)
               {
                   Value = Test3[s].ToString();
                   break;
               }
               else
                   continue;
           }
           return Value;
       }

       //按节点值保存配置信息
       public static void SaveConfig(string keyValue, string value)
       {
           XmlDocument doc = new XmlDocument();
           //获得配置文件的全路径
           string strFileName = Application.StartupPath.ToString() + "\\Hotel_app.exe.config";
           doc.Load(strFileName);
           //找出名称为“add”的所有元素
           XmlNodeList nodes = doc.GetElementsByTagName("add");
           for (int i = 0; i < nodes.Count; i++)
           {
               //获得当前元素的key属性
               XmlAttribute att = nodes[i].Attributes["key"];
               if (att != null)
               {
                   //根据元素的第一个属性来判断当前的元素是不是目标元素
                   if (att.Value == keyValue)
                   {
                       //对目标元素中的第二个属性赋值
                       att = nodes[i].Attributes["value"];
                       att.Value = value;
                       //保存上面的修改
                       doc.Save(strFileName);
                   }
               }
           }

       }

       //按节点值保存配置信息
       public static void SaveConfig(string  fileName,string keyValue, string value)
       {
           XmlDocument doc = new XmlDocument();
           //获得配置文件的全路径
           string strFileName = Application.StartupPath.ToString() + "\\"+fileName;
           doc.Load(strFileName);
           //找出名称为“add”的所有元素
           XmlNodeList nodes = doc.GetElementsByTagName("add");
           for (int i = 0; i < nodes.Count; i++)
           {
               //获得当前元素的key属性
               XmlAttribute att = nodes[i].Attributes["key"];
               if (att != null)
               {
                   //根据元素的第一个属性来判断当前的元素是不是目标元素
                   if (att.Value == keyValue)
                   {
                       //对目标元素中的第二个属性赋值
                       att = nodes[i].Attributes["value"];
                       att.Value = value;
                       //保存上面的修改
                       doc.Save(strFileName);
                   }
               }
           }

       }

       internal static bool CheckSoftEnableIsOk()
       {
           bool flage = false;
           try
           {
               //检查当前版本是什么版本
               string VersionType = ReadXML("add", "xxzs");
               //正式版
               if (VersionType.Equals(common_app.xxzs_zs))
               {
                   //对注册码和时间的检查
                   string RegKeyCurrent = ReadXML("add", "RegisterKey");
                   //读注册表
                   object RegKeyRegisterKeyRight = Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\MThotelSoft", "MThotelSoft", 0);
                   if (RegKeyRegisterKeyRight != null && RegKeyRegisterKeyRight.ToString().Equals(RegKeyCurrent))
                   {
                       //检查时间
                       DateTime startTime = DateTime.Parse(ReadXML("add", "startTime"));
                       DateTime EndTime = DateTime.Parse(ReadXML("add", "endTime"));
                       if (startTime < DateTime.Now && DateTime.Now < EndTime)
                       {
                           flage = true;
                       }
                       else
                       {
                           if (common_file.common_app.message_box_show_select(common_app.message_title, "您好,注册码己经失效,请联系软件开发者购买"))
                           {
                               //打开注册页面

                               //弹出注册界面
                               Frm_Register Frm_register_new = new Frm_Register();
                               Frm_register_new.StartPosition = FormStartPosition.CenterScreen;
                               if (Frm_register_new.ShowDialog().Equals(DialogResult.OK))
                               {
                                   if (Frm_register_new.IsRegister)
                                   {
                                       flage = true;
                                   }
                               }
                           }
                       }
                   }
                   else//没有查到，继续显示注册
                   {
                       if (common_file.common_app.message_box_show_select(common_app.message_title, "您好,注册码失效,请重新填写"))
                       {
                           //打开注册页面

                           //弹出注册界面
                           Frm_Register Frm_register_new = new Frm_Register();
                           Frm_register_new.StartPosition = FormStartPosition.CenterScreen;
                           if (Frm_register_new.ShowDialog().Equals(DialogResult.OK))
                           {
                               if (Frm_register_new.IsRegister)
                               {
                                   flage = true;
                               }
                           }
                       }
                   }
               }
               //试用版
               if (VersionType.Equals(common_app.xxzs_xx))
               {
                   //弹出注册界面
                   Frm_Register Frm_register_new = new Frm_Register();
                   Frm_register_new.StartPosition = FormStartPosition.CenterScreen;
                   if (Frm_register_new.ShowDialog().Equals(DialogResult.OK))
                   {
                       if (Frm_register_new.IsRegister)
                       {
                           flage = true;
                       }
                   }
               }
           }
           catch (Exception  ee)
           {
               common_app.Message_box_show(common_app.message_title, "系统文件丢失,请联系软件开发商");
               common_czjl.add_czjl(common_file.common_app.yydh, common_file.common_app.qymc, common_file.common_app.czy, ee.ToString(), "系统错误", ee.ToString(), DateTime.Now);
           }
           return flage;
       }


       //通过参数生成序列号(每个都是生成32位16进制的数据)
       public static string GenerateStr(string[] ss)
       {  
           string  result="";
           if (ss.Length > 0)
           {
               foreach (string tempStr in ss)
               {
                   //定长500
                   if (tempStr.Length < 200)
                   {
                       //如果不足200的
 
                   }
                   else
                   {

                   }
               }
           }

           return result;
       }

      //返回注册信息
       public static int GetRegisterStaus(string info)
       {
            int  flage = 100;
           SqlParameter[] parms1 = new SqlParameter[2];
           parms1[0] = new SqlParameter("@VerfiyInfo", SqlDbType.VarChar,2000);
           parms1[1] = new SqlParameter("@flage",SqlDbType.Int);
           parms1[1].Direction = ParameterDirection.Output;
           parms1[0].Value = info;

           DbHelperSQL.RunProcedure("GetRegInfo", parms1);
           try
           {
               flage = int.Parse(parms1[1].Value.ToString());

           }
           catch
           {
               flage = 100;//配置文件出错,请检查配置文件中的数据库连接信息
           }
           return flage;
       }
    }
}
