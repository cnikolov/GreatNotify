using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreatNotify.Base;
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

        protected override Person Calculate()
        {
            var niceDev = Participants.FirstOrDefault(x => x.Height > 180);

            return niceDev;
        }
        //I am well aware of the concurrent types and bags
        protected void CalculateScore(List<Person> participants)
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
                var participants = (List<Person>) state;
                CalculateScore(participants);
                Thread.Sleep(ms);
                Schedule(ms);
            },Participants.ToList());
        }
    }


}
