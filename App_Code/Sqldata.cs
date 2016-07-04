using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;


/// <summary>
/// SqlData 的摘要说明
/// </summary>
public class SqlData
{
    #region  类中的全局变量

    private SqlConnection sqlcon;  //申明一个SqlConnection对象
    private SqlCommand sqlcom;   //申明一个SqlCommand对象
    private SqlDataAdapter sqldata;   //申明一个SqlDataAdapter对象

    #endregion

    #region  构造函数

    /// <summary>
    /// 创建时间:2007－3－15
    /// 创建人:朱江
    /// 构造函数，初始化时连接数据库
    /// </summary>
    public SqlData()
    {
        sqlcon = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        sqlcon.Open();   //打开链接
    }

    #endregion

    #region  绑定用户页面中的GridView控件
    /// <summary>
    /// 创建时间:2007-3-15
    /// 创建人:朱江
    /// 此方法实现数据绑定到GridView中
    /// </summary>
    /// <param name="dl">要绑定的控件</param>
    /// <param name="SqlCom">要执行的SQL语句</param>
    /// <returns></returns>
    public bool BindData(GridView dl, string SqlCom)
    {
        dl.DataSource = this.ExceDS(SqlCom);
        try
        {
            dl.DataBind();
            return true;
        }
        catch
        {
            return false;
        }
        finally
        {
            sqlcon.Close();
        }
    }
    #endregion

    #region  执行SQL语句
    /// <summary>
    /// 创建时间:2007-3-15
    /// 创建人:朱江
    /// 此方法用来执行SQL语句
    /// </summary>
    /// <param name="SqlCom">要执行的SQL语句</param>
    /// <returns></returns>
    public bool ExceSQL(string strSqlCom)
    {
        sqlcom = new SqlCommand(strSqlCom, sqlcon);
        try
        {
            sqlcom.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
        finally
        {
            sqlcon.Close();
        }
    }
    #endregion
  
//该源码下载自www.51aspx.com(５１ａｓｐｘ．ｃｏｍ)


    #region  返回DataSet类型数据
    /// <summary>
    /// 创建时间:200-3-15
    /// 创建人:朱江
    /// 此方法返回一个DataSet类型
    /// </summary>
    /// <param name="SqlCom">要执行的SQL语句</param>
    /// <returns></returns>
    public DataSet ExceDS(string SqlCom)
    {
        try
        {
            sqlcom = new SqlCommand(SqlCom, sqlcon);
            sqldata = new SqlDataAdapter();
            sqldata.SelectCommand = sqlcom;
            DataSet ds = new DataSet();
            sqldata.Fill(ds);
            return ds;
        }
        finally
        {
            sqlcon.Close();
        }
    }
    #endregion

    #region  返回SqlDataReader类型的数据
    /// <summary>
    /// 创建时间:2007-3-15
    /// 创建人:朱江
    /// 此方法返回一个SqlDataReader类型的参数
    /// </summary>
    /// <param name="SqlCom"></param>
    /// <returns></returns>
    public SqlDataReader ExceRead(string SqlCom)
    {
        sqlcom = new SqlCommand(SqlCom, sqlcon);
        SqlDataReader read = sqlcom.ExecuteReader();
        return read;
    }
    #endregion


    public string Encrypt(string strInput)
    {
        //转换为UTF8编码
        byte[] b = Encoding.UTF8.GetBytes(strInput);

        //计算字符串UTF8编码后的的MD5哈希值，并转换为字符串
        MD5 md5 = new MD5CryptoServiceProvider();
        return Encoding.UTF8.GetString(md5.ComputeHash(b));
    }

    //
    public class MyTemplate : ITemplate
    {
        private string colname;

        public MyTemplate(string colname)
        {
            this.colname = colname;
        }

        public void InstantiateIn(Control container)
        {
            LiteralControl l = new LiteralControl();
            l.DataBinding += new EventHandler(this.OnDataBinding);
            container.Controls.Add(l);
        }

        public void OnDataBinding(object sender, EventArgs e)
        {
            LiteralControl l = (LiteralControl)sender;
            GridViewRow container = (GridViewRow)l.NamingContainer;
            l.Text = ((DataRowView)container.DataItem)[colname].ToString();
        }
    }
 
}
