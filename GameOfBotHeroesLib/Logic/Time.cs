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

        public void IncreaseDay()
        {
            ++Day;
            OnTimeChanged();
        }

        private void IncreaseDayWithoutEvent()
        {
            ++Day;
        }

        public void IncreaseHour()
        {
            int hour = ++Hour;
            IncrementTimeIfNeeded(ref hour,
                HoursPerDay,
                IncreaseDayWithoutEvent);
            Hour = hour;
            OnTimeChanged();
        }

        private void IncrementTimeIfNeeded(ref int timeNumber, int compareToTime, Action actionToExecuteIfNeeded)
        {
            if (timeNumber >= compareToTime)
            {
                actionToExecuteIfNeeded?.Invoke();
                timeNumber = 0;
            }
        }

        private void IncreaseHourWithoutEvent()
        {
            int hour = ++Hour;
            IncrementTimeIfNeeded(ref hour,
                HoursPerDay,
                IncreaseDayWithoutEvent);
            Hour = hour;
        }

        public void IncreaseMinute()
        {
            int minute = ++Minute;
            IncrementTimeIfNeeded(ref minute,
                MinutesPerHour,
                IncreaseHourWithoutEvent);
            Minute = minute;
            OnTimeChanged();
        }


        protected virtual void OnTimeChanged(EventArgs e = null)
        {
            TimeChanged?.Invoke(this, e);
        }
    }
}
