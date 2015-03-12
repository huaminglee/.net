<%@ WebHandler Language="C#" Class="PublicSave" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Data;
using System.Collections.Generic;

/// <summary>
/// Creator：ZSX
/// Date：2014-7-3
/// Use：Public Save
/// Note：Allow Overload
/// </summary>
public class PublicSave : IHttpHandler, IRequiresSessionState
{
    string pageState;
    string[] h_val;
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        //context.Request.QueryString["xxx"];//Get获取
        //context.Request["xxx"];//Post获取
        pageState = context.Request["pageState"];
        switch (pageState)
        {
            case null:
                pageState = context.Request.QueryString["pageState"];//因调用此文件可能为Get/Post，所以需要分别获取
                break;
            case "scjDel":
                /***删除收藏夹***/
                PDTech.OA.BLL.OA_FAVORITE scjDel_bll = new PDTech.OA.BLL.OA_FAVORITE();
                if (scjDel_bll.Delete(Convert.ToDecimal(context.Request["favorite_id"])))
                {
                    context.Response.Write("ok");
                }
                break;
            case "gwzz":
                /***岗位职责***/
                PDTech.OA.BLL.DUTY_RESPONSIBILITY gwzz_dr_bll = new PDTech.OA.BLL.DUTY_RESPONSIBILITY();
                PDTech.OA.Model.DUTY_RESPONSIBILITY gwzz_dr_model = new PDTech.OA.Model.DUTY_RESPONSIBILITY();
                PDTech.OA.BLL.USER_DUTY_RESPONSIBILITY_MAP gwzz_udrm_bll = new PDTech.OA.BLL.USER_DUTY_RESPONSIBILITY_MAP();
                PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP gwzz_udrm_model = new PDTech.OA.Model.USER_DUTY_RESPONSIBILITY_MAP();
                gwzz_dr_model.DUTY_NAME = context.Request["txt_riskName"];
                gwzz_dr_model.RESPONSIBILITY = context.Request["txt_gwzz"];
                gwzz_dr_model.DEPARTMENT_ID = Convert.ToDecimal(context.Request["company"]);
                if (gwzz_dr_bll.Add(gwzz_dr_model))
                {
                    h_val = context.Request["h_val"].TrimEnd(';').Split(';');//取出并拆分岗位人员姓名和人员ID
                    foreach (var item in h_val)
                    {
                        gwzz_udrm_model.USER_ID = Convert.ToDecimal(item.Split(',')[1]);
                        gwzz_udrm_model.DUTY_RESPONSIBILITY_ID = gwzz_dr_model.DUTY_RESPONSIBILITY_ID;
                        gwzz_udrm_bll.Add(gwzz_udrm_model);
                    }
                    context.Response.Write("保存成功！");
                }
                break;
            case "gwzzDel":
                /***删除岗位职责***/
                PDTech.OA.BLL.USER_DUTY_RESPONSIBILITY_MAP gwzzDel_udrm_bll = new PDTech.OA.BLL.USER_DUTY_RESPONSIBILITY_MAP();
                PDTech.OA.BLL.DUTY_RESPONSIBILITY gwzzDel_dr_bll = new PDTech.OA.BLL.DUTY_RESPONSIBILITY();
                if (gwzzDel_udrm_bll.Delete(Convert.ToDecimal(context.Request["duty_responsibility_id"])))
                {
                    if (gwzzDel_dr_bll.Delete(Convert.ToDecimal(context.Request["duty_responsibility_id"])))
                    {
                        context.Response.Write("ok");
                    }
                }
                break;
            case "gwfx":
                /***岗位风险***/
                PDTech.OA.BLL.DUTY_RISK_INFO gwfx_dri_bll = new PDTech.OA.BLL.DUTY_RISK_INFO();
                PDTech.OA.Model.DUTY_RISK_INFO gwfx_dri_model = new PDTech.OA.Model.DUTY_RISK_INFO();
                PDTech.OA.BLL.USER_RISK_MAP gwfx_urm_bll = new PDTech.OA.BLL.USER_RISK_MAP();
                PDTech.OA.Model.USER_RISK_MAP gwfx_urm_model = new PDTech.OA.Model.USER_RISK_MAP();
                gwfx_dri_model.DUTY_NAME = context.Request["txt_riskName"];
                gwfx_dri_model.RISK_NAME = context.Request["txt_dutyRisk"];
                gwfx_dri_model.DEPARTMENT_ID = Convert.ToDecimal(context.Request["company"]);
                gwfx_dri_model.RISK_LEVEL = context.Request["riskLevel"];
                gwfx_dri_model.AVOID_METOH = context.Request["txt_avoidMetoh"];
                if (gwfx_dri_bll.Add(gwfx_dri_model))
                {
                    context.Response.Write("保存成功！");
                }
                h_val = context.Request["h_val"].TrimEnd(';').Split(';');//取出并拆分岗位人员姓名和人员ID
                foreach (var item in h_val)
                {
                    gwfx_urm_model.USER_ID = Convert.ToDecimal(item.Split(',')[1]);
                    gwfx_urm_model.DUTY_RISK_ID = gwfx_dri_model.DUTY_RISK_ID;
                    gwfx_urm_bll.Add(gwfx_urm_model);
                }
                break;
            case "gwfxDel":
                /***删除岗位风险***/
                PDTech.OA.BLL.USER_RISK_MAP gwfxDel_udrm_bll = new PDTech.OA.BLL.USER_RISK_MAP();
                PDTech.OA.BLL.DUTY_RISK_INFO gwfxDel_dri_bll = new PDTech.OA.BLL.DUTY_RISK_INFO();
                if (gwfxDel_udrm_bll.Delete(Convert.ToDecimal(context.Request["duty_risk_id"])))
                {
                    if (gwfxDel_dri_bll.Delete(Convert.ToDecimal(context.Request["duty_risk_id"])))
                    {
                        context.Response.Write("ok");
                    }
                }
                break;
            case "uInfo":
                /***保存个人信息***/
                PDTech.OA.BLL.USER_INFO ui_bll_uInfo = new PDTech.OA.BLL.USER_INFO();
                PDTech.OA.Model.USER_INFO ui_model_uInfo = new PDTech.OA.Model.USER_INFO();
                ui_model_uInfo.USER_ID = Convert.ToDecimal(context.Session["user_id"]);
                ui_model_uInfo.PHONE = context.Request["txt_phone"];
                ui_model_uInfo.MOBILE = context.Request["txt_mPhone"];
                if (ui_bll_uInfo.Update(ui_model_uInfo))
                {
                    context.Response.Write("保存成功！");
                }
                break;
            case "cPwd":
                /***修改密码***/
                PDTech.OA.BLL.USER_INFO ui_bll_cPwd = new PDTech.OA.BLL.USER_INFO();
                PDTech.OA.Model.USER_INFO ui_model_cPwd = new PDTech.OA.Model.USER_INFO();
                ui_model_cPwd.USER_ID = Convert.ToDecimal(context.Session["user_id"]);
                ui_model_cPwd.LOGIN_PWD = FormsAuthentication.HashPasswordForStoringInConfigFile(context.Request["txt_confirmPwd"], "MD5");
                if (ui_bll_cPwd.UpdatePwd(ui_model_cPwd))
                {
                    context.Response.Write("yes");
                }
                break;
            case "riskAdd":
                /***添加风险防控***/
                PDTech.OA.BLL.RISK_POINT_INFO riskAdd_bll = new PDTech.OA.BLL.RISK_POINT_INFO();
                PDTech.OA.Model.RISK_POINT_INFO riskAdd_model = new PDTech.OA.Model.RISK_POINT_INFO();
                riskAdd_model.STEP_TYPE = context.Request["riskType"];
                riskAdd_model.RISK_LEVEL = Convert.ToDecimal(context.Request["riskLevel"]);
                riskAdd_model.RISK_POINT = context.Request["txt_riskPoint"];
                riskAdd_model.RISK_RESOLVE = context.Request["txt_riskResolve"];
                riskAdd_model.REMARK = context.Request["txt_remark"];
                riskAdd_model.STEP_ID = Convert.ToDecimal(context.Request["riskStep"]);
                if (riskAdd_bll.Add(riskAdd_model))
                {
                    context.Response.Write("yes");
                }
                break;
            case "riskUpdate":
                /***更新风险防控***/
                PDTech.OA.BLL.RISK_POINT_INFO riskUpdate_bll = new PDTech.OA.BLL.RISK_POINT_INFO();
                PDTech.OA.Model.RISK_POINT_INFO riskUpdate_model = new PDTech.OA.Model.RISK_POINT_INFO();
                if (context.Request["h_id"] != "" && context.Request["h_id"] != null)
                {
                    riskUpdate_model.RISK_POINT_ID = Convert.ToDecimal(context.Request["h_id"]);
                }
                riskUpdate_model.STEP_TYPE = context.Request["riskType"];
                riskUpdate_model.RISK_LEVEL = Convert.ToDecimal(context.Request["riskLevel"]);
                riskUpdate_model.RISK_POINT = context.Request["txt_riskPoint"];
                riskUpdate_model.RISK_RESOLVE = context.Request["txt_riskResolve"];
                riskUpdate_model.REMARK = context.Request["txt_remark"];
                riskUpdate_model.STEP_ID = Convert.ToDecimal(context.Request["riskStep"]);
                if (riskUpdate_bll.Update(riskUpdate_model))
                {
                    context.Response.Write("yes");
                }
                break;
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}