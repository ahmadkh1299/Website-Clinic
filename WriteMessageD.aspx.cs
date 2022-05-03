using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class WriteMessageD : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            FillDDLDoctors();
    }

    protected void FillDDLDoctors()
    {
        try
        {
            if (Session["ToPID"] != null)
            {
                DataTable dt = ClassPatients.GetByID(Session["ToPID"].ToString());
                string Patient = dt.Rows[0]["FName"].ToString();
                Patient += " " + dt.Rows[0]["LName"].ToString();
                ListItem l = new ListItem(Patient, dt.Rows[0]["PatientID"].ToString());
                DropDownList1.Items.Add(l);
            }
            else
            {
                DataTable dt = ClassPatients.GetAll("FName", "ASC");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Patient = dt.Rows[i]["FName"].ToString();
                    Patient += " " + dt.Rows[i]["LName"].ToString();
                    ListItem l = new ListItem(Patient, dt.Rows[i]["PatientID"].ToString());
                    DropDownList1.Items.Add(l);
                }
            }
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    protected void ButtonSend_Click(object sender, EventArgs e)
    {
        try
        {
            string LicenseNumber = ((DataTable)Session["DataTable"]).Rows[0]["LicenseNumber"].ToString();
            ClassMessagesToP obj = new ClassMessagesToP();
            obj.PatientID = DropDownList1.SelectedItem.Value;
            obj.LicenseNumber = LicenseNumber;
            obj.Message = TextBox1.Text;
            obj.Insert();
            Session["ToPID"] = null;
            Response.Redirect("WriteMessageD.aspx");
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }

    protected void ButtonClear_Click(object sender, EventArgs e)
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
}