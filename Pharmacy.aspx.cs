using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pharmacy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ValidUser"] == null || !(bool)Session["ValidUser"])
                Response.Redirect("LogIn.aspx");
            if ((bool)Session["ValidUser"] && (bool)Session["IsDoctor"])
                Response.Redirect("LogIn.aspx");
            if (!IsPostBack)
            {
                ClassPharmacy.DeleteEnded();
                FillDataList();
            }
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void FillDataList()
    {
        try
        {
            DataTable dt = ClassPharmacy.getAll();
            DataListPharmacy.DataSource = dt;
            DataListPharmacy.DataBind();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void DataListPharmacy_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Add to cart"))
            {
                string num = ((TextBox)(e.Item.FindControl("TextBox1"))).Text;
                string Item = ((Label)(e.Item.FindControl("LabelMedicine"))).Text;
                string Price = ((Label)(e.Item.FindControl("LabelPrice"))).Text;
                string PatientID = ((DataTable)Session["DataTable"]).Rows[0]["PatientID"].ToString();
                if (ClassPharmacy.Enough(Convert.ToInt32(num), Item))
                {
                    ClassCart Obj = new ClassCart();
                    Obj.Item = Item;
                    Obj.Number = num;
                    Obj.Price = Price;
                    Obj.PatientID = PatientID;
                    Obj.Insert();
                    Response.Redirect("Pharmacy.aspx");

                }
                else
                    LabelMsg.Text = "There is not enough Products of what you wanted";
            }
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
}