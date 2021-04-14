﻿using System;
using System.Collections.Generic;

namespace GreatNotify.Base
{
    //My personal choice would be to use generics <T>
    public abstract class PersonCollection<T>
    {
        protected IEnumerable<T> Participants { get; set; } = new List<T>();
        public virtual event EventHandler<EventArgs> Publish;


        protected void OnPublish(EventArgs e)
        {
            Publish?.Invoke(this,e);
        }
        public virtual void Add(T person)
        {
            //TODO
        }

        //Every little helps. overload might be handy.
        public virtual void Add(T[] person)
        {
            //TODO
        }
        public virtual T Remove(T person)
        {
            //TODO ADD LOGIC
            return person;
        }
        //Value could be double/ int keep it flexible.
        protected abstract object Calculate();
    }
}