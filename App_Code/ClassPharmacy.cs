using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ClassPharmacy
/// </summary>
public class ClassPharmacy
{
    private string medicineID, medicine, price, number, description, imageID;
	public ClassPharmacy()
	{
	}
    public string MedicineID
    {
        get { return medicineID; }
        set { medicineID = value; }
    }
    public string Medicine
    {
        get { return medicine; }
        set { medicine = value; }
    }
    public string Price
    {
        get { return price; }
        set { price = value; }
    }
    public string Number
    {
        get { return number; }
        set { number = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    public string ImageID
    {
        get { return imageID; }
        set { imageID = value; }
    }
    public static DataTable getAll()
    {
        string strSQL = "SELECT Pharmacy.Medicine, Pharmacy.Price, Pharmacy.Number, Pharmacy.Description, Images.ImageSource, Pharmacy.MedicineID";
        strSQL += " FROM Images INNER JOIN Pharmacy ON Images.ImageID = Pharmacy.ImageID ";
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public void Delete()
    {
        string strSQL = "DELETE * FROM [Pharmacy] WHERE [MedicineID]=" + this.MedicineID + "";
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Update()
    {
        string strSQL = "Update [Pharmacy] SET ";
        strSQL += "[Medicine] = '{0}', ";
        strSQL += "[Price] = '{1}', ";
        strSQL += "[Number] = {2}, ";
        strSQL += "[Description] = '{3}', ";
        strSQL += "[ImageID] = {4} ";
        strSQL += "WHERE [MedicineID] = {5} ";
        strSQL = string.Format(strSQL, Medicine, Price, Number, Description, ImageID, MedicineID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static void UpdateAmount(int amount,string Medicine)
    {
        string strSQL = "Update [Pharmacy] SET ";
        strSQL += "[Number] ="+amount+"";
        strSQL += " WHERE [Medicine]='" + Medicine + "'";
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void UpdateWithoutPic()
    {
        string strSQL = "Update [Pharmacy] SET ";
        strSQL += "[Medicine] = '{0}', ";
        strSQL += "[Price] = '{1}', ";
        strSQL += "[Number] = {2}, ";
        strSQL += "[Description] = '{3}' ";
        strSQL += "WHERE [MedicineID] = {4} ";
        strSQL = string.Format(strSQL, Medicine, Price, Number, Description, MedicineID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Insert()
    {
        string strSQL = "INSERT INTO [Pharmacy] ";
        strSQL += "([Medicine],[Price],[Number],[Description],[ImageID]) ";
        strSQL += "VALUES ('{0}', '{1}',{2},'{3}',{4})";
        strSQL = string.Format(strSQL, Medicine, Price, Number, Description, ImageID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static DataTable GetByImageID(string ImageID)
    {
        string strSQL = "SELECT * ";
        strSQL += "FROM Pharmacy WHERE ImageID={0} ";
        strSQL = string.Format(strSQL, ImageID);
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public static int GetAmountItem(string Medicine)
    {
        string strSQL = "SELECT [Number] FROM [Pharmacy] WHERE [Medicine] ='" + Medicine + "'";
        DataTable dt=Dbase.SelectFromTable(strSQL,"DBClinic.accdb");
        string amount="";
        if (dt.Rows.Count > 0)
        {
            amount = dt.Rows[0]["Number"].ToString();
        }
        else
            amount = "0";
        return Convert.ToInt32(amount);
    }
    public static void DeleteEnded()
    {
        DataTable dt = ClassPharmacy.getAll();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (GetAmountItem(dt.Rows[i]["Medicine"].ToString())== 0)
            {
                ClassPharmacy obj = new ClassPharmacy();
                obj.MedicineID = dt.Rows[i]["MedicineID"].ToString();
                obj.Delete();
            }
        }
    }
    public static bool Enough(int A, string Medicine)
    {
        if (A > GetAmountItem(Medicine))
        {
            return false;
        }
        return true;
    }
}