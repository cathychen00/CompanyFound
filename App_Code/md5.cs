using System.Security.Cryptography;
using System.Text;

public class Md5
{
    public static string Encrypt(string strInput)
    {
        //ת��ΪUTF8����
        byte[] b = Encoding.UTF8.GetBytes(strInput);

        //�����ַ���UTF8�����ĵ�MD5��ϣֵ����ת��Ϊ�ַ���
        MD5 md5 = new MD5CryptoServiceProvider();
        return Encoding.UTF8.GetString(md5.ComputeHash(b));
    }
}