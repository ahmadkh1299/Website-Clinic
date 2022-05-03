 using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OurDoctors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ClassSpecialties.DeleteNotUsed();
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
        if (!IsPostBack)
            try
            {
                FillDDLSpecialties();
                FillDataList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
    }
    private void FillDDLSpecialties()
    {
        ClassSpecialties c = new ClassSpecialties();
        DataTable dt = c.GetIDsANDSpecialties();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ListItem l = new ListItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
            DropDownListSpecialty.Items.Add(l);
        }
    }
    private void FillDataList()
    {
        try
        {
            if (DropDownListSpecialty.SelectedItem.Value == "All")
            {
                ClassDoctors obj = new ClassDoctors();
                DataTable dt = obj.GetAll();
                DataListDoctors.DataSource = dt;
                GVDataSource = dt;
                DataListDoctors.DataBind();
                DataListDoctors.RepeatColumns = 3;
            }
            else
            {
                string strSpecialtyID = DropDownListSpecialty.SelectedItem.Value;
                DataTable dt1 = ClassDoctors.GetBySpecialty(strSpecialtyID);
                DataListDoctors.DataSource = dt1;
                GVDataSource = dt1;
                DataListDoctors.DataBind();
                DataListDoctors.RepeatColumns = 1;
            }
 
         }
        catch (Exception ex)
        {
            LabelMessage.Text = "Error in  UsersEditorWithGV:FillGrid():" + ex.Message;
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
    protected void DropDownListSpecialty_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDataList();
    }
}