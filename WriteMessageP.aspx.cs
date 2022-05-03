using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class WriteMessageP : System.Web.UI.Page
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
            if (Session["ToLN"] != null)
            {
                DataTable dt = ClassDoctors.GetByLN(Session["ToLN"].ToString());
                string Doctor = dt.Rows[0]["FName"].ToString();
                Doctor += " " + dt.Rows[0]["LName"].ToString();
                Doctor += "         (" + dt.Rows[0]["Specialty"].ToString()+")";
                ListItem l = new ListItem(Doctor, dt.Rows[0]["LicenseNumber"].ToString());
                DropDownList1.Items.Add(l);
            }
            else
            {
                DataTable dt = ClassDoctors.GetAlls();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Doctor = dt.Rows[i]["FName"].ToString();
                    Doctor += " " + dt.Rows[i]["LName"].ToString();
                    Doctor += "         (" + dt.Rows[i]["Specialty"].ToString() + ")";
                    ListItem l = new ListItem(Doctor, dt.Rows[i]["LicenseNumber"].ToString());
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
            string PatientID = ((DataTable)Session["DataTable"]).Rows[0]["PatientID"].ToString();
            ClassMessagesToD obj = new ClassMessagesToD();
            obj.LicenseNumber = DropDownList1.SelectedItem.Value;
            obj.PatientID = PatientID;
            obj.Message = TextBox1.Text;
            obj.Insert();
            Session["ToLN"] = null;
            Response.Redirect("WriteMessageP.aspx");
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
            Response.Redirect("WriteMessageP.aspx");
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
}