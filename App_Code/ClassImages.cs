using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ClassImages
/// </summary>
public class ClassImages
{
    private string imageID, imageSource;
	public ClassImages()
	{
	}
    public string ImageID
    {
        get { return imageID; }
        set { imageID = value; }
    }
    public string ImageSource
    {
        get { return imageSource; }
        set { imageSource = value; }
    }
    public static DataTable GetAll()
    {
        string strSQL = "SELECT * FROM [Images]";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public static void InsertImage(string ImageSource)
    {
        string strSQL = "INSERT INTO [Images] ([ImageSource]) VALUES ({0}) ";
        strSQL = string.Format(strSQL, ImageSource);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static string GetID(string ImageSource)
    {
        string strSQL = "SELECT ImageID FROM [Images] WHERE ImageSource=" + ImageSource;
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        if (dt.Rows.Count == 0)
        {
            InsertImage(ImageSource);
            dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        }
        String ID = dt.Rows[0]["ImageID"].ToString();
        return ID;
    }
    public static void Delete(string ImageID)
    {
        string strSQL = "DELETE * FROM Images WHERE ImageID=" + ImageID + "";
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static void DeleteNotUsed()
    {
        string strSQL = "SELECT * FROM [Images]";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataTable check = ClassPharmacy.GetByImageID(dt.Rows[i]["ImageID"].ToString());
            if (check.Rows.Count == 0)
                ClassImages.Delete(dt.Rows[i]["ImageID"].ToString());
        }
    }

}