using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                FillDataList();
            }
            if (Session["ValidUser"] != null && (bool)Session["ValidUser"])
            {
                RenameMenuItem("LogOut");
                RenameMenuItemPh("LogIn Pharmacist");
                if (Session["IsDoctor"] != null && (bool)Session["IsDoctor"])
                {
                    RemoveMenuItem("My History");
                    if (!(bool)Session["IsManger"])
                    {
                        RemoveMenuItemChild("Control", "Pharmacists");
                        RemoveMenuItemChild("Control", "Doctors");
                        RemoveMenuItemChild("Control", "Pharmacy");
                    }
                }
                else if (Session["IsDoctor"] != null && !(bool)Session["IsDoctor"])
                {
                    RemoveMenuItem("Patients History");
                    RemoveMenuItem("Concerns");
                    RemoveMenuItem("Control");
                    RemoveMenuItem("Current Visit");
                }
            }
            else
            {
                if (Session["IsPharmacist"] != null && (bool)(Session["IsPharmacist"]) == true)
                {
                    RemoveMenuItem("Current Visit");          
                    RemoveMenuItem("Concerns");
                    RemoveMenuItemChild("Control", "Doctors");
                    RemoveMenuItemChild("Control", "Patients");
                    RemoveMenuItemChild("Control", "Pharmacists");
                    RenameMenuItemPh("LogOut Pharmacist");
                    RemoveMenuItem("Patients History");
                    RemoveMenuItem("Visits");
                    RemoveMenuItem("My History");
                }
                else
                {
                    RemoveMenuItem("Concerns");
                    RemoveMenuItem("Control");
                    RenameMenuItem("LogIn");
                    RemoveMenuItem("ProFile");
                    RemoveMenuItem("Visits");
                    RemoveMenuItem("Patients History");
                    RenameMenuItemPh("LogIn Pharmacist");
                    RemoveMenuItem("Current Visit");
                    RemoveMenuItem("My History");

                }
            }
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    private void RemoveMenuItemChild(string Parent, string Child)
    {
        try
        {
            MenuItem mi = MenuMain.FindItem(Parent);
            if (mi != null)
            {
                for (int i = 0; i < mi.ChildItems.Count; i++)
                {
                    if (mi.ChildItems[i].Value.Equals(Child))
                    {
                        MenuItem m2 = mi.ChildItems[i];
                        if (m2 != null)
                            mi.ChildItems.Remove(m2);
                        return;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    private void RemoveMenuItem(string Value)
    {
        try
        {
            MenuItem mi = MenuMain.FindItem(Value);
            if (mi != null)
            {
                MenuMain.Items.Remove(mi);
            }
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    private void RenameMenuItem(string strText)
    {
        try
        {
            Menu mainmenu = (Menu)FindControl("MenuMain");
            if (mainmenu != null)
            {
                MenuItem menuToRename = mainmenu.FindItem("LogInOut");
                if (menuToRename != null && menuToRename.Parent == null)
                {
                    menuToRename.Text = strText;
                }
            }
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    private void RenameMenuItemPh(string strText)
    {
        try
        {
            Menu mainmenu = (Menu)FindControl("MenuMain");
            if (mainmenu != null)
            {
                MenuItem menuToRename = mainmenu.FindItem("LogInPh");
                if (menuToRename != null && menuToRename.Parent == null)
                {
                    menuToRename.Text = strText;
                }
            }
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        try
        {
            if (e.Item.Value.Equals("LogInOut"))
            {
                if (e.Item.Text.Equals("LogIn"))
                    Response.Redirect("LogIn.aspx");
                else
                {
                    Session.Abandon();
                    Session["ValidUser"] = false;
                    RenameMenuItem("LogIn");
                    Response.Redirect("OurDoctors.aspx");
                }
            }
            if (e.Item.Value.Equals("Visits"))
            {
                if ((bool)Session["IsDoctor"])
                    Response.Redirect("DAllVisits.aspx");
                else
                    Response.Redirect("PAllVisits.aspx");
            }
            if (e.Item.Value.Equals("Messages"))
            {
                if (Session["ValidUser"]==null || (!(bool)Session["ValidUser"]))
                    Response.Redirect("LogIn.aspx");
                else
                {
                    if ((bool)Session["IsDoctor"])
                        Response.Redirect("DMessages.aspx");
                    else
                        Response.Redirect("PMessages.aspx");
                }
            }
            if (e.Item.Value.Equals("LogInPh"))
            {
                if (e.Item.Text.Equals("LogIn Pharmacist"))
                    Response.Redirect("LogInPh.aspx");
                else
                {
                    Session.Abandon();
                    Session["IsPharmacist"] = false;
                    RenameMenuItemPh("LogIn Pharmacist");
                    Response.Redirect("OurDoctors.aspx");
                }
            }
        }
        catch (Exception ex)
        {
            LabelMsg.Text = ex.Message;
        }
    }
    protected void FillDataList()
    {
        DataTable dt = WebServiceTips.GetAllTips();
        DataListTips.DataSource = dt;
        DataListTips.DataBind();
        dt = WebServiceTips.getTipOfTheDay();
        DataListDailyTip.DataSource = dt;
        DataListDailyTip.DataBind();
    }
}
