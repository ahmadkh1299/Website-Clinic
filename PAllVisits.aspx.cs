using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PAllVisits : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ClassVisits.DeleteDone();
            if (!IsPostBack)
            {
                FillGridView();
            }
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    private void FillGridView()
    {
        try
        {
            string PatientID = ((DataTable)Session["DataTable"]).Rows[0]["PatientID"].ToString();
            DataTable dt = ClassVisits.GetVisitsByPID(PatientID);
            GridViewVisits.DataSource = dt;
            GridViewVisits.DataBind();
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    protected string FormateDate(object obj)
    {
        try
        {
            if (obj is DateTime)
            {
                return ((DateTime)obj).ToString("dd/MM/yyyy");
            }
            return obj.ToString();
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
            return null;
        }
    }
    protected void GridViewVisits_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Label Date = (Label)GridViewVisits.Rows[e.RowIndex].FindControl("LabelVisitDate");
            Label Time = (Label)GridViewVisits.Rows[e.RowIndex].FindControl("LabelTime");
            string PatientID = ((DataTable)Session["DataTable"]).Rows[0]["PatientID"].ToString();
            ClassVisits.DeleteWithoutID(Date.Text, Time.Text, PatientID);
            FillGridView();
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("PVisit.aspx");
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
} 