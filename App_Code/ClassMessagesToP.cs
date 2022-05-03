using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for ClassMessagesToP
/// </summary>
public class ClassMessagesToP
{
    string messageID, patientID, licenseNumber, message;
    public ClassMessagesToP()
    {
    }
    public string MessageID
    {
        get { return messageID; }
        set { messageID = value; }
    }
    public string PatientID
    {
        get { return patientID; }
        set { patientID = value; }
    }
    public string LicenseNumber
    {
        get { return licenseNumber; }
        set { licenseNumber = value; }
    }
    public string Message
    {
        get { return message; }
        set { message = value; }
    }
    public void Update()
    {
        string strSQL = "UPDATE [DtoPMessages] SET ";
        strSQL += "[LicenseNumber]={0},";
        strSQL += "[PatientID]={1},";
        strSQL += "[Message]='{2}' ";
        strSQL += "WHERE [MessageID]={3}";
        strSQL = string.Format(strSQL, this.LicenseNumber, this.PatientID, this.Message, this.MessageID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Insert()
    {
        string strSQL = "INSERT INTO [DtoPMessages] ";
        strSQL += "([LicenseNumber], [PatientID], [Message])";
        strSQL += "VALUES ({0},{1},'{2}')";
        strSQL = string.Format(strSQL, this.licenseNumber, this.patientID, this.message);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static void Deletes(string Message,string LicenseNumber)
    {
        string strSQL = "DELETE * FROM [DtoPMessages] WHERE [Message]='{0}' AND [LicenseNumber]={1}";
        strSQL = string.Format(strSQL, Message,LicenseNumber);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static DataTable GetByPID(string PatientID)
    {
        string strSQL = "SELECT Doctors.LicenseNumber, Doctors.FName, Doctors.LName, DtoPMessages.Message ";
        strSQL += "FROM Patients INNER JOIN (Doctors INNER JOIN DtoPMessages ON Doctors.LicenseNumber = DtoPMessages.LicenseNumber) ON Patients.PatientID = DtoPMessages.PatientID ";
        strSQL += " WHERE (((Patients.[PatientID])=207177197))";
        strSQL = string.Format(strSQL, PatientID);
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
}