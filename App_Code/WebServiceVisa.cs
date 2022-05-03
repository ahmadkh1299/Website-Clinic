using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Services;

/// <summary>
/// Summary description for WebServiceVisa
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceVisa : System.Web.Services.WebService {

    public WebServiceVisa () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public static bool IsValid(string VisaNr, string ValidiationNr, string OwnerID)
    {
        string strSQL = "SELECT * FROM [Accounts] ";
        strSQL += " WHERE [VisaNr]={0} ";
        strSQL += " AND [ValidUntil] >= #{1}#";
        strSQL = string.Format(strSQL, VisaNr, DateTime.Now);
        DataTable dt = Dbase.SelectFromTable(strSQL, "VisaDB.accdb");
        strSQL = "SELECT * FROM [Validation] ";
        strSQL += " WHERE [VisaNr]={0} AND [ValidiationNr]={1} AND [OwnerID]={2} ";
        strSQL = string.Format(strSQL, VisaNr, ValidiationNr, OwnerID);
        DataTable dt1 = Dbase.SelectFromTable(strSQL, "VisaDB.accdb");
        return (dt.Rows.Count > 0 && dt1.Rows.Count > 0);
    }
    [WebMethod]
    public static bool Pay(int Amount, string VisaNrFrom, string VisaNrTo,string ValidiationNr,string OwnerID)
    {
        if (!WebServiceVisa.IsValid(VisaNrFrom,ValidiationNr,OwnerID))
            return false;
        string strSQL = "SELECT Balance FROM Accounts ";
        strSQL += " WHERE VisaNr={0} ";
        strSQL = string.Format(strSQL, VisaNrFrom);
        DataTable dt = Dbase.SelectFromTable(strSQL, "VisaDB.accdb");
        if (int.Parse(dt.Rows[0]["Balance"].ToString()) < Amount)
            return false;
        //
        strSQL = "UPDATE Accounts SET Balance=Balance-{0}  ";
        strSQL += " WHERE VisaNr={1} ";
        strSQL = string.Format(strSQL, Amount, VisaNrFrom);
        Dbase.ChangeTable(strSQL, "VisaDB.accdb");
        //
        strSQL = "UPDATE Accounts SET Balance=Balance+{0}  ";
        strSQL += " WHERE VisaNr={1} ";
        strSQL = string.Format(strSQL, Amount, VisaNrTo);
        Dbase.ChangeTable(strSQL, "VisaDB.accdb");
        return true;
    }

    
}
