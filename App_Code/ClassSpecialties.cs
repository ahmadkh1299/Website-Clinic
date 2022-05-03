using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ClassSpecialties
/// </summary>
public class ClassSpecialties
{
    private string specialtyID, specialty;
    public ClassSpecialties()
    {
    }
    public string SpecialtyID
    {
        get { return specialtyID; }
        set { specialtyID = value; }
    }
    public string Specialty
    {
        get { return specialty; }
        set { specialty = value; }
    }
    public DataTable GetIDsANDSpecialties()
    {
        string strSQL = "SELECT SpecialtyID,Specialty FROM [Specialties]";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public static void InsertSpecialty(string Specialty)
    {
        string strSQL = "INSERT INTO [Specialties] ([Specialty]) VALUES ('{0}') ";
        strSQL = string.Format(strSQL, Specialty);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static string GetID(string Specialty)
    {
        string strSQL = "SELECT SpecialtyID FROM [Specialties] WHERE Specialty='" + Specialty + "'";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        if (dt.Rows.Count == 0)
        {
            InsertSpecialty(Specialty);
            dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        }
        String ID = dt.Rows[0]["SpecialtyID"].ToString();
        return ID;
    }
    public static void Delete(string SpecialtyID)
    {
        string strSQL = "DELETE * FROM Specialties WHERE SpecialtyID=" + SpecialtyID + "";
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static void DeleteNotUsed()
    {
        string strSQL = "SELECT * FROM [Specialties]";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataTable check = ClassDoctors.GetBySpecialty(dt.Rows[i]["SpecialtyID"].ToString());
            if (check.Rows.Count == 0)
                ClassSpecialties.Delete(dt.Rows[i]["SpecialtyID"].ToString());
        }
    }
}