using System.Security.Cryptography;
using System.Text;

public class Md5
{
    public static string Encrypt(string strInput)
    {
        //转换为UTF8编码
        byte[] b = Encoding.UTF8.GetBytes(strInput);

        //计算字符串UTF8编码后的的MD5哈希值，并转换为字符串
        MD5 md5 = new MD5CryptoServiceProvider();
        return Encoding.UTF8.GetString(md5.ComputeHash(b));
    }
}