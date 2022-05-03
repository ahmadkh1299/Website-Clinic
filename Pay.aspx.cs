using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ButtonPay_Click(object sender, EventArgs e)
    {
        try
        {
            string VisaNumber = TextBoxVisaNr.Text;
            string Validation = TextBoxValidiationNr.Text;
            string ID = TextBoxID.Text;
            int amount = (int)(Session["Payment"]);
            if (WebServiceVisa.Pay(amount, VisaNumber, "1", Validation, ID))
            {
                string PatientID = ((DataTable)Session["DataTable"]).Rows[0]["PatientID"].ToString();
                ClassCart.Clear(PatientID);
                TextBoxVisaNr.Text = "";
                TextBoxValidiationNr.Text = "";
                TextBoxID.Text = "";
                LabelMessage.Text = "You have Completed your Payment";
            }
            else
            {
                LabelMessage.Text = "Your Information in InValid";
            }
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MyCart.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("MyCart.aspx");
    }
}