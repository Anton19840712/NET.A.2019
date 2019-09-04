using System;
using System.Threading;

namespace NET.W._2019.Gridushko._11
{
    /// <summary>
    /// Timer notification implementaton.
    /// </summary>
    public class TimeManagementInstance
    {
        public event EventHandler<TimerEventArgs> Notification = delegate { };

        /// <summary>
        /// Subscriber
        /// </summary>
        /// <param name="seconds">Delay your time</param>
        /// <param name="message">Message for subscribed types</param>
        public void NotifyOnTimer(int seconds, string message)
        {
            if (seconds < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(seconds)} must be more than 0");
            }

            Thread.Sleep(seconds * 500);
            OnNotification(this, new TimerEventArgs(seconds, message));
        }

        protected virtual void OnNotification(object sender, TimerEventArgs args)
        {
            var eventHandler = Notification;

            eventHandler?.Invoke(sender, args);
        }
    }
}