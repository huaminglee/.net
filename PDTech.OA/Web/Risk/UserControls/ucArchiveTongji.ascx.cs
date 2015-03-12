using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Risk_UserControls_ucArchiveTongji : System.Web.UI.UserControl
{
    PDTech.OA.BLL.VIEW_ARCHIVE_FILE_TASK viewtBll = new PDTech.OA.BLL.VIEW_ARCHIVE_FILE_TASK();
    StringBuilder strwhere ;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PDTech.OA.BLL.OA_ARCHIVE_TYPE tBll = new PDTech.OA.BLL.OA_ARCHIVE_TYPE();
            //IList<PDTech.OA.Model.OA_ARCHIVE_TYPE> tList = tBll.get_ArchiveTypeList(new PDTech.OA.Model.OA_ARCHIVE_TYPE() { });
            //foreach (var item in tList)
            //{
            //    ListItem items = new ListItem();
            //    if (item.ARCHIVE_TYPE != 51)
            //    {
            //        items.Value = item.ARCHIVE_TYPE.ToString();
            //        items.Text = item.TYPE_NAME;
            //        dplBusinessType.Items.Add(items);
            //    }

            //}
            //ListItem item_default = new ListItem();
            //item_default.Value = "";
            //item_default.Text = "---请选择---";
            //dplBusinessType.Items.Insert(0, item_default);
            txtsTime.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            txteTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            BindGird(GridView1,"ARCHIVE_TYPE_NAME");         
        }
    }
    private void BindGird(GridView gv,string ftype)
    {
        strwhere = new StringBuilder();
        if (!string.IsNullOrEmpty(txtsTime.Text.Trim()))
        {
            strwhere.Append(string.Format(@" AND START_TIME>=CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txtsTime.Text).ToString("yyyy-MM-dd HH:mm:ss"))));
        }
        if (!string.IsNullOrEmpty(txteTime.Text.Trim()))
        {
            strwhere.Append(string.Format(@" AND START_TIME<=CONVERT(DATETIME,'{0}',120) ", (Convert.ToDateTime(txteTime.Text).ToString("yyyy-MM-dd HH:mm:ss"))));
        }
       
        //if (!string.IsNullOrEmpty(hidDeptName.Value) && hidDeptName.Value != "---请选择---")
             
        //if (!string.IsNullOrEmpty(hidUserName.Value) && hidUserName.Value != "---请选择---" && hidDeptName.Value != "---请选择---")


        DataTable dt = viewtBll.getArchiveTongji(strwhere.ToString(), ftype);
        if (dt.Rows.Count>0)
        {
            gv.DataSource = dt;
            gv.DataBind();

        }
        else
        {
            gv.DataSource = null;
            gv.DataBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        total = 0;
        fininus = 0;
        unfininus = 0;
        GridView1.Visible = true;
        gvDept.Visible = false;
        gvPerson.Visible = false;
        BindGird(GridView1,"ARCHIVE_TYPE_NAME");
    }
    protected void btnSearchP_Click(object sender, EventArgs e)
    {
        total = 0;
        fininus = 0;
        unfininus = 0;
        GridView1.Visible = false;
        gvDept.Visible = false;
        gvPerson.Visible = true;
        BindGird(gvPerson, "FULL_NAME");
    }
    protected void btnSearchD_Click(object sender, EventArgs e)
    {
        total = 0;
        fininus = 0;
        unfininus = 0;
        GridView1.Visible = false;
        gvDept.Visible = true;
        gvPerson.Visible = false;
        BindGird(gvDept, "DEPARTMENT_NAME");
    }
    private int total = 0,fininus=0,unfininus=0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbfinished = e.Row.FindControl("lbfinished") as Label;
            Label lbunfinished = e.Row.FindControl("lbunfinished") as Label;
            int totalnums = int.Parse(e.Row.Cells[1].Text.ToString());
            string archivetype = e.Row.Cells[0].Text.ToString();
            string cstrwhere = " ARCHIVE_TYPE_NAME='" + archivetype + "' ";
            if (strwhere != null)
            {
                 cstrwhere += strwhere;
            }            

            DataTable dt = viewtBll.getArchiveunfinished(cstrwhere);
            int unfinishnums = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            lbunfinished.Text = unfinishnums.ToString();
            lbfinished.Text = (totalnums - unfinishnums).ToString();
            unfininus += unfinishnums;
            fininus += (totalnums - unfinishnums);
            total += totalnums;

        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计：";
            e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[1].Text = total.ToString();
            e.Row.Cells[2].Text = fininus.ToString();
            e.Row.Cells[3].Text = unfininus.ToString();
        }
    }
    protected void gvPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbfinished = e.Row.FindControl("lbfinished") as Label;
            Label lbunfinished = e.Row.FindControl("lbunfinished") as Label;
            int totalnums = int.Parse(e.Row.Cells[1].Text.ToString());
            string cPerson = e.Row.Cells[0].Text.ToString();
            string cstrwhere = " FULL_NAME='" + cPerson + "' ";
            if (strwhere != null)
            {
                cstrwhere += strwhere;
            }            
            DataTable dt = viewtBll.getArchiveunfinished(cstrwhere);
            int unfinishnums = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            lbunfinished.Text = unfinishnums.ToString();
            lbfinished.Text = (totalnums - unfinishnums).ToString();
            unfininus += unfinishnums;
            fininus += (totalnums - unfinishnums);
            total += totalnums;
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计：";
            e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[1].Text = total.ToString();
            e.Row.Cells[2].Text = fininus.ToString();
            e.Row.Cells[3].Text = unfininus.ToString();
        }
    }
    protected void gvDept_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbfinished = e.Row.FindControl("lbfinished") as Label;
            Label lbunfinished = e.Row.FindControl("lbunfinished") as Label;
            int totalnums = int.Parse(e.Row.Cells[1].Text.ToString());
            string cdept = e.Row.Cells[0].Text.ToString();
            string cstrwhere = " DEPARTMENT_NAME='" + cdept + "' ";
            if (strwhere != null)
            {
                cstrwhere += strwhere;
            }            
            DataTable dt = viewtBll.getArchiveunfinished(cstrwhere);
            int unfinishnums = int.Parse(dt.Rows[0].ItemArray[0].ToString());
            lbunfinished.Text = unfinishnums.ToString();
            lbfinished.Text = (totalnums - unfinishnums).ToString();
            unfininus += unfinishnums;
            fininus += (totalnums - unfinishnums);
            total += totalnums;
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "合计：";
            e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[1].Text = total.ToString();
            e.Row.Cells[2].Text = fininus.ToString();
            e.Row.Cells[3].Text = unfininus.ToString();
        }
    }
}