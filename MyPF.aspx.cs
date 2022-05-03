using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MyPF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            FillDataList();
    }
    public void FillDataList()
    {
        try
        {
            DataTable dt;
            if (Session["DataTable"] != null)
            {
                if (Session["IsDoctor"] != null)
                {
                    if ((bool)Session["IsDoctor"])
                    {
                        dt = (DataTable)Session["DataTable"];
                        DataListDoctors.DataSource = dt;
                        DataListDoctors.DataBind();

                    }
                    else
                        if (Session["IsPharmacist"] != null && (bool)Session["IsPharmacist"])
                        {
                                dt = (DataTable)Session["DataTable"];
                                DataListPharmacists.DataSource = dt;
                                DataListPharmacists.DataBind();
                        }
                        else
                        {
                            dt = (DataTable)Session["DataTable"];
                            DataListPatients.DataSource = dt;
                            DataListPatients.DataBind();
                        }
                }
            }
        }
        catch (Exception ex)
        {
            LabelMsg.Text = "Problem in getting your information at" + ex.Message;
        }
    }
    protected void DataListPatients_CancelCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            DataListPatients.EditItemIndex = -1;
            FillDataList();
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
            FillDataList();
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
            DataTable dt = ClassPatients.GetByID(PatientID.Text);
            Session["DataTable"] = dt;
            FillDataList();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void DataListDoctors_CancelCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            DataListDoctors.EditItemIndex = -1;
            FillDataList();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void DataListDoctors_EditCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            DataListDoctors.EditItemIndex = e.Item.ItemIndex;
            FillDataList();
        }
        catch (Exception ex) { LabelMsg.Text = ex.Message; }
    }
    protected void DataListDoctors_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            Label LabelLicenseNumber = (Label)(e.Item.FindControl("LabelLicenseNumber1"));
            TextBox TextBoxFName = (TextBox)(e.Item.FindControl("TextBoxFName"));
            TextBox TextBoxLName = (TextBox)(e.Item.FindControl("TextBoxLName"));
            TextBox TextBoxPassWord = (TextBox)(e.Item.FindControl("TextBoxPassWord"));
            TextBox TextBoxSpecialty = (TextBox)(e.Item.FindControl("TextBoxSpecialty"));
            string SID = ClassSpecialties.GetID(TextBoxSpecialty.Text);
            FileUpload PicUpload = (FileUpload)(e.Item.FindControl("PicUpload"));
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
            ClassDoctors obj = new ClassDoctors();
            obj.LicenseNumber = LabelLicenseNumber.Text;
            obj.FName = TextBoxFName.Text;
            obj.LName = TextBoxLName.Text;
            obj.PassWord = TextBoxPassWord.Text;
            obj.SpecialtyID = SID;
            obj.IsManger = Session["IsManger"].ToString();
            obj.ImageSource = "'" + "Images\\" + PicUpload.FileName + "'";
            if (obj.ImageSource != "'Images\\'")
                obj.Update();
            else
                obj.UpdateWithoutPic();
            DataListDoctors.EditItemIndex = -1;
            DataTable dt = ClassDoctors.GetByLN(LabelLicenseNumber.Text);
            Session["DataTable"] = dt;
            FillDataList();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void DataListPharmacists_CancelCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            DataListPharmacists.EditItemIndex = -1;
            FillDataList();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void DataListPharmacists_EditCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            DataListPharmacists.EditItemIndex = e.Item.ItemIndex;
            FillDataList();
        }
        catch (Exception ex) { LabelMsg.Text = ex.Message; }
    }
    protected void DataListPharmacists_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        Label PharmacistID = (Label)(e.Item.FindControl("LabelPharmacistID"));
        TextBox TextboxFName = (TextBox)(e.Item.FindControl("TextboxFName"));
        TextBox TextboxPassWord = (TextBox)(e.Item.FindControl("TextboxPassWord"));
        TextBox TextboxLName = (TextBox)(e.Item.FindControl("TextboxLName"));
        TextBox TextboxUserName = (TextBox)(e.Item.FindControl("TextboxUserName"));
        ClassPharmacists obj = new ClassPharmacists();
        obj.PharmacistID = PharmacistID.Text;
        obj.FName = TextboxFName.Text;
        obj.LName = TextboxLName.Text;
        obj.UserName = TextboxUserName.Text;
        obj.PassWord = TextboxPassWord.Text;
        obj.Update();
        DataListPharmacists.EditItemIndex = -1;
        DataTable dt = ClassPharmacists.GetByID(PharmacistID.Text);
        Session["DataTable"] = dt;
        FillDataList();
    }
}