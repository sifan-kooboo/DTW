using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Hotel_app.common_file
{
   public class common_ClearControlsValue
    {
        public static void ClearControlsValue(Panel p, string[] exceptControlsNames)
        {
            bool flage = false;
            if (p is Panel)
            {
                foreach (Control Tb in p.Controls)
                {
                    foreach (string cc_name in exceptControlsNames)
                    {
                        if (Tb.Name != cc_name)
                            continue;
                        if (Tb.Name == cc_name)
                        {
                            flage = true;
                            break;
                        }
                    }
                    if (flage)
                    { 
                    }
                    else
                    {
                        if (Tb is TextBox)
                        {
                            Tb.Text = "";
                        }
                        if (Tb is DateTimePicker)
                        {
                            Tb.Text = common_app.cssj;
                        }
                    }
                }
            }
        }

       /// <summary>
       /// 设置panel上的控制的可视性
       /// </summary>
       /// <param name="panelControl">panel的names</param>
       /// <param name="exceptControlsNames">不需要设置的控制的name</param>
       /// <param name="flage">为真是不可用</param>
        public static void SetControlDisable(Control panelControl,string[] exceptControlsNames,bool flage)
       {
           if (panelControl is Panel || panelControl is TabPage)
           {
               foreach (Control temp in panelControl.Controls)
               {
                   if (flage)
                   {
                       int i = 0;
                       if (exceptControlsNames.Length > 0)
                       {
                           foreach (string ss in exceptControlsNames)
                           {
                               if (temp.Name == ss) //找到后直接跳出
                               {
                                   i = 1;
                                   break;
                               }
                           }
                       }
                       if (i == 0)
                       {
                           //文本框
                           if (temp is TextBox)
                           {
                               ((TextBox)temp).ReadOnly = true;
                               temp.BackColor = Color.LimeGreen;
                           }
                           //if ((temp is ComboBox) || (temp is Button) || (temp is DateTimePicker))
                           //{
                           //    temp.Enabled = false;
                           //    if ((temp is ComboBox) || (temp is DateTimePicker))
                           //    {
                           //        temp.BackColor = Color.LimeGreen;
                           //    }
                           //}

                           if ((temp is Button) || (temp is DateTimePicker))
                           {
                               temp.Enabled = false;
                               //if ((temp is ComboBox) || (temp is DateTimePicker))
                               //{
                               //    temp.BackColor = Color.LimeGreen;
                               //}
                           }
                       }
                   }
                   if (!flage)
                   {
                       int i = 0;
                       if (exceptControlsNames.Length > 0)
                       {
                           foreach (string ss in exceptControlsNames)
                           {
                               if (temp.Name == ss) //找到后直接跳出
                               {
                                   i = 1;
                                   break;
                               }
                           }
                       }
                       if (i ==0)
                       {
                           if (temp is TextBox)
                           {
                               ((TextBox)temp).ReadOnly = false;
                               temp.BackColor = Color.White;
                           }
                           //下拉框
                           if ((temp is ComboBox) || (temp is DateTimePicker))
                           {
                               temp.Enabled = true;
                               temp.BackColor = Color.White;
                           }
                           if (temp is Button)
                           {
                               temp.Enabled = true;
                               temp.BackColor = Color.DimGray;
                           }
                       }
                   }
               }
           }
       }
    }
}
