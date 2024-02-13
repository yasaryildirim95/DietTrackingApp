using System;
using System.Security.Cryptography;
using System.Text;

public class PasswordHasher
{
    public string CalculateSHA256(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            // Hash'i hex formatına dönüştür
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2")); // x2 ile her byte'ı 2 haneli hexadecimal olarak formatlar
            }

            return builder.ToString();
        }
    }

}
