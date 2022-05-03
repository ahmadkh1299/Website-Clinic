using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MyCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ValidUser"] == null || !(bool)Session["ValidUser"])
            {
                Response.Redirect("LogIn.aspx");
            }
            else
            {
                if ((bool)Session["IsDoctor"])
                {
                    LabelMessage.Text = "You Dont Have a Cart Please LogIn as Patient";
                    LinkButton1.Visible = true;
                    return;
                }
            }

            if (!IsPostBack)
            {
                ClassCart.DeleteNotAvalibe(((DataTable)Session["DataTable"]).Rows[0]["PatientID"].ToString());
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
            DataTable dt = ClassCart.GetAll(PatientID);
            DataListCart.DataSource = dt;
            DataListCart.DataBind();
            Label5.Text = payment(PatientID).ToString() + " ILS";
        }

        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    protected int payment(string PatientID)
    {
        try
        {
            int cnt = 0, x, c;
            DataTable dt = ClassCart.GetAll(PatientID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x = Convert.ToInt32(dt.Rows[i]["Price"]);
                c = Convert.ToInt32(dt.Rows[i]["Number"]);
                cnt += (x * c);
            }
            Session["Payment"] = cnt;
            return cnt;
        }

        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
            return 0;
        }
    }
    protected void DataListCart_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            string PatientID = ((DataTable)Session["DataTable"]).Rows[0]["PatientID"].ToString();
            Label Item = (Label)(e.Item.FindControl("LabelItem"));
            ClassCart.Delete(Item.Text, PatientID);
            Response.Redirect("MyCart.aspx");
        }

        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    protected void ButtonBuy_Click(object sender, EventArgs e)
    {
        Response.Redirect("Pay.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Session["ValidUser"] = false;
            Session["IsDoctor"] = false;
            Session["IsManger"] = false;
            Session["DataTable"] = null;
            Response.Redirect("LogIn.aspx");
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
}