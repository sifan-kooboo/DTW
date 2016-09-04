using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Maticsoft.Common
{
   public class FileToByte
    {
        public static byte[] FileContent(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            try
            {
                byte[] buffur = new byte[fs.Length];
                fs.Read(buffur, 0, (int)fs.Length);

                return buffur;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                if (fs != null)
                {

                    //关闭资源  
                    fs.Close();
                }
            }
        }

    }
}
