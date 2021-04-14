using System;

namespace GreatNotify.Events
{
    public class NotificationEventArgs : EventArgs
    {
        public string Action { get; init; }
        public string Domain { get; init; }
        public string Name { get; init; }

        public NotificationEventArgs(string action, string domain, string name)
        {
            Action = action;
            Domain = domain;
            Name = name;
        }
    }
}