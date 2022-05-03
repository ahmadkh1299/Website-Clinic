using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ClassTimes
/// </summary>
public class ClassTimes
{
    string timeID, licenseNumber, day, start, end;

    public ClassTimes()
    {
    }
    public string TimeID
    {
        get { return timeID; }
        set { timeID = value; }
    }
    public string LicenseNumber
    {
        get { return licenseNumber; }
        set { licenseNumber = value; }
    }
    public string Day
    {
        get { return day; }
        set { day = value; }
    }
    public string Start
    {
        get { return start; }
        set { start = value; }
    }
    public string End
    {
        get { return end; }
        set { end = value; }
    }
    public DataTable GetAll()
    {
        string strSQL = "SELECT * FROM [Times]";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public DataTable GetAllByDay(string Day)
    {
        string strSQL = "SELECT * FROM [Times] WHERE [Day]='" + Day + "'";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public void Insert()
    {
        string strSQL = "INSERT INTO [Times] ";
        strSQL += "([LicenseNumber],[Day],[Start],[End]) ";
        strSQL += "VALUES ({0}, {1},#{2}#,#{3}#)";
        strSQL = string.Format(strSQL, this.LicenseNumber, this.Day, this.Start, this.End);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Update()
    {
        string strSQL = "UPDATE [Times] SET";
        strSQL += "[LicenseNumber]={0}, ";
        strSQL += "[Day]={1}, ";
        strSQL += "[Start]=#{2}#, ";
        strSQL += "[End]=#{3}# ";
        strSQL += "WHERE [TimeID]={4}";
        strSQL = string.Format(strSQL, this.LicenseNumber, this.Day, this.Start, this.End);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Delete()
    {
        string strSQL = "DELETE * FROM [Times] ";
        strSQL += "WHERE [TimeID]={0}";
        strSQL = string.Format(strSQL, this.TimeID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static string[] GetAllByLNandDay(string LicenseNumber, string Day)
    {
        string strSQL = "SELECT [Start], [End] FROM [Times] WHERE [Day]='{0}' AND [LicenseNumber]={1} ";
        strSQL = string.Format(strSQL, Day, LicenseNumber);
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        string[] A;
        int Num = 0;
        Double P = 0;
        string Start = dt.Rows[0]["Start"].ToString();
        string End = dt.Rows[0]["End"].ToString();
        double S = ToNums(Start);
        double E = ToNums(End);
        Num = (int)((E - S) * 2) + 1;
        P = S;
        A = new string[Num];
        for (int i = 0; i < Num; i++)
        {
            A[i] = ToHours(P);
            P += 0.5;
        }
        return A;
    }
    public static DataTable GetWorkingDays(string LicenseNumber)
    {
        string strSQL = "SELECT [Day] FROM [Times] WHERE [LicenseNumber]=" + LicenseNumber + "";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public static bool IsDoctorWorking(string LicenseNumber, string Day)
    {
        string strSQL = "SELECT * FROM [Times] WHERE [LicenseNumber]={0} AND [Day]='{1}' ";
        strSQL = string.Format(strSQL, LicenseNumber, Day);
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        if (dt.Rows.Count > 0)
            return true;
        return false;
    }
    static double ToNums(string S)
    {
        double x;
        if (S.Substring(3, 2) == "30")
            x = double.Parse(S.Substring(0, 2)) + 0.5;
        else
            x = double.Parse(S.Substring(0, 2));
        return x;
    }
    static string ToHours(double X)
    {
        if (X > 0 && X < 10)
        {
            if ((X * 10) % 10 == 5)
                return "0" + (X - 0.5) + ":30";
            else
                return "0" + X + ":00";
        }
        if (X > 9)
        {
            if ((X * 10) % 10 == 5)
                return (X - 0.5) + ":30";
            else
                return X + ":00";
        }
        return "00:00";
    }
}