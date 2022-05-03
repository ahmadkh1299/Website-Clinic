using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EditDoctors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                FillGridViewDoctors();
            }
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    private void FillGridViewDoctors()
    {
        try
        {
            DataTable dt = ClassDoctors.GetAlls();
            GridViewDoctors.DataSource = dt;
            GVDataSource = dt;
            GridViewDoctors.DataBind();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = "A problem in getting the information: " + ex.Message;
        }
    }
    public DataTable GVDataSource
    {
        get
        {
            if (ViewState["GVDataSource"] == null)
                ViewState["GVDataSource"] = null; //GridViewUsers.DataSource as DataTable;
            return ViewState["GVDataSource"] as DataTable;
        }
        set
        {
            ViewState["GVDataSource"] = value;
        }

    }
    protected void GridViewDoctors_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridViewDoctors.PageIndex = e.NewPageIndex;
            FillGridViewDoctors();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void GridViewDoctors_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            GridViewDoctors.EditIndex = -1;
            FillGridViewDoctors();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void GridViewDoctors_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
            if (e.CommandName.Equals("Insert"))
            {
                 InsertDoctor();
                FillGridViewDoctors();
            }
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }

    }
    private void InsertDoctor()
    {

        {
            try
            {
                TextBox TextBoxLicenseNumber = (TextBox)GridViewDoctors.FooterRow.FindControl("TextBoxNewLicenseNumber");
                TextBox TextBoxFName = (TextBox)GridViewDoctors.FooterRow.FindControl("TextBoxNewFName");
                TextBox TextBoxLName = (TextBox)GridViewDoctors.FooterRow.FindControl("TextBoxNewLName");
                TextBox TextBoxSpecialty = (TextBox)GridViewDoctors.FooterRow.FindControl("TextBoxNewSpecialty");
                TextBox TextBoxPassword = (TextBox)GridViewDoctors.FooterRow.FindControl("TextBoxNewPassWord");
                CheckBox CheckBoxIsManger = (CheckBox)GridViewDoctors.FooterRow.FindControl("CheckBoxNewIsManger");
                FileUpload PicUpload = (FileUpload)GridViewDoctors.FooterRow.FindControl("FileUpload1");
                string strRealPath = Request.PhysicalApplicationPath;
                strRealPath += "Images\\";
                if (PicUpload.HasFile)
                {
                    if (!System.IO.Directory.Exists(strRealPath))
                    {
                        LabelMsg.Text = "Images directory does not exist";
                    }
                    else if (PicUpload.PostedFile.ContentLength < 2000000)
                    {
                        if (System.IO.File.Exists(strRealPath + PicUpload.FileName))
                        {
                            LabelMsg.Text = "A file with this name already exists";
                        }
                        else
                        {
                            PicUpload.SaveAs(strRealPath + PicUpload.FileName);
                        }
                    }
                    else
                    {
                        LabelMsg.Text = "The file size must be <= to 2 MB ";
                    }
                }
                else
                    LabelMsg.Text = "Please Select a pic first";
                ClassDoctors obj = new ClassDoctors();
                string ID = ClassSpecialties.GetID(TextBoxSpecialty.Text);
                obj.LicenseNumber = TextBoxLicenseNumber.Text;
                obj.FName = TextBoxFName.Text;
                obj.LName = TextBoxLName.Text;
                obj.PassWord = TextBoxPassword.Text;
                obj.SpecialtyID = ID;
                obj.IsManger = CheckBoxIsManger.Checked.ToString();
                obj.ImageSource = "'" + "Images\\" + PicUpload.FileName + "'";
                obj.Insert();
                FillGridViewDoctors();
            }
            catch (Exception ex)
            {
                LabelMsg.Text = ex.Message;
            }

        }
    }
    protected void GridViewDoctors_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridViewDoctors.EditIndex = e.NewEditIndex;
            FillGridViewDoctors();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void GridViewDoctors_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Label LabelLicenseNumber = (Label)GridViewDoctors.Rows[e.RowIndex].FindControl("LabelLicenseNumber");
            ClassDoctors obj = new ClassDoctors();
            obj.LicenseNumber = LabelLicenseNumber.Text;
            obj.Delete();
            FillGridViewDoctors();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void GridViewDoctors_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int Index = e.RowIndex;
            Label LabelLicenseNumber = (Label)GridViewDoctors.Rows[Index].FindControl("LabelLicenseNumber");
            TextBox TextBoxFName = (TextBox)GridViewDoctors.Rows[Index].FindControl("TextBoxFName");
            TextBox TextBoxLName = (TextBox)GridViewDoctors.Rows[Index].FindControl("TextBoxLName");
            TextBox TextBoxSpecialty = (TextBox)GridViewDoctors.Rows[Index].FindControl("TextBoxSpecialty");
            string SpecialtyID = ClassSpecialties.GetID(TextBoxSpecialty.Text);
            TextBox TextBoxPassWord = (TextBox)GridViewDoctors.Rows[Index].FindControl("TextBoxPassWord");
            CheckBox CheckBoxIsManger = (CheckBox)GridViewDoctors.Rows[Index].FindControl("CheckBoxEditIsManger");
            ClassDoctors obj = new ClassDoctors();
            obj.LicenseNumber = LabelLicenseNumber.Text;
            obj.FName = TextBoxFName.Text;
            obj.LName = TextBoxLName.Text;
            obj.SpecialtyID = SpecialtyID;
            obj.PassWord = TextBoxPassWord.Text;
            obj.IsManger = CheckBoxIsManger.Checked.ToString();
            obj.UpdateWithoutPic();
            GridViewDoctors.EditIndex = -1;
            FillGridViewDoctors();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = "Problem In Updating" + ex.Message;
        }
    }
    protected void GridViewDoctors_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}