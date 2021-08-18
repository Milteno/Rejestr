using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.Logic
{
    public class LostProcessor
    {
        public static int CreateLost(string firstName, string lastName, int age, GenderEnum gender)
        {
            LostModel data = new LostModel
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Gender = gender

            };
            string sql = @"insert into dbo.Lost (FirstName, LastName, Age, Gender) values (@FirstName, @LastName, @Age, @Gender);";

            return SqlDataAccess.SaveData(sql, data);
        }
        public static List <LostModel> LoadLost()
        {
            string sql = "select Id, FirstName, LastName, Age, Gender FROM dbo.Lost;";
            return SqlDataAccess.LoadData<LostModel>(sql);
        }
        public static int EditLost(int Id, string firstName, string lastName, int age, GenderEnum gender)
        {
            LostModel data = new LostModel
            {
                Id = Id,
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Gender = gender

            };
            string sql = @"UPDATE dbo.Lost SET FirstName = @FirstName, LastName = @LastName, Age = @Age, Gender = @Gender WHERE Id = @Id;";
            return SqlDataAccess.SaveData(sql, data);
        }
        public static int Deletesql(int Id, string firstName, string lastName, int age, GenderEnum gender)
        {
            LostModel data = new LostModel
            {
                Id = Id,
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Gender = gender

            };
            string sql = @"DELETE FROM dbo.Lost WHERE Id = @Id;";
            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
