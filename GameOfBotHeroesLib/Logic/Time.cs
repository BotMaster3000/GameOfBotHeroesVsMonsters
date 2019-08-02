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

        public void IncreaseDay()
        {
            ++Day;
        }

        public void IncreaseHour()
        {
            ++Hour;
            if(Hour >= HoursPerDay)
            {
                Hour = 0;
                IncreaseDay();
            }
        }

        public void IncreaseMinute()
        {
            ++Minute;
            if(Minute >= MinutesPerHour)
            {
                Minute = 0;
                IncreaseHour();
            }
        }
    }
}
