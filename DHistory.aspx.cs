using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDataList();
        }
    }
    protected void FillDataList()
    {
        DataTable dt = ClassHistory.GetAll();
        DataListHistory.DataSource = dt;
        DataListHistory.DataBind();
    }
    protected string FormateDate(object obj)
    {
        try
        {
            if (obj is DateTime)
            {
                return ((DateTime)obj).ToString("dd/MM/yyyy");
            }
            return obj.ToString();
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
            return null;
        }
    }
    protected void DataListHistory_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandArgument.Equals("Search"))
        {
            TextBox TextBoxSearch = (TextBox)(e.Item.FindControl("TextBoxSearch"));
            DataTable dt = ClassHistory.GetHistoryByPID(TextBoxSearch.Text);
            FillDataListSearch(dt);
        }
    }
    private void FillDataListSearch(DataTable dt)
    {
        try
        {
            DataListHistory.DataSource = dt;
            ViewState["SearchDL"] = dt;
            DataListHistory.DataBind();
            DataListHistory.RepeatColumns = 1;
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }

}