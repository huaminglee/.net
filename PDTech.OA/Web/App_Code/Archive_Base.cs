using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Archive_Base 的摘要说明
/// </summary>
public class Archive_Base
{

    /// <summary>
    /// 获取公文可执行的下一步列表
    /// </summary>
    /// <param name="p_archive"></param>
    /// <param name="p_all_step"></param>
    /// <param name="p_next_steps"></param>
    /// <param name="p_curr_step_id"></param>
    public static void GetAvailableSteps(PDTech.OA.Model.OA_ARCHIVE p_archive, List<PDTech.OA.Model.WORKFLOW_STEP> p_all_step,
            List<PDTech.OA.Model.WORKFLOW_STEP> p_next_steps, Decimal p_curr_step_id)
    {
        PDTech.OA.Model.WORKFLOW_STEP c_step = p_all_step.Where(s => s.STEP_ID == p_curr_step_id).FirstOrDefault();
        if (c_step.IS_LOOP_STEP == "1")//是否该步骤是否允许重复
        {
            p_next_steps.Add(c_step);
        }
        GetNextStepListBySkip(p_all_step, p_next_steps, p_curr_step_id);///根据下一步是否可以跳过，获取可用下一步列表
        if (p_archive != null && p_archive.RESPONSE_USER.HasValue && CurrentAccount.USER_ID == p_archive.RESPONSE_USER.Value) //专管员可直接结束流程
        {
            PDTech.OA.Model.WORKFLOW_STEP end_step = p_all_step.Where(s => s.END_FLAG == "1").FirstOrDefault();
            if (!p_next_steps.Contains(end_step))
                p_next_steps.Add(end_step);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="p_all_step">获取到的所有数据集合</param>
    /// <param name="p_next_steps">返回下一步可指向步骤集合</param>
    /// <param name="p_curr_step_id">当前步骤ID</param>
    public static void GetNextStepListBySkip(List<PDTech.OA.Model.WORKFLOW_STEP> p_all_step, List<PDTech.OA.Model.WORKFLOW_STEP> p_next_steps, Decimal p_curr_step_id)
    {
        PDTech.OA.Model.WORKFLOW_STEP c_step = p_all_step.Where(s => s.STEP_ID == p_curr_step_id).FirstOrDefault();

        if (c_step != null && c_step.NEXT_STEP_ID.HasValue)
        {
            PDTech.OA.Model.WORKFLOW_STEP next_step = p_all_step.Where(s => s.STEP_ID == c_step.NEXT_STEP_ID.Value).FirstOrDefault();
            if (!p_next_steps.Contains(next_step))
                p_next_steps.Add(next_step);
            if (next_step.IS_SKIP != null && next_step.IS_SKIP == "1")
                GetNextStepListBySkip(p_all_step, p_next_steps, next_step.STEP_ID.Value);
        }
    }

}