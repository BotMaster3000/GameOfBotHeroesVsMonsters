using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Interfaces;

namespace GameOfBotLib.Logic
{
    public class Time : ITime
    {
        public int Day { get; private set; }
        public int Hour { get; private set; }
        public int Minute { get; private set; }

        private const int HoursPerDay = 24;
        private const int MinutesPerHour = 60;

        public event EventHandler TimeChanged;

        public void IncreaseDay(bool fireTimeChangedEvent = true)
        {
            ++Day;
            if (fireTimeChangedEvent)
            {
                OnTimeChanged();
            }
        }

        public void IncreaseHour(bool fireTimeChangedEvent = true)
        {
            ++Hour;
            if (Hour >= HoursPerDay)
            {
                Hour = 0;
                IncreaseDay(false);
            }
            if (fireTimeChangedEvent)
            {
                OnTimeChanged();
            }
        }

        public void IncreaseMinute(bool fireTimeChangedEvent = true)
        {
            ++Minute;
            if (Minute >= MinutesPerHour)
            {
                Minute = 0;
                IncreaseHour(false);
            }
            if (fireTimeChangedEvent)
            {
                OnTimeChanged();
            }
        }

        protected virtual void OnTimeChanged(EventArgs e = null)
        {
            TimeChanged?.Invoke(this, e);
        }
    }
}
