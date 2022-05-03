using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                RangeValidator1.MaximumValue = DateTime.Now.ToString("MM/dd/yyyy");
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
            DataTable dt = ClassHistory.GetHistoryByPID(((DataTable)(Session["DataTable"])).Rows[0]["PatientID"].ToString());
            DataListHistory.DataSource = dt;
            DataListHistory.DataBind();
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
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
    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string ID = ((DataTable)(Session["DataTable"])).Rows[0]["PatientID"].ToString();
            string Date = TextBoxSearch.Text;
            string day = Date.Substring(0, 2);
            string Month = Date.Substring(3, 2);
            string year = Date.Substring(6);
            Date = Month + "/" + day + "/" + year;
            DataTable dt = ClassHistory.GetHistoryByPIDAndDate(ID, Date);
            DataListHistory.DataSource = dt;
            DataListHistory.DataBind();
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("PHistory.aspx");
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
}
