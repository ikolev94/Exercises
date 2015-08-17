namespace Buhtig_Issue_Tracker.Models
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class User
    {
        public User(string username, string password)
        {
            this.UserName = username;
            this.PasswortHash = HashPassword(password);
        }

        public string UserName { get; set; }

        public string PasswortHash { get; set; }

        public static string HashPassword(string password)
        {
            return string.Join(string.Empty, SHA1.Create().ComputeHash(Encoding.Default.GetBytes(password)).Select(x => x.ToString()));
        }
    }
}
