using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

public class CNPUBLIC
{
    private static Regex RegNumber = new Regex("^[0-9.]+$");
    ///   <summary>
    ///   判断是否为数字
    ///   </summary>
    ///   <param name="str">传入的字符串</param>
    ///   <returns>返回真假</returns>
    public static bool IsNumeric(string inputData)
    {
        if (inputData == null || inputData.Equals("0"))
            return false;

        Match m = RegNumber.Match(inputData);
        return m.Success;
    }

}