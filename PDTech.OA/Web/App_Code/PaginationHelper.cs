using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

/// <summary>分页工具类
/// Creator：ZSX
/// Date：2014-7-22
/// Use：返回分页的必要数据（如：总条数）
/// Note：Allow Overload
/// </summary>
[DataContract]
public class PaginationHelper
{
    /// <summary>
    /// 数据源（序列化后的json字符串）
    /// </summary>
    [DataMember(Order = 0)]
    public string DataSources { get; set; }

    /// <summary>
    /// 总条数（分页用的属性）
    /// </summary>
    [DataMember(Order = 1)]
    public int TotalNum { get; set; }
}

[DataContract]
public class Pagination
{
    /// <summary>
    /// 总条数（分页用的属性）
    /// </summary>
    [DataMember(Order = 0)]
    public int total { get; set; }

    /// <summary>
    /// 数据源（序列化后的json字符串）
    /// </summary>
    [DataMember(Order = 1)]
    public List<Pagination> rows { get; set; }

    /// <summary>
    /// 类型名称（序列化后的json字符串）
    /// </summary>
    [DataMember(Order = 2)]
    public string type_name { get; set; }
}