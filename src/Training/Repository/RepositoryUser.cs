using System;
using System.Collections.Generic;
using System.Linq;
using Training.Models;
using WebApplication1;

namespace Training.Repository
{
    public class RepositoryUser : IRepository<User>
    {
        private TrainingContext TrainingContext;

        public RepositoryUser()
        {
            
        }

        public RepositoryUser(TrainingContext TrainingContext)
        {
            this.TrainingContext = TrainingContext;
        }

        public IEnumerable<User> GetAll()
        {
            return TrainingContext.Users;
        }

        public void Add(User entity)
        {
            TrainingContext.Users.Add(entity);
            TrainingContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            TrainingContext.Users.Remove(entity);
            TrainingContext.SaveChanges();
        }

        public void Update(User entity)
        {
            TrainingContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            TrainingContext.SaveChanges();
        }

        public User FindById(int Id)
        {
            return TrainingContext.Users.FirstOrDefault(u => u.Id.Equals(Id));
        }


        public User GetUser(string username, string password)
        {
            return TrainingContext.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));
        }
    }
}
