using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password_manager
{
    public class encryption
    {
        private static readonly string originalchars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly string altchars = "1BCDEFG2IJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0AH3456789";
        public static string encrypt(string password)
        {
            var sb = new StringBuilder();
            foreach (var ch in password)
            {
                var charindex = originalchars.IndexOf(ch);
                sb.Append(altchars[charindex]);

            }
            return sb.ToString();


        }
        public static string decrypt(string password)
        {
            var sb = new StringBuilder();
            foreach (var ch in password)
            {
                var charindex = altchars.IndexOf(ch);
                sb.Append(originalchars[charindex]);

            }
            return sb.ToString();

        }
    }
}
