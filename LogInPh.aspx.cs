using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class LogInPh : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["ValidUser"] = false;
            Session["IsDoctor"] = false;
            Session["IsManger"] = false;
            Session["DataTable"] = null;
            Session["IsPharmacist"] = false;
            Session["DataTable"] = null;
        }
    }
    protected void ButtonLogIn_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtPh = ClassPharmacists.CheckIfIn(TextBoxUserName.Text, TextBoxPassWord.Text);
            if (dtPh.Rows.Count != 0)
            {
                Session["IsPharmacist"] = true;
                Session["DataTable"] = dtPh;
                Response.Redirect("EditPharmacy.aspx");
            }
        }
        catch(Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
}