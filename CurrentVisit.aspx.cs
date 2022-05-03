using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CurrentVisit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string LicenseNumber = ((DataTable)(Session["DataTable"])).Rows[0]["LicenseNumber"].ToString();
            string Description = "The Patient Came in complaining about ";
            Description += TextBox2.Text + "\n";
            Description += "I see that the daiagnosses is ";
            Description += TextBox3.Text + "\n";
            Description += "And The Best Medication will be ";
            Description += TextBox4.Text;
            string PatientID = TextBox1.Text;
            ClassHistory obj = new ClassHistory();
            obj.LicenseNumber = LicenseNumber;
            obj.PatientID = PatientID;
            obj.Description = Description;
            obj.VisitDate = DateTime.Now.ToString("MM/dd/yyyy");
            obj.Insert();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            LabelMessage.Text = "The information is saved succesfully";
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("CurrentVisit.aspx");
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
}