using System;
using System.Collections.Generic;
using System.Linq;
using Training.Models;
using Training.Repository;
using WebApplication1;

namespace Training.Repository
{
    public class RepositoryEvent : IRepository<Event>
    {
        private TrainingContext TrainingContext;

        public RepositoryEvent()
        {
            
        }
        public RepositoryEvent(TrainingContext TrainingContext)
        {
            this.TrainingContext = TrainingContext;
        }

        public IEnumerable<Event> GetAll()
        {
            return TrainingContext.Events;

        }

        public void Add(Event entity)
        {
            TrainingContext.Events.Add(entity);
            TrainingContext.SaveChanges();
        }

        public void Delete(Event entity)
        {
            TrainingContext.Events.Remove(entity);
            TrainingContext.SaveChanges();
        }

        public void Update(Event entity)
        {
            TrainingContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            TrainingContext.SaveChanges();
        }

        public Event FindById(int Id)
        {
            return TrainingContext.Events.FirstOrDefault(e => e.IdEvent.Equals(Id));
        }

    }
}
