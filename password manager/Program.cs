using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace password_manager
{
    //1.list all passwords
    //2.add or change password
    //3.get pass
    //4.delete pass
    class Program
    {
        private static readonly Dictionary<string, string> _passwordEntries = new Dictionary<string, string>();
        private static string magicpassword { get; set; }


        static void Main(string[] args)
        {  

            Console.WriteLine("write your password");
            var pass = Console.ReadLine();
            if (pass!=null)
            {
                magicpassword = pass;
            }
            while (true)
            {
                Console.WriteLine("select an option");
                Console.WriteLine("1.list all passwords");
                Console.WriteLine("2.add or change password");
                Console.WriteLine("3.get pass");
                Console.WriteLine("4.delete pass");

                var option = Console.ReadLine();
                if (option == "1")
                    Listallpasswords();
                else if (option == "2")
                    addOrChangePass();
                else if (option == "3")
                    GetPass();
                else if (option == "4")
                    DeletePass();
                else
                    Console.WriteLine("invalid option");
                Console.WriteLine("====================================");


            }

        }
        

        private static void Listallpasswords()
        {
            Console.WriteLine("enter your magic password");
            var pass = Console.ReadLine();
            if (pass == magicpassword)
            {
                foreach (var entry in _passwordEntries) 
                {
                  Console.WriteLine($"{entry.Key}={entry.Value}");
                }

            }
            else
            {
                Console.WriteLine("hackerrrr");
            }
            
        }

        private static void addOrChangePass()
        {
            Console.WriteLine("enter website to change");
            var website = Console.ReadLine();
            Console.WriteLine("enter password");
            var pass = Console.ReadLine();
            if (_passwordEntries.ContainsKey(website))
                _passwordEntries[website] = pass;
            else
                _passwordEntries.Add(website, pass);
            savepass();


        }

        private static void GetPass()
        {
            Console.WriteLine("enter website to change");
            var website = Console.ReadLine();
            if (_passwordEntries.ContainsKey(website))
                Console.WriteLine($"your password {_passwordEntries[website]}");
            else
                Console.WriteLine("password not found");
        }

        private static void DeletePass()
        {
            Console.WriteLine("enter website to change");
            var website = Console.ReadLine();
            if (_passwordEntries.ContainsKey(website))
                _passwordEntries.Remove(website);
            else
                Console.WriteLine("not found");
            savepass();
        }
        private static void readpass()
        {
            if (File.Exists("pass.txt"))
            {
                var passlines = File.ReadAllText("passlines.txt");
                foreach (var line in passlines.Split( Environment.NewLine.ToCharArray()))
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var eqindex = line.IndexOf('=');
                        var website = line.Substring(0, eqindex);
                        var pass = line.Substring(eqindex + 1);
                        _passwordEntries.Add(website,encryption.decrypt( pass));
                    }
                }
            }



        }
        private static void savepass()
        {
            var sb = new StringBuilder();
            foreach (var entry in _passwordEntries)
            {
                sb.AppendLine($"{entry.Key}+{encryption.encrypt( entry.Value)}");
                File.WriteAllText("pass.txt",sb.ToString());

            }


        }
    }
}
