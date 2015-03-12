using System;
using System.Collections.Generic;
using System.Web;

public class ConvertHelper
{
    // Fields
    private object _obj;

    public ConvertHelper(object obj)
    {
        this._obj = obj;
    }
    public override string ToString()
    {
        return Convert.ToString(this._obj);
    }
    public string String
    {
        get
        {
            return this.ToString();
        }
    }
    public bool? ToBool
    {
        get
        {
            if ((this._obj == null) || (this._obj == Convert.DBNull))
            {
                return null;
            }
            if ((this.String.ToLower() == "false") || (this.String == "0"))
            {
                return false;
            }
            return true;
        }
    }
    public DateTime? ToDateTime
    {
        get
        {
            DateTime time;
            if (DateTime.TryParse(this.String, out time))
            {
                return new DateTime?(time);
            }
            return null;
        }
    }
    public decimal? ToDecimal
    {
        get
        {
            decimal num;
            if (decimal.TryParse(this.String, out num))
            {
                return new decimal?(num);
            }
            return null;
        }
    }
    public double? ToDouble
    {
        get
        {
            double num;
            if (double.TryParse(this.String, out num))
            {
                return new double?(num);
            }
            return null;
        }
    }
    public float? ToFloat
    {
        get
        {
            float num;
            if (float.TryParse(this.String, out num))
            {
                return new float?(num);
            }
            return null;
        }
    }
    public int? ToInt32
    {
        get
        {
            int num;
            if (int.TryParse(this.String, out num))
            {
                return new int?(num);
            }
            return null;
        }
    }
    public long? ToInt64
    {
        get
        {
            long num;
            if (long.TryParse(this.String, out num))
            {
                return new long?(num);
            }
            return null;
        }
    }
}