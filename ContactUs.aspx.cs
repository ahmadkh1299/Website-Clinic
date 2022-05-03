using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ContactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RangeValidator1.MaximumValue = int.MaxValue.ToString() ;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string PhoneNumber = DropDownList1.SelectedItem.Text;
            ClassContactUs obj = new ClassContactUs();
            obj.Message = TextBox1.Text;
            obj.PhoneNumber = PhoneNumber + TextBox2.Text;
            obj.Insert();
            Response.Redirect("ContactUs.aspx");
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
}