using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreatNotify.Base;
using GreatNotify.Contracts;
using GreatNotify.Events;

namespace GreatNotify.Models
{
    public class ChatRoom : PersonCollection<IPerson>
    {
        public override void Add(IPerson person)
        {
            base.Add(person);
            //TODO ADD LOGIC
            var eventArgs = new NotificationEventArgs(EActionType.Add, nameof(ChatRoom), person.FirstName);
            base.OnPublish(eventArgs);
        }
        //WC O(n)
        public override void Add(IPerson[] people)
        {
            base.Add(people);
            foreach (var person in people)
            {
                var eventArgs = new NotificationEventArgs(EActionType.Add, nameof(ChatRoom), person.FirstName);
                base.OnPublish(eventArgs);

            }
        }

        //Remove Person with the highest Value
        public override IPerson Remove()
        {
            var removedPerson = base.Remove();
            //Business Logic
            if (removedPerson == null) return null;
            var eventArgs = new NotificationEventArgs(EActionType.Remove, nameof(ChatRoom), removedPerson.FirstName);
            base.OnPublish(eventArgs);
            return removedPerson;
        }

        //Some very complicated Algorithm
        protected override IPerson Calculate()
        {
            var result = Participants.FirstOrDefault(x => x.Height > 160);

            return result;
        }
        //I am well aware of the concurrent types and bags
        protected void CalculateScore(List<IPerson> participants)
        {
            foreach (var participant in participants)
            {
                var eventArgs = new NotificationEventArgs(EActionType.Notify, nameof(ChatRoom), participant.FirstName,
                    participant.Height);
                base.OnPublish(eventArgs);
            }
        }

        public void Schedule(int ms)
        {
            //Easier to implement I could use concurrent bags instead of state. its a give or take.
            Task.Factory.StartNew((state) =>
            {
                var participants = (List<IPerson>) state;
                CalculateScore(participants);
                Thread.Sleep(ms);
                Schedule(ms);
            },Participants.ToList());
        }
    }


}
