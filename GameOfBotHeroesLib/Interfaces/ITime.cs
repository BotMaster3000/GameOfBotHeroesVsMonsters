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

        void IncreaseDay();
        void IncreaseHour();
        void IncreaseMinute();
    }
}
