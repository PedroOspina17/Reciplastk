using System.Security.Cryptography;
using System.Text;

namespace Reciplastk.Gateway.Common
{
    public static class Encrypt
    {
        public static string EncryptPassword(string input)
        {
            MD5 mD5Hash = MD5.Create();
            byte[] data = mD5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }

    }
}
