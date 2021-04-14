using System;

namespace GreatNotify.Events
{
    public class NotificationEventArgs : EventArgs
    {
        public EActionType ActionType { get; init; }
        public string Domain { get; init; }
        public string Name { get; init; }
        public int Height { get; set; }

        public NotificationEventArgs(EActionType actionType, string domain, string name, int height = 0)
        {
            ActionType = actionType;
            Domain = domain;
            Name = name;
            Height = height;
        }
    }

    public enum EActionType
    {
        Add,
        Remove,
        Notify
    }
}