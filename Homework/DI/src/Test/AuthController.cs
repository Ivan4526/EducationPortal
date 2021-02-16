namespace Auth
{
    public class AuthController
    {
        public void LogIn(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && username == "Admin")
            {
                this.RedirectToAdminLogIn(username, password);
                return;
            }

            this.SignIn(username, password);
        }

        public void LogOut(User user)
        {
            if (user != null && user.Name == "Admin")
            {
                this.LogOutAdmin();
                return;
            }

            this.SignOut(user);
        }

        public void RedirectToAdminLogIn(string username, string password) { /*...*/ }
        public void SignIn(string username, string password) { /*...*/ }
        public void SignOut(User user) { /*...*/ }
        public void LogOutAdmin() { /*...*/ }
    }

    public class User
    {
        public string Name { get; set; }
    }
}