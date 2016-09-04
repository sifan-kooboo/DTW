
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
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection.Emit;


namespace Hotel_app.Qyddj
{
   public  sealed class Q_temp_1
    {

        //object obj = WinDllInvoke("Kernel32.dll", "Beep", new object[] { 750, 300 }, typeof(void));


         [System.Runtime.InteropServices.DllImport("kernel32")]
          private static extern IntPtr LoadLibrary(string lpLibFileName);
  
          [System.Runtime.InteropServices.DllImport("kernel32")]
          private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
  
          [System.Runtime.InteropServices.DllImport("kernel32")]
          private static extern IntPtr FreeLibrary(IntPtr hLibModule);
 
         /// <summary>
         /// 动态调用Windows DLL
         /// </summary>
         /// <param name="fileName">Dll文件名</param>
         /// <param name="funName">待调用的函数名</param>
         /// <param name="objParams">函数参数</param>
        /// <param name="returnType">返回值</param>
         /// <returns>调用结果</returns>
         public static object WinDllInvoke(string fileName, string funName, object[] objParams, Type returnType)
         {
             IntPtr libHandle = IntPtr.Zero;
 
             try
             {
                 //获取函数地址
                 libHandle = LoadLibrary(fileName);
                if (libHandle == IntPtr.Zero) return null;
                 IntPtr procAddres = GetProcAddress(libHandle, funName);
                 if (procAddres == IntPtr.Zero) return null;
                 
                 //获取参数类型
                 Type[] paramTypes = new Type[objParams.Length];
                for (int i = 0; i < objParams.Length; ++i)
                 {
                     paramTypes[i] = objParams[i].GetType();
                 }
 
                 //构建调用方法模型
                 AssemblyName asembyName = new AssemblyName();
                 asembyName.Name = "WinDllInvoke_Assembly";
                 AssemblyBuilder asembyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asembyName, AssemblyBuilderAccess.Run);
                 ModuleBuilder moduleBuilder = asembyBuilder.DefineDynamicModule("WinDllInvoke");
                 MethodBuilder methodBuilder = moduleBuilder.DefineGlobalMethod("InvokeFun", MethodAttributes.Public | MethodAttributes.Static, returnType, paramTypes);
 
                 //获取一个 ILGenerator ，用于发送所需的 IL 
                 ILGenerator IL = methodBuilder.GetILGenerator();
                 for (int j = 0; j < paramTypes.Length; ++j)
                 {
                     //将参数压入堆栈
                     if (paramTypes[j].IsValueType)
                     {
                         IL.Emit(OpCodes.Ldarg, j); //By Value
                     }
                     else
                     {
                         IL.Emit(OpCodes.Ldarga, j); //By Addrsss
                     }
                }
 
                 // 判断处理器类型
                 if (IntPtr.Size == 4)
                 {
                     IL.Emit(OpCodes.Ldc_I4, procAddres.ToInt32());
                 }
                 else if (IntPtr.Size == 8)
                 {
                     IL.Emit(OpCodes.Ldc_I8, procAddres.ToInt64());
                 }
                 else
                 {
                     throw new PlatformNotSupportedException("不好意思，偶不认得你哦！");
                 }
 
                 IL.EmitCalli(OpCodes.Calli, CallingConvention.StdCall, returnType, paramTypes);
                 IL.Emit(OpCodes.Ret); // 返回值 
                 moduleBuilder.CreateGlobalFunctions();
 
                 // 取得方法信息 
                 MethodInfo methodInfo = moduleBuilder.GetMethod("InvokeFun");
 
                 return methodInfo.Invoke(null, objParams);// 调用方法，并返回其值
             }
            catch { return null; }
             finally
             {
                 if (libHandle != IntPtr.Zero) FreeLibrary(libHandle); //释放资源
             }
        }




    }
}
