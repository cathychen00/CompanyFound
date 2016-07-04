using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// UserInfo 的摘要说明
/// </summary>
public class UserInfo
{
    #region Model
    private int _userinfoid;
    private string _username;
    private string _userpwd;
    private int _usersexid;
    private int _userlevelid;
    /// <summary>
    /// 
    /// </summary>
    public int userinfoID
    {
        set { _userinfoid = value; }
        get { return _userinfoid; }
    }
    /// <summary>
    /// 
    /// </summary>
    public string UserName
    {
        set { _username = value; }
        get { return _username; }
    }
    /// <summary>
    /// 
    /// </summary>
    public string UserPwd
    {
        set { _userpwd = value; }
        get { return _userpwd; }
    }
    /// <summary>
    /// 
    /// </summary>
    public int usersexID
    {
        set { _usersexid = value; }
        get { return _usersexid; }
    }
    /// <summary>
    /// 
    /// </summary>
    public int userlevelID
    {
        set { _userlevelid = value; }
        get { return _userlevelid; }
    }
    #endregion Model

}