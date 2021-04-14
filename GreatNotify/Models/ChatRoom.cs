using System;
using System.Linq;
using GreatNotify.Base;
using GreatNotify.Contracts;
using GreatNotify.Events;

namespace GreatNotify.Models
{
    public class ChatRoom : PersonCollection<Person>
    {
        public override void Add(Person person)
        {
            base.Add(person);
            //TODO ADD LOGIC
            var eventArgs = new NotificationEventArgs(EActionType.Add, nameof(ChatRoom), person.FirstName);
            base.OnPublish(eventArgs);
        }

        public override Person Remove(Person person)
        {
            var removedPerson =  base.Remove(person);
            var eventArgs = new NotificationEventArgs(EActionType.Remove, nameof(ChatRoom), person.FirstName);
            base.OnPublish(eventArgs);
            return removedPerson;
        }

        protected override IPerson Calculate()
        {
            var peopleAbove18 = Participants.Where(x => x.DateOfBirth.Year >= DateTime.Now.Year - 18).ToList();
            var mvp = peopleAbove18.FirstOrDefault(x => x.Height  == peopleAbove18.Max(person=> person.Height) );
            return mvp;
        }
    }


}
