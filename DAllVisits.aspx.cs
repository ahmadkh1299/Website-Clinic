using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DAllVisits : System.Web.UI.Page
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
    protected void FillGridView()
    {
        try
        {
            string LicenseNumber = ((DataTable)Session["DataTable"]).Rows[0]["LicenseNumber"].ToString();
            DataTable dt = ClassVisits.GetVisitsByLN(LicenseNumber);
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
            string LicenseNumber = ((DataTable)Session["DataTable"]).Rows[0]["LicenseNumber"].ToString();
            string FName=((DataTable)Session["DataTable"]).Rows[0]["FName"].ToString();
            string LName=((DataTable)Session["DataTable"]).Rows[0]["LName"].ToString();
            Label PatientID = (Label)GridViewVisits.Rows[e.RowIndex].FindControl("LabelPatientID");
            Label Date = (Label)GridViewVisits.Rows[e.RowIndex].FindControl("LabelVisitDate");
            Label Time = (Label)GridViewVisits.Rows[e.RowIndex].FindControl("LabelTime");
            ClassVisits.DeleteWithoutID(Date.Text, Time.Text, PatientID.Text);
            ClassMessagesToP obj = new ClassMessagesToP();
            obj.PatientID = PatientID.Text;
            obj.LicenseNumber = LicenseNumber;
            obj.Message = "Sorry to inform you, but your visit at " + Date.Text + " " + Time.Text + " Has been canceld for personal reasons";
            obj.Insert();
            FillGridView();
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
}