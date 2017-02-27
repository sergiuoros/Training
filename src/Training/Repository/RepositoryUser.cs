using System;
using System.Linq;
using Training.Models;
using WebApplication1;

namespace Training.Repository
{
    public class RepositoryUser : IDisposable
    {
        private TrainingContext trainingContext;

        public RepositoryUser()
        {
            trainingContext = new TrainingContext();
        }

        public void Dispose()
        {
            if (trainingContext != null)
            {
                trainingContext.Dispose();
            }
        }

        //public bool CheckUser(string username, string password)
        //{
        //    string connetionString = null;
        //    SqlConnection con;
        //    connetionString = "Data Source=CJ1434-LAP\\SQLEXPRESS;Initial Catalog=Training;Integrated Security=True";
        //    con = new SqlConnection(connetionString);

        //    SqlCommand cmd = new SqlCommand("Select * from User where username= @username and @password=password", con);
        //    cmd.Parameters.AddWithValue("@Username", username);
        //    cmd.Parameters.AddWithValue("@password", password);
        //    con.Open();
        //    var result = cmd.ExecuteScalar();
        //    if (result != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        public User GetUser(string username, string password)
        {
            return trainingContext.Users.FirstOrDefault(u => u.username.Equals(username) && u.password.Equals(password));
        }
    }
}
