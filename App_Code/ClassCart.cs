using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ClassCart
/// </summary>
public class ClassCart
{
    private string itemID, item, price, number, patientID;
	public ClassCart()
	{
	}
    public string ItemID
    {
        get { return itemID; }
        set { itemID = value; }
    }
    public string Item
    {
        get { return item; }
        set { item = value; }
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
    public string PatientID
    {
        get { return patientID; }
        set { patientID = value; }
    }
    public void Update()
    {
        string strSQL = "UPDATE [Cart] SET ";
        strSQL += "[Item]='{0}',";
        strSQL += "[Price]='{1}',";
        strSQL += "[Number]='{2}',";
        strSQL += "[PatientID]='{3}' ";
        strSQL += "WHERE [ItemID]={4}";
        strSQL = string.Format(strSQL, this.Item, this.Price, this.Number,  this.PatientID, this.ItemID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public void Insert()
    {
        string strSQL = "INSERT INTO [Cart] ";
        strSQL += "([Item],[Price],[Number],[PatientID]) ";
        strSQL += "VALUES ('{0}', '{1}',{2},{3})";
        strSQL = string.Format(strSQL, this.Item, this.Price, this.Number, this.PatientID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static void Delete(string Item,string PatientID)
    {
        string strSQL = "DELETE * FROM [Cart] ";
        strSQL += "WHERE [ItemID]={0} AND [PatientID]={1}";
        string ItemID = ClassCart.GetItemID(Item, PatientID);
        strSQL = string.Format(strSQL, ItemID,PatientID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static string GetItemID(string Item, string PatientID)
    {
        string strSQL = "SELECT [ItemID] FROM [Cart] WHERE [PatientID]={0} AND [Item]='{1}'";
        strSQL = string.Format(strSQL, PatientID, Item);
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt.Rows[0][0].ToString();
    }
    public static DataTable GetAll(string PatientID)
    {
        string strSQL = "SELECT * FROM [Cart] WHERE [PatientID]={0} ";
        strSQL = string.Format(strSQL, PatientID);
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public static DataTable GetByID(string ID)
    {
        string strSQL = "SELECT * FROM [Cart] WHERE ";
        strSQL += "ItemID=" + ID;
        DataTable dt = Dbase.SelectFromTable(strSQL, "DBClinic.accdb");
        return dt;
    }
    public static void Clear(string PatientID)
    {
        DataTable dt = ClassCart.GetAll(PatientID);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int Wanted = Convert.ToInt32(dt.Rows[i]["Number"].ToString());
            int Amount = ClassPharmacy.GetAmountItem(dt.Rows[i]["Item"].ToString());
            ClassPharmacy.UpdateAmount(Amount - Wanted, dt.Rows[i]["Item"].ToString());
        }
        string strSQL = "DELETE * FROM [Cart] ";
        strSQL += "WHERE [PatientID]={0}";
        strSQL = string.Format(strSQL, PatientID);
        Dbase.ChangeTable(strSQL, "DBClinic.accdb");
    }
    public static void DeleteNotAvalibe(string PatientID)
    {
        DataTable dt = ClassCart.GetAll(PatientID);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (ClassPharmacy.GetAmountItem(dt.Rows[i]["Item"].ToString()) == 0)
            {
                ClassCart obj = new ClassCart();
                Delete(dt.Rows[i]["Item"].ToString(), PatientID);
            }
        }
    }
}