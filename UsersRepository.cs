using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using THEArcadeAppAV.Models;

namespace THEArcadeAppAV;

public class UserRepository
{
    string dbPath;
    private SQLiteConnection conn;

    public UserRepository(string db)
    {
        dbPath = db;
    }

    private void Init()
    {
        //check if connection is yes
        if (conn != null)
            return;
        //set connection
        conn = new SQLiteConnection(dbPath);
        //generate table (database)
        conn.CreateTable<Users>();
    }

    public void AddUser(string username, string password)
    {
        int result = 0;
        Init();

        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
            //insets a new user into the database w a username and password
            result = conn.Insert(new Users { Username = username, Password = password});
        }
    }

    public Users GetUser(string username)
    {
        Init();
        //searches the database for an entry w a matching username
        return conn.Table<Users>().Where(u => u.Username == username).FirstOrDefault();
    }

    public void UpdateUserFishCard(string username, string fishname, int value)
    {
        Init();

        if(username != null)
        {
            Users user = conn.Table<Users>().Where(u => u.Username == username).FirstOrDefault();

            if(user != null)
            {
                var column = typeof(Users).GetProperty(fishname);
                if(column != null && column.PropertyType == typeof(int))
                {
                    //ser new calue
                    column.SetValue(user, value);
                    //update user data
                    conn.Update(user);
                }
            }
        }
    }
}
