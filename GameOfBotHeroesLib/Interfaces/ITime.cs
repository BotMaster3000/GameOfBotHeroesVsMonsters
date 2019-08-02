using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfBotLib.Interfaces
{
    public interface ITime
    {
        int Day { get; }
        int Hour { get; }
        int Minute { get; }

        public event EventHandler TimeChanged;

        void IncreaseDay(bool fireTimeChangedEvent);
        void IncreaseHour(bool fireTimeChangedEvent);
        void IncreaseMinute(bool fireTimeChangedEvent);
    }
}
