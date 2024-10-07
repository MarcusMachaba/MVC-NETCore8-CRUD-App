using System.Security.Cryptography;
using System.Text;

namespace MVC.CRUD.Interface.UtilityHelpers;

public sealed class ApplicationEncryption
{
    public static string SuperEncrypt(string encryptionKey, string plainText)
    {
        if (string.IsNullOrWhiteSpace(encryptionKey) || string.IsNullOrWhiteSpace(plainText))
            throw new ArgumentNullException("Plain Text or EncryptionKey is invalid", (Exception)null);

        var _x64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
        return Encrypt(encryptionKey, _x64);
    }

    private static string Encrypt(string encryptionKey, string plainText)
    {
        byte[] inputArray = Encoding.UTF8.GetBytes(plainText);
        TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider
        {
            Key = Encoding.UTF8.GetBytes(encryptionKey),
            Mode = CipherMode.ECB,
            Padding = PaddingMode.PKCS7
        };
        ICryptoTransform cTransform = tripleDES.CreateEncryptor();
        byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
        tripleDES.Clear();
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    public static string SuperDecrypt(string decryptionKey, string cypherText)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(decryptionKey) || string.IsNullOrWhiteSpace(cypherText))
                throw new ArgumentNullException("Cypher Text or DecryptionKey is invalid", (Exception)null);

            var _x64 = Decrypt(decryptionKey, cypherText);
            return Encoding.UTF8.GetString(Convert.FromBase64String(_x64));

        }
        catch (Exception e)
        {
            throw;
        }

    }

    private static string Decrypt(string decryptionKey, string cypherText)
    {
        try
        {
            byte[] inputArray = Convert.FromBase64String(cypherText);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider
            {
                Key = Encoding.UTF8.GetBytes(decryptionKey),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Encoding.UTF8.GetString(resultArray);
        }
        catch (Exception e)
        {
            throw;
        }

    }
}
