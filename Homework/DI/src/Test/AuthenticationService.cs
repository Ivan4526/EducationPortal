public class AuthenticationService
{
    public void AuthenticateWithCookies(string username, string password)
    {
        new CookiesAuthenticationService().Authenticate(username, password);
    }

    public void AuthenticateWithToken(string username, string password)
    {
        new JwtAuthenticationService().Authenticate(username, password);
    }
}

public class CookiesAuthenticationService
{
    public void Authenticate(string username, string password)
    {
        // ...
    }
}

public class JwtAuthenticationService
{
    public void Authenticate(string username, string password)
    {
        // ...
    }
}