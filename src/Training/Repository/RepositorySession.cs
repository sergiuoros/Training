using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Models;
using Training.Repository;
using WebApplication1;

namespace Training.Repository
{
    public class RepositorySession : IRepository<Session>
    {
        private TrainingContext TrainingContext;

        public RepositorySession()
        {

        }
        public RepositorySession(TrainingContext TrainingContext)
        {
            this.TrainingContext = TrainingContext;
        }

        public IEnumerable<Session> GetAll()
        {
            return TrainingContext.Sessions;
        }
        public IEnumerable<Session> GetSessionsForEvent(int id)
        {
            return TrainingContext.Sessions.Where(s => s.IdEvent == id);
        }

        public void Add(Session entity)
        {
            TrainingContext.Sessions.Add(entity);
            TrainingContext.SaveChanges();
        }

        public void Delete(Session entity)
        {
            TrainingContext.Sessions.Remove(entity);
            TrainingContext.SaveChanges();
        }

        public void Update(Session entity)
        {
            TrainingContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            TrainingContext.SaveChanges();
        }

        public Session FindById(int Id)
        {
            return TrainingContext.Sessions.FirstOrDefault(s => s.IdEvent.Equals(Id));
        }
    }
}
