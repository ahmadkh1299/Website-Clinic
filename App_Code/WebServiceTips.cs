using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

/// <summary>
/// Summary description for WebServiceTips
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceTips : System.Web.Services.WebService {

    public WebServiceTips () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public static DataTable getTipOfTheDay()
    {
        string StrSQL = "SELECT * FROM [Tips]";
        DataTable dt = Dbase.SelectFromTable(StrSQL, "DailyTips.accdb");
        int x = dt.Rows.Count;
        Random R = new Random();
        x = R.Next(0, x);
        string TipID = dt.Rows[x]["TipID"].ToString();
        StrSQL = "SELECT * FROM [Tips] WHERE [TipID]=" + TipID;
        dt = Dbase.SelectFromTable(StrSQL, "DailyTips.accdb");
        dt.TableName = "Tip of the day";
        return dt;
    }
    [WebMethod]
    public static DataTable GetAllTips()
    {
        string StrSQL = "SELECT * FROM [Tips]";
        DataTable dt = Dbase.SelectFromTable(StrSQL, "DailyTips.accdb");
        return dt;
    }
}
