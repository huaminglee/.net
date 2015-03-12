using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// 公文紧急程度
/// </summary>
public enum EArchiveUrgency
{
    普通 = 0,
    急件 = 1,
    特急 = 2
}
/// <summary>
/// 风险处置等级
/// </summary>
public enum EArchiveRiskLevel
{
    一级 = 1,
    二级 = 2,
    三级 = 3
}