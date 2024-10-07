namespace MVC.CRUD.Interface.UtilityHelpers;

public class ApplicationPasswordEncryption
{
    private static string PasswordEncryptionKey { get; set; }
    public static void SetPasswordEncruptionKey(string passwordEncryptionKey)
    {
        PasswordEncryptionKey = passwordEncryptionKey;
    }

    public static string EncryptPassword(string plainTextPassword)
    {
        return ApplicationEncryption.SuperEncrypt(PasswordEncryptionKey, plainTextPassword);
    }

    public static bool PasswordIsMatch(string plainTextPassword, string encryptedPassword)
    {
        if (string.IsNullOrWhiteSpace(plainTextPassword) || string.IsNullOrWhiteSpace(encryptedPassword))
            throw new ArgumentNullException();

        return ApplicationEncryption.SuperDecrypt(PasswordEncryptionKey, encryptedPassword).Equals(plainTextPassword);
    }
}
