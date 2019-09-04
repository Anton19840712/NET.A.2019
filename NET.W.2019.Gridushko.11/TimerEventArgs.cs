using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Gridushko._11
{
    /// <summary>
    /// Argument event info
    /// </summary>
    public class TimerEventArgs : EventArgs
    {
        private int _periodNotification;
        public TimerEventArgs(int notificationInterval, string message)
        {
            PeriodNotification = notificationInterval;
            Message = message;
        }
        public int PeriodNotification
        {
            get
            {
                return _periodNotification;
            }

            private set
            {
                if (value > 0)
                {
                    _periodNotification = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be more than 0.");
                }
            }
        }
        public string Message { get; }
    }
}