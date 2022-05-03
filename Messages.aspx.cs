using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Messages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            FillDataList();
    }
    protected void FillDataList()
    {
        try
        {
            DataTable dt = ClassContactUs.GetAll();
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        ClassContactUs obj = new ClassContactUs();
        Label PhoneNumber = (Label)(e.Item.FindControl("LabelPhoneNumber"));
        TextBox Message = (TextBox)(e.Item.FindControl("TextBox1"));
        obj.PhoneNumber = PhoneNumber.Text;
        obj.Message = Message.Text;
        obj.Delete();
        FillDataList();
    }
}