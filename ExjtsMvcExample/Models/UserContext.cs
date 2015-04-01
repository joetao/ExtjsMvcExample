using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExjtsMvcExample.DbAccess;
using Npgsql;

namespace ExjtsMvcExample.Models
{
    public class UserContext
    {
        DBHelper dbHelper = new DBHelper();
        public List<User> GetUserList()
        {
            List<User> list = new List<User>();

            string sql = "select id,name,age,phone,email from users";

            NpgsqlDataReader dataReader = DBHelper.GetDataReader(sql);

            if (dataReader != null && dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    User user = new User();
                    user.ID = (int)dataReader["id"];
                    user.Name = dataReader["name"].ToString();
                    user.Age = (int)dataReader["age"];
                    user.Phone = dataReader["phone"].ToString();
                    user.Email = dataReader["email"].ToString();
                    list.Add(user);
                }
            }

            return list;
        }
    }
}