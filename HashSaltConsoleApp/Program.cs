using System;
using System.Collections.Generic;
using System.Text;

namespace HashSaltConsoleApp
{
    class Program
    {
        static List<User> users = new List<User>();

        static void Main(string[] args)
        {
            HashPassword hashPassword = new HashPassword();

            Console.WriteLine("write your name to sign up");
            string name = Console.ReadLine();

            Console.WriteLine("write your new pasword to sign up");
            string password = Console.ReadLine();

            hashPassword.generateSalt();

            byte[] salt = hashPassword.generateSalt();
            string hashed = hashPassword.HashPasswordHMACSHA1(password, salt, 10000);

            users.Add(new User(name, hashed, Convert.ToBase64String(salt)));
            
            int attempts = 0;

            while (attempts < 5)
            {
                Console.WriteLine("write your name to log in");
                string nameInput = Console.ReadLine();
                Console.WriteLine("write your pasword to log in");
                string passwordInput = Console.ReadLine();
                if (nameInput == users[0].Name)
                {
                    if (hashPassword.HashPasswordHMACSHA1(passwordInput,Convert.FromBase64String(users[0].Salt), 10000) == hashed)
                    {
                        Console.WriteLine(hashPassword.HashPasswordHMACSHA1(passwordInput, Convert.FromBase64String(users[0].Salt), 10000));
                        Console.WriteLine(hashed);
                        Console.WriteLine("gain entrance");
                    }
                }
                attempts++;
            }
        }
    }
}
