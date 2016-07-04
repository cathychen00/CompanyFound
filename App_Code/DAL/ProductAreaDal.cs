using System.Data.SqlClient;

/// <summary>
/// 产地信息
/// </summary>
public class ProductAreaDal
{
    public static ProductArea Get(int id)
    {
        ProductArea area = new ProductArea();

        string sqlstr = "select * from gy_KName where k_ID =" + id + " ";
        SqlData da = new SqlData();
        SqlDataReader read = da.ExceRead(sqlstr);
        read.Read();
        if (read.HasRows)
        {
            area.Id = id;
            area.Name = read["k_name"].ToString();
            area.Phone = read["k_phone"].ToString();
            area.Remark = read["k_remark"].ToString();
        }
        read.Close();

        return area;
    }

    public static bool Add(ProductArea area)
    {
        SqlData da = new SqlData();
        string useradd = "insert into gy_KName(K_name,K_phone,K_remark)values('" + area.Name + "','" + area.Phone + "','" + area.Remark + "')";
        return da.ExceSQL(useradd);
    }

    public static bool Update(ProductArea area)
    {
        SqlData da = new SqlData();
        string update = "update gy_KName set k_name='" + area.Name + "',k_phone='" + area.Phone+ "',k_remark='" + area.Remark + "' where k_ID='" + area.Id + "'";
        return da.ExceSQL(update);
    }

    public static bool Delete(int id)
    {
        string sqlstr = "delete from gy_KName where k_ID='" + id + "'";
        SqlData da = new SqlData();
        return da.ExceSQL(sqlstr);
    }

    public static bool Exist(string name)
    {
        bool exist = false;
        SqlData da = new SqlData();
        SqlDataReader read = da.ExceRead("select * from gy_KName where K_name='" + name + "'");
        read.Read();
        if (read.HasRows)
        {
            if (name == read["K_name"].ToString())
            {
                exist = true;
            }
        }
        read.Close();

        return exist;
    }
}