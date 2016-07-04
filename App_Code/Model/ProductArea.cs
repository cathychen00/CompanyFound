/// <summary>
/// 产地信息
/// </summary>
public class ProductArea
{
    private int _id;
    private string _name;
    private string _phone;
    private string _remark;
    /// <summary>
    /// 
    /// </summary>
    public int Id
    {
        set { _id = value; }
        get { return _id; }
    }
    /// <summary>
    /// 
    /// </summary>
    public string Name
    {
        set { _name = value; }
        get { return _name; }
    }
    /// <summary>
    /// 
    /// </summary>
    public string Phone
    {
        set { _phone = value; }
        get { return _phone; }
    }
    /// <summary>
    /// 
    /// </summary>
    public string Remark
    {
        set { _remark = value; }
        get { return _remark; }
    }
}