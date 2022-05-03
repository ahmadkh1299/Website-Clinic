using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Patients : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ValidUser"] == null || !(bool)Session["ValidUser"])
            {
                Response.Redirect("LogIn.aspx");
            }
            if (!IsPostBack)
            {
                FillDataList("FName", "ASC");
            }

        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }

    private void FillDataList(string strName, string order)
    {
        try
        {
            DataTable dt = ClassPatients.GetAll(strName, order);
            DataListPatients.DataSource = dt;
            DataListPatients.DataBind();
            DataListPatients.RepeatColumns = 3;
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    private void FillDataListSearch(DataTable dt)
    {
        try
        {
            DataListPatients.DataSource = dt;
            ViewState["SearchDL"] = dt;
            DataListPatients.DataBind();
            DataListPatients.RepeatColumns = 1;
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void DataListPatients_CancelCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            DataListPatients.EditItemIndex = -1;
            FillDataList("FName", "ASC");
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void DataListPatients_DeleteCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            int Index = e.Item.ItemIndex;
            Label LabelPatientID = (Label)(e.Item.FindControl("LabelPatientID"));
            ClassPatients obj = new ClassPatients();
            obj.PatientID = LabelPatientID.Text;
            obj.Delete();
            FillDataList("FName", "ASC");
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void DataListPatients_EditCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            DataListPatients.EditItemIndex = e.Item.ItemIndex;
            if (ViewState["SearchDL"] == null)
                FillDataList("FName", "ASC");
            else
                FillDataListSearch((DataTable)ViewState["SearchDL"]);
        }
        catch (Exception ex) { LabelMsg.Text = ex.Message; }
    }
    protected void DataListPatients_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            int Index = e.Item.ItemIndex;
            Label PatientID = (Label)(e.Item.FindControl("LabelPatientID"));
            TextBox TextboxFName = (TextBox)(e.Item.FindControl("TextboxFName"));
            TextBox TextboxPassWord = (TextBox)(e.Item.FindControl("TextboxPassWord"));
            TextBox TextboxLName = (TextBox)(e.Item.FindControl("TextboxLName"));
            TextBox TextboxEmail = (TextBox)(e.Item.FindControl("TextboxEmail"));
            TextBox TextboxDOB = (TextBox)(e.Item.FindControl("TextboxDOB"));
            ClassPatients obj = new ClassPatients();
            obj.PatientID = PatientID.Text;
            obj.FName = TextboxFName.Text;
            obj.LName = TextboxLName.Text;
            obj.PassWord = TextboxPassWord.Text;
            obj.Email = TextboxEmail.Text;
            obj.DOB = TextboxDOB.Text;
            obj.Update();
            DataListPatients.EditItemIndex = -1;
            if (ViewState["SearchDL"] == null)
                FillDataList("FName", "ASC");
            else
            {
                ViewState["SearchDL"] = ClassPatients.GetByID(obj.PatientID);
                FillDataListSearch((DataTable)ViewState["SearchDL"]);
            }
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void DataListPatients_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            CheckBox chexkboxorder = (CheckBox)(e.Item.FindControl("ChBOrder"));
            string order;
            if (chexkboxorder != null && chexkboxorder.Checked)
            {
                order = "ASC";
                ViewState["ChBOrder"] = true;
            }
            else
            {
                order = "DESC";
                ViewState["ChBOrder"] = false;
            }

            if (e.CommandName.Equals("Insert"))
            {
                AddNewPatient();
            }
            else if (e.CommandName.Equals("Sort"))
                FillDataList(e.CommandArgument.ToString(), order);
            else if (e.CommandName.Equals("Search"))
            {
                TextBox TextBoxSearch = (TextBox)(e.Item.FindControl("TextBoxSearch"));
                DataTable dt = ClassPatients.GetByID(TextBoxSearch.Text);
                FillDataListSearch(dt);
            }
        }

        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void AddNewPatient()
    {
        try
        {
            int FooterIndex = DataListPatients.Controls.Count - 1;
            Control Footer = DataListPatients.Controls[FooterIndex];
            TextBox TextboxFName = (TextBox)(Footer.FindControl("TextboxNewFName"));
            TextBox TextboxLName = (TextBox)(Footer.FindControl("TextboxNewLName"));
            TextBox TextboxPatientID = (TextBox)(Footer.FindControl("TextboxPatientID"));
            TextBox TextboxPassword = (TextBox)(Footer.FindControl("TextboxNewPassword"));
            TextBox TextboxEmail = (TextBox)(Footer.FindControl("TextboxNewEmail"));
            TextBox TextboxDOB = (TextBox)(Footer.FindControl("TextboxNewDOB"));
            ClassPatients obj = new ClassPatients();
            obj.FName = TextboxFName.Text;
            obj.LName = TextboxLName.Text;
            obj.PassWord = TextboxPassword.Text;
            obj.PatientID = TextboxPatientID.Text;
            obj.DOB = TextboxDOB.Text;
            obj.Email = TextboxEmail.Text;
            obj.Insert();
            FillDataList("FName", "ASC");
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void DataListPatients_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}