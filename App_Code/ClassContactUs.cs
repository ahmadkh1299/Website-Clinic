using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ClassContactUs
/// </summary>
public class ClassContactUs
{
    private string messageID, message, phoneNumber;
	public ClassContactUs()
	{
	}
    public string MessageID
    {
        get { return messageID; }
        set { messageID = value; }
    }
    public string Message
    {
        get { return message; }
        set { message = value; }
    }
    public string PhoneNumber
    {
        get { return phoneNumber; }
        set { phoneNumber = value; }
    }
    public void Update()
    {
        string strSQL = "UPDATE [ContactUs] SET ";
        strSQL += "[Message]='{0}',";
        strSQL += "[PhoneNumber]={1} ";
        strSQL += "WHERE [MessageID]={2}";
        strSQL = string.Format(strSQL, this.Message, this.PhoneNumber, this.MessageID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Insert()
    {
        string strSQL = "INSERT INTO [ContactUs] ";
        strSQL += "([Message],[PhoneNumber]) ";
        strSQL += "VALUES ('{0}', {1})";
        strSQL = string.Format(strSQL, this.Message, this.PhoneNumber);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Delete()
    {
        string strSQL = "DELETE * FROM [ContactUs] ";
        strSQL += "WHERE [Message]='{0}' AND [PhoneNumber]={1}";
        strSQL = string.Format(strSQL, Message,phoneNumber);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static DataTable GetAll()
    {
        string strSQL="SELECT * FROM [ContactUs]";
        DataTable dt= Dbase.SelectFromTable(strSQL,"DBClinic.accdb");
        return dt;
    }
}