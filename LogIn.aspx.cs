using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class LogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["IsPharmacist"] = false;
            Session["ValidUser"] = false;
            Session["IsDoctor"] = false;
            Session["IsManger"] = false;
            Session["DataTable"] = null;
        }
    }
    protected void ButtonLogIn_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtP = ClassPatients.GetByIDandPassWord(TextBoxUserName.Text, TextBoxPassWord.Text);
            DataTable dtD = ClassDoctors.CheckIfIn(TextBoxUserName.Text, TextBoxPassWord.Text);
            if (dtD.Rows.Count != 0 || dtP.Rows.Count != 0)
            {
                if (dtD.Rows.Count != 0)
                {
                    Session["IsDoctor"] = true;
                    Session["DataTable"] = dtD;
                    if (dtD.Rows[0]["IsManger"].ToString() == "True")
                        Session["IsManger"] = true;
                }
                else
                    Session["DataTable"] = dtP;
                Session["ValidUser"] = true;
                Response.Redirect("OurDoctors.aspx");
            }
            else
            {
                LabelMsg.Text = "Not autherized to log in!!!!";
                Session["ValidUser"] = false;
            }
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void ButtonCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("LogIN.aspx");
    }
}