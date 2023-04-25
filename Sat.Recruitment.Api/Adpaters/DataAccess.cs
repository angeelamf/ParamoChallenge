using Sat.Recruitment.Api.Entities;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Models.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Sat.Recruitment.Api.Adpaters
{
    public static class DataAccess
    {
        public static List<User> ReadUsersFromFile()
        {
            List<User> _users = new List<User>();

            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var user = new User
                {
                    Name = line.Split(',')[0],
                    Email = line.Split(',')[1],
                    Phone = line.Split(',')[2],
                    Address = line.Split(',')[3],
                    UserType = Enum.Parse<UserType>(line.Split(',')[4]),
                    Money = decimal.Parse(line.Split(',')[5]),
                };
                _users.Add(user);
            }
            reader.Close();

            return _users;
        }

        public static bool SaveUserToFile(User user)
        {
            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            user.CalculateMoney();

            foreach (var u in ReadUsersFromFile())
            {
                if (u.Email == user.Email || u.Phone == user.Phone || (u.Name == user.Name && u.Address == user.Address))
                {
                    Debug.WriteLine("The user is duplicated");
                    throw new Exception("The user is duplicated");
                }
            }

            using StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.ToString());

            return true;
        }
    }
}
