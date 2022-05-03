using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EditPharmacists : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGridView();
        }
    }
    protected void FillGridView()
    {
        try
        {
            DataTable dt = ClassPharmacists.GetAll();
            GridViewPharmacists.DataSource = dt;
            GridViewPharmacists.DataBind();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void GridViewPharmacists_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridViewPharmacists.PageIndex = e.NewPageIndex;
            FillGridView();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void GridViewPharmacists_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridViewPharmacists.EditIndex = e.NewEditIndex;
            FillGridView();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void GridViewPharmacists_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            GridViewPharmacists.EditIndex = -1;
            FillGridView();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void GridViewPharmacists_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Label LabelPharmacistID = (Label)GridViewPharmacists.Rows[e.RowIndex].FindControl("LabelPharmacistID");
            ClassPharmacists obj = new ClassPharmacists();
            obj.PharmacistID = LabelPharmacistID.Text;
            obj.Delete();
            FillGridView();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void GridViewPharmacists_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int Index = e.RowIndex;
            Label LabelID = (Label)GridViewPharmacists.Rows[Index].FindControl("LabelPharmacistID");
            TextBox TextBoxFName = (TextBox)GridViewPharmacists.Rows[Index].FindControl("TextBoxFName");
            TextBox TextBoxLName = (TextBox)GridViewPharmacists.Rows[Index].FindControl("TextBoxLName");
            TextBox TextBoxPassWord = (TextBox)GridViewPharmacists.Rows[Index].FindControl("TextBoxPassWord");
            TextBox UserName = (TextBox)GridViewPharmacists.Rows[Index].FindControl("TextBoxUserName");
            ClassPharmacists obj = new ClassPharmacists();
            obj.PharmacistID = LabelID.Text;
            obj.FName = TextBoxFName.Text;
            obj.LName = TextBoxLName.Text;
            obj.PassWord = TextBoxPassWord.Text;
            obj.UserName = UserName.Text;
            obj.Update();
            GridViewPharmacists.EditIndex = -1;
            FillGridView();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void GridViewPharmacists_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
            if (e.CommandName.Equals("Insert"))
            {
                InsertPharmacist();
                FillGridView();
            }
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void InsertPharmacist()
    {
        try
        {
            TextBox TextBoxFName = (TextBox)GridViewPharmacists.FooterRow.FindControl("TextBoxNewFName");
            TextBox TextBoxLName = (TextBox)GridViewPharmacists.FooterRow.FindControl("TextBoxNewLName");
            TextBox TextBoxPassWord = (TextBox)GridViewPharmacists.FooterRow.FindControl("TextBoxNewPassWord");
            TextBox UserName = (TextBox)GridViewPharmacists.FooterRow.FindControl("TextBoxNewUserName");
            ClassPharmacists obj = new ClassPharmacists();
            obj.FName = TextBoxFName.Text;
            obj.LName = TextBoxLName.Text;
            obj.PassWord = TextBoxPassWord.Text;
            obj.UserName = UserName.Text;
            obj.Insert();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
}