using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DMessages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!((bool)Session["ValidUser"]))
                Response.Redirect("LogIn.aspx");
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
            string LicenseNumber = ((DataTable)Session["DataTable"]).Rows[0]["LicenseNumber"].ToString();
            DataTable dt = ClassMessagesToD.GetByLN(LicenseNumber);
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
                Label patientID = (Label)(e.Item.FindControl("LabelPatientID"));
                Session["ToPID"] = patientID.Text;
                Response.Redirect("WriteMessageD.aspx");
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
            Response.Redirect("WriteMessageD.aspx");
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message; 
        }
    }
    protected void DataListMessages_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        Label patientID = (Label)(e.Item.FindControl("LabelPatientID"));
        Label LabelMessage = (Label)(e.Item.FindControl("LabelMessage"));
        ClassMessagesToD.Deletes(LabelMessage.Text, patientID.Text);
        FillDataList();
    }
}