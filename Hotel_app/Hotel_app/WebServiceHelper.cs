using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Net;
using System.IO;
using System.Web.Services.Description;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace Hotel_app
{
    /// <summary>
    /// 动态调用WebService 的相关方法
    /// </summary>
    public sealed class DynamicWebServiceCall
    {
        /// <summary>
        /// 动态调用WebService 的方法
        /// </summary>
        /// <param name="pcUrl">WebService 的访问路径 http://localhost:8080/WebServiceTest.asmx </param>
        /// <param name="pcClassName">要调用的类名</param>
        /// <param name="pcMethodName">方法名</param>
        /// <param name="args">方法参数</param>
        /// <returns></returns>
        public static object InvokeWebService(string pcUrl, string pcMethodName, object[] args)
        {
            return InvokeWebService(pcUrl, "", pcMethodName, args);
        }
        /// <summary>
        /// 动态调用WebService 的方法
        /// </summary>
        /// <param name="pcUrl">WebService 的访问路径 http://localhost:8080/  或 http://localhost:8080/WebServiceTest.asmx </param>
        /// <param name="pcClassName">要调用的类名，当Url里已经传动了类名的时候，这里设置为“”</param>
        /// <param name="pcMethodName">方法名</param>
        /// <param name="args">方法参数</param>
        /// <returns></returns>
        /// 




        public static object InvokeWebService(string pcUrl, string pcClassName, string pcMethodName, object[] args)
        {
            object loRetVal = null;

            try
            {
                if (!string.IsNullOrEmpty(pcClassName))
                {
                    pcUrl += pcClassName;
                }
                else
                {
                    pcClassName = GetWsClassName(pcUrl);
                }

                Assembly loAssemble = CreateDynWebServiceAssemble(pcUrl);
                if (loAssemble != null)
                {
                    string lcNameSpace = "Sonic.Web.WebService.DynamicWebService";
                    Type t = loAssemble.GetType(lcNameSpace + "." + pcClassName, true, true);
                    object obj = Activator.CreateInstance(t);
                    MethodInfo loMethodInfo = t.GetMethod(pcMethodName);
                    if (loMethodInfo != null)
                        loRetVal = loMethodInfo.Invoke(obj, args);
                }
            }
            catch (Exception e)
            {
                loRetVal = null;
            }
            return loRetVal;
        }

        /// <summary>
        /// 动态创建WebService的Assembly
        /// </summary>
        /// <param name="pcUrl">WebService 的访问路径 入 http://localhost:8080/WebServiceTest.asmx</param>
        /// <returns></returns>
        public static Assembly CreateDynWebServiceAssemble(string pcUrl)
        {
            Assembly loRetVal = null;
            string lcNameSpace = "Sonic.Web.WebService.DynamicWebService";
            try
            {
                //获取WSDL
                WebClient loWC = new WebClient();
                Stream stream = loWC.OpenRead(pcUrl + "?WSDL");

                ServiceDescription sd = ServiceDescription.Read(stream);
                ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                sdi.AddServiceDescription(sd, "", "");
                CodeNamespace cn = new CodeNamespace(lcNameSpace);

                //生成客户端代理类代码
                CodeCompileUnit ccu = new CodeCompileUnit();
                ccu.Namespaces.Add(cn);
                sdi.Import(cn, ccu);
                CSharpCodeProvider csc = new CSharpCodeProvider();
                ICodeCompiler icc = csc.CreateCompiler();

                //设定编译参数
                CompilerParameters cplist = new CompilerParameters();
                cplist.GenerateExecutable = false;
                cplist.GenerateInMemory = true;
                cplist.ReferencedAssemblies.Add("System.dll");
                cplist.ReferencedAssemblies.Add("System.XML.dll");
                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                cplist.ReferencedAssemblies.Add("System.Data.dll");

                //编译代理类
                CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);
                if (true == cr.Errors.HasErrors)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
                    {
                        sb.Append(ce.ToString());
                        sb.Append(System.Environment.NewLine);
                    }
                    throw new Exception(sb.ToString());
                }

                //生成代理实例，并调用方法
                loRetVal = cr.CompiledAssembly;
            }
            catch (Exception e)
            {
                loRetVal = null;
                throw e;
            }

            return loRetVal;
        }

        private static string GetWsClassName(string wsUrl)
        {
            string[] parts = wsUrl.Split('/');
            string[] pps = parts[parts.Length - 1].Split('.');

            return pps[0];
        }
    }
}
