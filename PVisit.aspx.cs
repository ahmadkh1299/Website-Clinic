using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PVisit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["ValidUser"] == null || !(bool)Session["ValidUser"])
            {
                Response.Redirect("LogIn.aspx");
            }
            ClassSpecialties.DeleteNotUsed();
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
        if (!IsPostBack)
        {
            try
            {
                ViewState["LicenseNumber"] = null;
                FillDDLSpecialties();
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            FillDDLTimes(Calendar1.SelectedDate.Date.DayOfWeek.ToString(), Calendar1.SelectedDate.Date.ToString("MM/dd/yyyy"));
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    private void FillDDLTimes(string Day, string Date)
    {
        try
        {
            DropDownListTimes.Items.Clear();
            DropDownListTimes.Items.Add("Select your Time");
            string[] A = ClassTimes.GetAllByLNandDay(ViewState["LicenseNumber"].ToString(), Day);
            string[] B = ClassVisits.getVisitByLNAndDate(ViewState["LicenseNumber"].ToString(), Date);
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                    if (A[i] == B[j])
                        A[i] = "0";
            }
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != "0")
                    DropDownListTimes.Items.Add(A[i]);
            }
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        try
        {
            if (ViewState["LicenseNumber"] == null)
                e.Day.IsSelectable = false;
            else
                e.Day.IsSelectable = ClassTimes.IsDoctorWorking(ViewState["LicenseNumber"].ToString(), e.Day.Date.DayOfWeek.ToString());
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    private void FillDDLDoctors(string specialty)
    {
        try
        {
            DataTable dt = ClassDoctors.GetBySpecialty(specialty);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem l = new ListItem(dt.Rows[i]["FName"].ToString(), dt.Rows[i]["LicenseNumber"].ToString());
                DropDownListDoctors.Items.Add(l);
            }
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    private void FillDDLSpecialties()
    {
        try
        {
            ClassSpecialties c = new ClassSpecialties();
            DataTable dt = c.GetIDsANDSpecialties();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListItem l = new ListItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
                DropDownListSpecialty.Items.Add(l);
            }
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    protected void DropDownListSpecialty_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DropDownListSpecialty.SelectedItem.Text == "Select a Specialty")
            {
                DropDownListDoctors.Items.Clear();
                DropDownListDoctors.Items.Add("Select a Doctor");
                return;
            }
            DropDownListDoctors.Items.Clear();
            DropDownListDoctors.Items.Add("Select a Doctor");
            FillDDLDoctors(DropDownListSpecialty.SelectedValue.ToString());
        }
        catch (Exception ex)
        { LabelMessage.Text = ex.Message; }
    }
    protected void DropDownListDoctors_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["LicenseNumber"] = DropDownListDoctors.SelectedItem.Value;
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    protected void DropDownListTimes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DropDownListTimes.SelectedItem.Text != "Select your Time")
            {
                string Visit = "Set the appointment at ";
                Visit += Calendar1.SelectedDate.Date.ToString("dd/MM/yyyy");
                Visit += " at the time ";
                Visit += DropDownListTimes.SelectedItem.Text;
                LinkButtonSet.Text = Visit;
            }
            else
                LabelMessage.Text = "Select a time to proced";
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
    protected void LinkButtonSet_Click(object sender, EventArgs e)
    {
        try
        {
            ClassVisits Obj = new ClassVisits();
            Obj.LicenseNumber = ViewState["LicenseNumber"].ToString();
            Obj.PatientID = ((DataTable)Session["DataTable"]).Rows[0]["PatientID"].ToString();
            Obj.Time = DropDownListTimes.SelectedItem.ToString();
            Obj.VisitDate = Calendar1.SelectedDate.ToString("MM/dd/yyyy");
            Obj.Insert();
            LabelSucces.Text = "You have set the appointment";
        }
        catch (Exception ex)
        {
            LabelMessage.Text = ex.Message;
        }
    }
}