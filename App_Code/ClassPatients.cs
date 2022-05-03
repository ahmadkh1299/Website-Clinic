using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ClassPatients
/// </summary>
public class ClassPatients
{
    private string patientID, fName, lName, passWord,dOB,email;
	public ClassPatients()
	{
	}
    public string PatientID
    {
        get { return patientID; }
        set { patientID = value; }
    }
    public string FName
    {
        get { return fName; }
        set { fName = value; }
    }
    public string LName
    {
        get { return lName; }
        set { lName = value; }
    }
    public string PassWord
    {
        get { return passWord; }
        set { passWord = value; }
    }
    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    public string DOB
    {
        get { return dOB; }
        set { dOB = value; }
    }
    public void Update()
    {
        string strSQL = "UPDATE [Patients] SET ";
        strSQL += "[FName]='{0}',";
        strSQL += "[LName]='{1}',";
        strSQL += "[PassWord]='{2}',";
        strSQL += "[DateOfBirth]=#{3}#,";
        strSQL += "[Email]='{4}' ";
        strSQL += "WHERE [PatientID]={5}";
        strSQL = string.Format(strSQL, this.FName, this.LName, this.PassWord, this.DOB, this.Email, this.PatientID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Insert()
    {
        string strSQL = "INSERT INTO [Patients] ";
        strSQL += "([PatientID],[FName],[LName],[Password],[Email],[DateOfBirth]) ";
        strSQL += "VALUES ({0}, '{1}','{2}','{3}','{4}',#{5}#)";
        strSQL = string.Format(strSQL, this.PatientID, this.FName, this.LName, this.PassWord,this.Email,this.DOB);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Delete()
    {
        string strSQL = "DELETE * FROM [Patients] ";
        strSQL += "WHERE [patientID]={0}";
        strSQL = string.Format(strSQL, this.patientID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static DataTable GetAll(string strName, string Order)
    {
        string strSQL = "SELECT * FROM [Patients] ORDER BY ";
        strSQL += "[" + strName + "]" + Order;
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public static DataTable GetByID(string ID)
    {
        string strSQL = "SELECT * FROM [Patients] WHERE ";
        strSQL += "PatientID=" + ID;
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public static DataTable GetByIDandPassWord(string ID, string PassWord)
    {
        string strSQL = "SELECT * FROM [Patients] WHERE ";
        strSQL += "PatientID=" + ID;
        strSQL += " AND PassWord='" + PassWord + "'";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
}