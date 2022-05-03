using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Visits
/// </summary>
public class ClassVisits
{
    private string visitID, licenseNumber, patientID, time, visitDate;
    public ClassVisits()
    {
    }
    public string VisitID
    {
        get { return visitID; }
        set { visitID = value; }
    }
    public string LicenseNumber
    {
        get { return licenseNumber; }
        set { licenseNumber = value; }
    }
    public string PatientID
    {
        get { return patientID; }
        set { patientID = value; }
    }
    public string Time
    {
        get { return time; }
        set { time = value; }
    }
    public string VisitDate
    {
        get { return visitDate; }
        set { visitDate = value; }
    }
    public DataTable GetAll()
    {
        string strSQL = "SELECT * FROM [Visits]";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public void Insert()
    {
        string strSQL = "INSERT INTO [Visits] ";
        strSQL += "([LicenseNumber],[PatientID],[Time],[VisitDate]) ";
        strSQL += "VALUES ({0}, {1},'{2}',#{3}#)";
        strSQL = string.Format(strSQL, this.LicenseNumber, this.PatientID, this.Time, this.VisitDate);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Update()
    {
        string strSQL = "UPDATE [Visits] SET";
        strSQL += "[LicenseNumber]={0}, ";
        strSQL += "[PatientID]={1}, ";
        strSQL += "[Time]=#{2}#, ";
        strSQL += "[VisitDate]=#{3}# ";
        strSQL += "WHERE [VisitID]={4}";
        strSQL = string.Format(strSQL, this.LicenseNumber, this.PatientID, this.Time, this.visitDate,this.VisitID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Delete()
    {
        string strSQL = "DELETE * FROM [Visits] ";
        strSQL += "WHERE [VisitID]={0}";
        strSQL = string.Format(strSQL, this.VisitID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static void DeleteWithoutID(string Date, string Time, string PatientID)
    {
        string strSQL = "DELETE * FROM [Visits] WHERE ";
        strSQL += "PatientID={0} AND Time ='{1}' AND VisitDate=#{2}#";
        strSQL = string.Format(strSQL, PatientID, Time, Date);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static int getNumVisitsByLNAndDate(string LicenseNum,string Date)
    {
        string strSQL = "SELECT * FROM [Visits] WHERE [LicenseNumber]={0} AND [VisitDate]=#{1}# ";
        strSQL = string.Format(strSQL, LicenseNum, Date);
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt.Rows.Count;
    }
    public static string[] getVisitByLNAndDate(string LicenseNum, string Date)
    {
        string strSQL = "SELECT [Time] FROM [Visits] WHERE [LicenseNumber]={0} AND [VisitDate]=#{1}# ";
        strSQL = string.Format(strSQL, LicenseNum, Date);
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        string[] A = new string[dt.Rows.Count];
        for (int i = 0; i < A.Length; i++)
        {
            A[i] = dt.Rows[i]["Time"].ToString();
        }
        return A;
    }
    public static DataTable GetVisitsByLN(string LicenseNum)
    {
        string strSQL="SELECT Visits.PatientID, Patients.FName, Patients.LName, Visits.VisitDate, Visits.Time ";
        strSQL += "FROM Patients INNER JOIN Visits ON Patients.PatientID = Visits.PatientID ";
        strSQL += "WHERE [LicenseNumber]=" + LicenseNum + "";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public static DataTable GetVisitsByPID(string PatientID)
    {
        string strSQL = "SELECT Doctors.FName, Doctors.LName, Visits.VisitDate, Visits.Time, Specialties.Specialty ";
        strSQL += "FROM Specialties INNER JOIN (Doctors INNER JOIN Visits ON Doctors.LicenseNumber = Visits.LicenseNumber) ";
        strSQL += "ON Specialties.SpecialtyID =  Doctors.SpecialtyID WHERE PatientID={0}";
        strSQL = string.Format(strSQL, PatientID);
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public static void DeleteDone()
    {
        string strSQL = "DELETE * FROM [Visits] ";
        strSQL += " WHERE [VisitDate] < #{0}#";
        strSQL = string.Format(strSQL, DateTime.Now.ToString("MM/dd/yyyy"));
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
}