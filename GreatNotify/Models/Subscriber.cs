using System;
using GreatNotify.Events;

namespace GreatNotify.Models
{
    public class Subscriber
    {
        public Subscriber(string name)
        {
            Name = name;
        }
        //init a nice little feature with .net 5
        public string Name { get; init; }

        public void Notify(object? sender, EventArgs e)
        {
            var notificationEvent = e as NotificationEventArgs;
            if (notificationEvent == null) return;
            Console.WriteLine($"{Name} - new person {notificationEvent.Action} the {notificationEvent.Domain} with nick ${notificationEvent.Name}");
        }
    }
}