using System;

namespace GreatNotify.Events
{
    public class NotificationEventArgs : EventArgs
    {
        public EActionType ActionType { get; init; }
        public string Domain { get; init; }
        public string Name { get; init; }

        public NotificationEventArgs(EActionType actionType, string domain, string name)
        {
            ActionType = actionType;
            Domain = domain;
            Name = name;
        }
    }

    public enum EActionType
    {
        Add,
        Remove
    }
}