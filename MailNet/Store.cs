using System;
using System.Collections.Generic;

namespace MailNet
{
    public static class Store
    {
        private static readonly List<Action> _messageReceivedActions = new List<Action>();

        public static void AddMessage()
        {
            Console.WriteLine("message added.");

            foreach (var action in _messageReceivedActions)
            {
                action();
            }
        }

        public static void OnMessageReceived(Action action)
        {
            _messageReceivedActions.Add(action);
        }
    }
}
