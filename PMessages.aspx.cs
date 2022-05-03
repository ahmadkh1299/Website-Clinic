using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Messages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ValidUser"] == null || !(bool)Session["ValidUser"])
            {
                    Response.Redirect("LogIn.aspx");
            }
            if (!IsPostBack)
            {
                FillDataList();
            }
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    protected void FillDataList()
    {
        try
        {
            string PatientID = ((DataTable)Session["DataTable"]).Rows[0]["PatientID"].ToString();
            DataTable dt = ClassMessagesToP.GetByPID(PatientID);
            DataListMessages.DataSource = dt;
            DataListMessages.DataBind();
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    protected void DataListMessages_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Reply"))
            {
                Label LicenseNumber = (Label)(e.Item.FindControl("LabelLicenseNumber"));
                Session["ToLN"] = LicenseNumber.Text;
                Response.Redirect("WriteMessageP.aspx");
            }
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
            Response.Redirect("WriteMessageP.aspx");
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    protected void DataListMessages_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        Label LabelLicenseNumber = (Label)(e.Item.FindControl("LabelLicenseNumber"));
        Label LabelMessage = (Label)(e.Item.FindControl("LabelMessage"));
        ClassMessagesToP.Deletes(LabelMessage.Text, LabelLicenseNumber.Text);
        FillDataList();
    }
}