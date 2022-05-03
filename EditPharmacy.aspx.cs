using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class EditPharmacy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
                FillGridview();
            ClassImages.DeleteNotUsed();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void FillGridview()
    {
        try
        {
            DataTable dt = ClassPharmacy.getAll();
            GridViewPharmacy.DataSource = dt;
            GridViewPharmacy.DataBind();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = "A problem in getting the information: " + ex.Message;
        }
    }
    protected void GridViewPharmacy_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Label LMedicineID = (Label)GridViewPharmacy.Rows[e.RowIndex].FindControl("LabelMedicineID");
            ClassPharmacy obj = new ClassPharmacy();
            obj.MedicineID = LMedicineID.Text;
            obj.Delete();
            FillGridview();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = "A problem in getting the information: " + ex.Message;
        }
    }
    protected void GridViewPharmacy_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridViewPharmacy.EditIndex = e.NewEditIndex;
            FillGridview();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void GridViewPharmacy_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            GridViewPharmacy.EditIndex = -1;
            FillGridview();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void GridViewPharmacy_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            ClassPharmacy obj = new ClassPharmacy();
            int Index = e.RowIndex;
            Label MedicineID = (Label)GridViewPharmacy.Rows[Index].FindControl("LabelMedicineID");
            TextBox Medicine = (TextBox)GridViewPharmacy.Rows[Index].FindControl("TextBoxMedicine");
            TextBox Number = (TextBox)GridViewPharmacy.Rows[Index].FindControl("TextBoxNumber");
            TextBox Description = (TextBox)GridViewPharmacy.Rows[Index].FindControl("TextBoxDescription");
            TextBox Price = (TextBox)GridViewPharmacy.Rows[Index].FindControl("TextBoxPrice");
            FileUpload PicUpload = (FileUpload)GridViewPharmacy.Rows[Index].FindControl("FileUpload2");
            string strRealPath = Request.PhysicalApplicationPath;
            strRealPath += "Images\\";
            if (PicUpload.HasFile)
            {
                if (!System.IO.Directory.Exists(strRealPath))
                {
                    LabelMsg.Text = "Images directory does not exist";
                }
                else if (PicUpload.PostedFile.ContentLength > 2000000)
                {

                    LabelMsg.Text = "The file size must be <= to 2 MB ";
                }
                string ID = ClassImages.GetID("Images\\" + PicUpload.FileName);
                obj.MedicineID = MedicineID.Text;
                obj.Medicine = Medicine.Text;
                obj.Number = Number.Text;
                obj.Description = Description.Text;
                obj.Price = Price.Text;
                obj.ImageID = ID;
                obj.Update();
                GridViewPharmacy.EditIndex = -1;
                FillGridview();
            }
            else
            {
                obj.MedicineID = MedicineID.Text;
                obj.Medicine = Medicine.Text;
                obj.Number = Number.Text;
                obj.Description = Description.Text;
                obj.Price = Price.Text;
                obj.UpdateWithoutPic();
                GridViewPharmacy.EditIndex = -1;
                FillGridview();
            }
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void GridViewPharmacy_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("Insert"))
            {
                InsertMedicine();
                FillGridview();
            }
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void InsertMedicine()
    {
        try
        {
            string Medicine = ((TextBox)GridViewPharmacy.FooterRow.FindControl("TextBoxNewMedicine")).Text;
            string Number = ((TextBox)GridViewPharmacy.FooterRow.FindControl("TextBoxNewNumber")).Text;
            string Description = ((TextBox)GridViewPharmacy.FooterRow.FindControl("TextBoxNewDescription")).Text;
            string Price = ((TextBox)GridViewPharmacy.FooterRow.FindControl("TextBoxNewPrice")).Text;
            FileUpload PicUpload = (FileUpload)GridViewPharmacy.FooterRow.FindControl("FileUpload1");
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
                        return;
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
            ClassPharmacy obj = new ClassPharmacy();
            string ID = ClassImages.GetID("'" + "Images\\" + PicUpload.FileName + "'");
            obj.Medicine = Medicine;
            obj.Number = Number;
            obj.Price = Price;
            obj.ImageID = ID;
            obj.Description = Description;
            obj.Insert();
            FillGridview();
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
}