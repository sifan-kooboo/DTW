using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_app.common_file
{
  public   class  common_CheckPhoneNo
    {
      public static bool checkphoneNo(string phone)
      {
          bool flage = false;
          if (phone.Length == 11)
          {
              //判断第一位
              try
              {
                  int j = Convert.ToInt32(phone[0]);
                  if (j != 1)
                  {
                      return flage = false;
                  }
              }
              catch
              {
                  return flage = false;
              }
              foreach (char p in phone)
              {
                  try
                  {
                      int j = Convert.ToInt32(p);
                  }
                  catch
                  {
                      return false;
                  }
              }
          }
          flage = true;
          return true;
      }
    }
}
