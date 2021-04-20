using System;
using System.Collections.Generic;

namespace GreatNotify.Base
{
    //My personal choice would be to use generics <T>
    public abstract class PersonCollection<T>
    {
        protected List<T> Participants { get; set; } = new List<T>();
        public virtual event EventHandler<EventArgs> Publish;


        protected void OnPublish(EventArgs e)
        {
            Publish?.Invoke(this,e);
        }
        public virtual void Add(T person)
        {
            Participants.Add(person);
        }
        public virtual void AddRange(T[] people)
        {
            Participants.AddRange(people);
        }
        public virtual T Remove()
        {
            var person = Calculate();
            Participants.Remove(person);
            return person;
        }
        protected abstract T Calculate();
    }
}
