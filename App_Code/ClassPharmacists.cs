using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for ClassPharmacists
/// </summary>
public class ClassPharmacists
{
    string pharmacistID, fName, lName, userName, passWord;
    public ClassPharmacists()
    {
    }
    public string PharmacistID
    {
        get { return pharmacistID; }
        set { pharmacistID = value; }
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
    public string UserName
    {
        get { return userName; }
        set { userName = value; }
    }
    public string PassWord
    {
        get { return passWord; }
        set { passWord = value; }
    }
    public static DataTable CheckIfIn(string UserName, string PassWord)
    {
        string strSQL = "SELECT * FROM [Pharmacists] WHERE [UserName]='{0}' AND [PassWord]='{1}'";
        strSQL = string.Format(strSQL, UserName, PassWord);
        DataTable dt= Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public void Update()
    {
        string strSQL = "UPDATE Pharmacists SET";
        strSQL += "[FName] = '{0}', ";
        strSQL += "[LName] = '{1}', ";
        strSQL += "[UserName] = '{2}', ";
        strSQL += "[PassWord] = '{3}' ";
        strSQL += "WHERE [PharmacistID]={4}";
        strSQL = string.Format(strSQL, FName, LName, UserName, PassWord, PharmacistID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static DataTable GetByID(string ID)
    {
        string strSQL = "SELECT * FROM [Pharmacists] WHERE [PharmacistID]=" + ID;
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public static DataTable GetAll()
    {
        string strSQL = "SELECT * FROM [Pharmacists] ";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public void Delete()
    {
        string strSQL = "DELETE * FROM [pharmacists] WHERE [PharmacistID]=" + PharmacistID;
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Insert()
    {
        string strSQL = "INSERT INTO [Pharmacists] ";
        strSQL += "([FName],[LName],[Password],[UserName]) ";
        strSQL += "VALUES ('{0}', '{1}','{2}','{3}')";
        strSQL = string.Format(strSQL, this.FName, this.LName, this.PassWord, this.userName);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
}