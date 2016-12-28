using System;
using System.Collections.Generic;
using MimeKit;

namespace MailNet
{
    public static class Store
    {
        private static readonly List<Action<MimeMessage>> _messageReceivedActions = new List<Action<MimeMessage>>();

        public static void AddMessage(MimeMessage message)
        {
            Console.WriteLine("message added.");

            foreach (var action in _messageReceivedActions)
            {
                action(message);
            }
        }

        public static void OnMessageReceived(Action<MimeMessage> action)
        {
            _messageReceivedActions.Add(action);
        }
    }
}
