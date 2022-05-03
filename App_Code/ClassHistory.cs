using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ClassHistory
/// </summary>
public class ClassHistory
{
    private string visitID, licenseNumber, patientID, description, visitDate;
    public ClassHistory()
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
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    public string VisitDate
    {
        get { return visitDate; }
        set { visitDate = value; }
    }
    public void Insert()
    {
        string strSQL = "INSERT INTO [History] ";
        strSQL += "([LicenseNumber],[PatientID],[Description],[VisitDate]) ";
        strSQL += "VALUES ({0}, {1},'{2}',#{3}#)";
        strSQL = string.Format(strSQL, this.LicenseNumber, this.PatientID, this.Description, this.VisitDate);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Update()
    {
        string strSQL = "UPDATE [History] SET";
        strSQL += "[LicenseNumber]={0}, ";
        strSQL += "[PatientID]={1}, ";
        strSQL += "[Description]=#{2}#, ";
        strSQL += "[VisitDate]=#{3}# ";
        strSQL += "WHERE [VisitID]={4}";
        strSQL = string.Format(strSQL, this.LicenseNumber, this.PatientID, this.Description, this.visitDate, this.VisitID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Delete()
    {
        string strSQL = "DELETE * FROM [History] ";
        strSQL += "WHERE [VisitID]={0}";
        strSQL = string.Format(strSQL, this.VisitID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static DataTable GetHistoryByPID(string PatientID)
    {
        string strSQL = "SELECT History.PatientID, History.LicenseNumber, Patients.FName AS [PFName], Patients.LName AS [PLName], Doctors.FName AS [DFName], Doctors.LName AS [DLName], History.VisitDate, History.Description, Specialties.Specialty ";
        strSQL += "FROM Specialties INNER JOIN (Patients INNER JOIN (Doctors INNER JOIN History ON Doctors.LicenseNumber = History.LicenseNumber) ON Patients.PatientID = History.PatientID) ";
        strSQL += " ON Specialties.SpecialtyID = Doctors.SpecialtyID WHERE History.[PatientID]={0}";
        strSQL = string.Format(strSQL, PatientID);
        return Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
    }
    public static DataTable GetHistoryByPIDAndDate(string PatientID,string Date)
    {
        string strSQL = "SELECT History.PatientID, History.LicenseNumber, Patients.FName AS [PFName], Patients.LName AS [PLName], Doctors.FName AS [DFName], Doctors.LName AS [DLName], History.VisitDate, History.Description, Specialties.Specialty ";
        strSQL += "FROM Specialties INNER JOIN (Patients INNER JOIN (Doctors INNER JOIN History ON Doctors.LicenseNumber = History.LicenseNumber) ON Patients.PatientID = History.PatientID) ";
        strSQL += " ON Specialties.SpecialtyID = Doctors.SpecialtyID WHERE History.[PatientID]={0} AND [VisitDate]=#{1}#";
        strSQL = string.Format(strSQL, PatientID,Date);
        return Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
    }

    public static DataTable GetVisitsByLN(string LicenseNum)
    {
        string strSQL = "SELECT History.PatientID, History.LicenseNumber, Patients.FName AS [PFName], Patients.LName AS [PLName], Doctors.FName AS [DFName], Doctors.LName AS [DLName], History.VisitDate, History.Description, Specialties.Specialty ";
        strSQL += "FROM Specialties INNER JOIN (Patients INNER JOIN (Doctors INNER JOIN History ON Doctors.LicenseNumber = History.LicenseNumber) ON Patients.PatientID = History.PatientID) ";
        strSQL += " ON Specialties.SpecialtyID = Doctors.SpecialtyID WHERE History.[LicenseNumber]={0}";
        strSQL = string.Format(strSQL, LicenseNum);
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public static DataTable GetAll()
    {
        string strSQL = "SELECT History.PatientID, History.LicenseNumber, Patients.FName AS [PFName], Patients.LName AS [PLName], Doctors.FName AS [DFName], Doctors.LName AS [DLName], History.VisitDate, History.Description, Specialties.Specialty ";
        strSQL += "FROM Specialties INNER JOIN (Patients INNER JOIN (Doctors INNER JOIN History ON Doctors.LicenseNumber = History.LicenseNumber) ON Patients.PatientID = History.PatientID) ";
        strSQL += " ON Specialties.SpecialtyID = Doctors.SpecialtyID ";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }

}