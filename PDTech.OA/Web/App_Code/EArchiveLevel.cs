using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// 公文级别
/// </summary>
public enum EArchiveLevel
{
    全局 = 1,
    本部门 = 2,
}
/// <summary>
/// 是否推送三重一大
/// </summary>
public enum EArchiveSzyd
{
    否 = 0,
    是 = 1,
}
/// <summary>
/// 提醒对象
/// </summary>
public enum EArchiveNextUser
{
    下一步骤办理人员 = 1,
    当前和下一步骤办理人员 = 2,
}
/// <summary>
/// 组织方式
/// </summary>
public enum EArchiveOrgUnit
{
    省级=3,
    市本级 = 1,
    区县级 = 2,
    其它=9,
}
/// <summary>
/// 归档处室
/// </summary>
public enum EArchiveFILE_DEPT
{
    规计处 = 1,
    财务处 = 2,
}