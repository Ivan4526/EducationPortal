using System.Linq;

public class PasswordHasher
{
    public string SecretKey { get; set; } = "JHD7-BCX9-SRWT-95H1-NNM1";

    public string Hash(string originalPassword)
    {
        return originalPassword.Reverse().Concat(this.SecretKey).ToString();
    }
}