using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ClassMessagesToD
/// </summary>
public class ClassMessagesToD
{
    string messageID, patientID, licenseNumber, message;
	public ClassMessagesToD()
	{
	}
    public string MessageID
    {
        get { return messageID; }
        set { messageID = value; }
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
    public string Message
    {
        get { return message; }
        set { message = value; }
    }
    public void Update()
    {
        string strSQL = "UPDATE [PtoDMessages] SET ";
        strSQL += "[LicenseNumber]={0},";
        strSQL += "[PatientID]={1},";
        strSQL += "[Message]='{2}' ";
        strSQL += "WHERE [MessageID]={3}";
        strSQL = string.Format(strSQL, this.LicenseNumber, this.PatientID, this.Message, this.MessageID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Insert()
    {
        string strSQL = "INSERT INTO [PtoDMessages] ";
        strSQL += "([LicenseNumber], [PatientID], [Message])";
        strSQL += "VALUES ({0},{1},'{2}')";
        strSQL = string.Format(strSQL, this.licenseNumber, this.patientID, this.message);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static void Delete(string MessageID)
    {
        string strSQL = "DELETE * FROM [PtoDMessages] WHERE [MessageID]={0}";
        strSQL = string.Format(strSQL, MessageID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static void Deletes(string Message,string PatientID)
    {
        string strSQL = "DELETE * FROM [PtoDMessages] WHERE [Message]='{0}' AND [PatientID]={1}";
        strSQL = string.Format(strSQL, Message,PatientID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static DataTable GetByLN(string LicenseNumber)
    {
        string strSQL = "SELECT Patients.FName, Patients.LName, PtoDMessages.Message, Patients.PatientID ";
        strSQL += "FROM Patients INNER JOIN PtoDMessages ON Patients.PatientID = PtoDMessages.PatientID ";
        strSQL += " WHERE [LicenseNumber]={0}";
        strSQL = string.Format(strSQL, LicenseNumber);
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
}