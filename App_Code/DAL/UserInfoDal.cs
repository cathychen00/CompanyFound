using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

/// <summary>
/// UserInfoDal 的摘要说明
/// </summary>
public class UserInfoDal
{
    /// <summary>
    /// 检测用户名是否存在
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <returns>是否已经存在</returns>
    public static bool Exist(string userName)
    {
        bool exist = false;

        SqlData da = new SqlData();
        SqlDataReader read = da.ExceRead("select * from userinfo where username='" +userName + "'");
        read.Read();
        if (read.HasRows)
        {
            if (userName == read["username"].ToString())
            {
                exist=true;
            }
        }
        read.Close();

        return exist;
    }

    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <param name="password">加密后的密码</param>
    /// <param name="level">用户级别</param>
    /// <param name="sex">用户性别</param>
    /// <returns></returns>
    public static bool Add(string userName,string password,int level,int sex)
    {
        SqlData da = new SqlData();
        string useradd = string.Format("insert into userinfo(UserName,UserPwd,userlevelID,usersexID)values('{0}','{1}','{2}','{3}')", userName, password, level, sex);
        return da.ExceSQL(useradd);
    }

    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static UserInfo Get(int id)
    {
        string sqlstr = "select * from userinfo where userinfoID=" + id + " ";
        SqlData da = new SqlData();
        SqlDataReader read = da.ExceRead(sqlstr);
        read.Read();

        UserInfo userinfo = new UserInfo();
        if (read.HasRows)
        {
            userinfo.userinfoID = id;
            userinfo.UserPwd = read["UserPwd"].ToString();
            userinfo.UserName = read["username"].ToString();
            userinfo.usersexID =Convert.ToInt16(read["usersexID"].ToString());
            userinfo.userlevelID =Convert.ToInt16(read["userlevelID"].ToString());
        }

        read.Close();

        return userinfo;
    }

    /// <summary>
    /// 更新用户信息
    /// </summary>
    /// <param name="userInfo"></param>
    /// <returns></returns>
    public static bool Update(UserInfo userInfo)
    {
        SqlData da = new SqlData();
        string update = "update userinfo set username='" + userInfo.UserName + "',userpwd='" +userInfo.UserPwd + "',usersexID='" + userInfo.usersexID + "',userlevelID='" + userInfo.userlevelID + "' where userinfoID='" + userInfo.userinfoID + "'";
        return da.ExceSQL(update);
    }

    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static bool Delete(int id)
    {
        string sql = "delete from userinfo where userinfoID='" + id + "'";
        SqlData da = new SqlData();
        return da.ExceSQL(sql);
    }
}