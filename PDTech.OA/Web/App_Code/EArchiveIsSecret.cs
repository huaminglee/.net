using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// 是否
/// </summary>
public enum EArchiveIsSecret
{
    否 = 0,
    是 = 1
}
/// <summary>
/// 公文状态
/// </summary>
public enum EArchiveIsState
{
    新建=0,
    流转中 = 1,
    已完成 = 2,
    取消 = 9,
}
