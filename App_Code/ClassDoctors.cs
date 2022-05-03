using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class ClassDoctors
{
    private String licenseNumber, fName, lName, password, specialtyID, isManger, imageSource;
    public ClassDoctors()
    {
    }
    public string LicenseNumber
    {
        get { return licenseNumber; }
        set { licenseNumber = value; }
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
        get { return password; }
        set { password = value; }
    }
    public string SpecialtyID
    {
        get { return specialtyID; }
        set { specialtyID = value; }
    }
    public string IsManger
    {
        get { return isManger; }
        set { isManger = value; }
    }
    public string ImageSource
    {
        get { return imageSource; }
        set { imageSource = value; }
    }
    public void Update()
    {
        string strSQL = "UPDATE [Doctors] SET ";
        strSQL += "[FName]='{0}',";
        strSQL += "[LName]='{1}',";
        strSQL += "[PassWord]='{2}',";
        strSQL += "[SpecialtyID]={3},";
        strSQL += "[ImageSource]={4},";
        strSQL += "[IsManger]={5} ";
        strSQL += "WHERE [LicenseNumber]={6}";
        strSQL = string.Format(strSQL, this.FName, this.LName, this.PassWord, this.SpecialtyID,this.ImageSource, this.isManger, this.LicenseNumber);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void UpdateWithoutPic()
    {
        string strSQL = "UPDATE [Doctors] SET ";
        strSQL += "[FName]='{0}',";
        strSQL += "[LName]='{1}',";
        strSQL += "[PassWord]='{2}',";
        strSQL += "[SpecialtyID]={3},";
        strSQL += "[IsManger]={4} ";
        strSQL += "WHERE [LicenseNumber]={5}";
        strSQL = string.Format(strSQL, this.FName, this.LName, this.PassWord, this.SpecialtyID, this.isManger, this.LicenseNumber);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Insert()
    {
        string strSQL = "INSERT INTO [Doctors] ";
        strSQL += "([LicenseNumber],[FName],[LName],[Password],[SpecialtyID],[IsManger],[ImageSource]) ";
        strSQL += "VALUES ({0}, '{1}','{2}','{3}','{4}',{5},{6})";
        strSQL = string.Format(strSQL, this.LicenseNumber, this.FName, this.LName, this.PassWord, this.SpecialtyID, this.IsManger, this.ImageSource);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Delete()
    {
        string strSQL = "DELETE * FROM [Doctors] ";
        strSQL += "WHERE [LicenseNumber]={0}";
        strSQL = string.Format(strSQL, this.LicenseNumber);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static void DeleteAll(string strLicenseNumber)
    {
        string strSQL = "DELETE * FROM [Doctors] ";
        strSQL += "WHERE [LicenseNumber] IN {0}";
        strSQL = string.Format(strSQL, strLicenseNumber);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public DataTable GetAll()
    {
        string strSQL = "SELECT Doctors.FName, Doctors.LName,Doctors.ImageSource, Specialties.Specialty ";
        strSQL += "FROM Specialties INNER JOIN Doctors ON Specialties.SpecialtyID = Doctors.SpecialtyID";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public static DataTable CheckIfIn(string LicenseNumber,string PassWord)
    {
        string strSQL = "SELECT Doctors.LicenseNumber, Doctors.FName, Doctors.LName, Doctors.PassWord, Doctors.ImageSource, Doctors.IsManger, Specialties.Specialty";
        strSQL += " FROM Specialties INNER JOIN Doctors ON Specialties.SpecialtyID = Doctors.SpecialtyID ";
        strSQL += "WHERE LicenseNumber=" + LicenseNumber + "";
        strSQL += " AND PassWord=" + "'" + PassWord + "'";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public static DataTable GetByLN(string LN)
    {
        string strSQL = "SELECT Doctors.LicenseNumber, Doctors.FName, Doctors.LName, Doctors.PassWord, Doctors.ImageSource, Doctors.IsManger, Specialties.Specialty";
        strSQL += " FROM Specialties INNER JOIN Doctors ON Specialties.SpecialtyID = Doctors.SpecialtyID ";
        strSQL += "WHERE LicenseNumber=" + LN + "";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public static DataTable GetAlls()
    {
        string strSQL = "SELECT *, Specialties.Specialty ";
        strSQL += "FROM Specialties INNER JOIN Doctors ON Specialties.SpecialtyID = Doctors.SpecialtyID ";
        strSQL += "ORDER BY Specialties.Specialty";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public static DataTable GetBySpecialty(string SpecialtyTG)
    {
        string strSQL = "SELECT * ";
        strSQL += "FROM Doctors WHERE SpecialtyID={0} ";
        strSQL = string.Format(strSQL, SpecialtyTG);
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
}