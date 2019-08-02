using System;
using System.Collections.Generic;
using System.Text;
using GameOfBotLib.Interfaces;
using GameOfBotLib.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfBotLibTests
{

    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void IncreaseDayTest()
        {
            Time time = new Time();
            int startingDay = time.Day;
            time.IncreaseDay();
            Assert.AreEqual(startingDay + 1, time.Day);
        }

        [TestMethod]
        public void IncreaseHourTest()
        {
            Time time = new Time();
            int startingHour = time.Hour;
            time.IncreaseHour();
            Assert.AreEqual(startingHour + 1, time.Hour);
        }

        [TestMethod]
        public void IncreaseHourTest_NextDay()
        {
            Time time = new Time();
            int currentDay = time.Day;
            IncreaseHourToOneBeforeNextDay(time);
            int currentHour = time.Hour;
            Assert.AreEqual(23, currentHour);
            time.IncreaseHour();
            Assert.AreEqual(0, time.Hour);
            Assert.AreEqual(currentDay + 1, time.Day);
        }

        private void IncreaseHourToOneBeforeNextDay(Time time)
        {
            const int HourBeforeNextDay = 23;
            IncreaseToValue(HourBeforeNextDay,
                time.IncreaseHour,
                () => time.Hour);
            Assert.AreEqual(HourBeforeNextDay, time.Hour);
        }

        private void IncreaseToValue(int numberToIncreaseTo, Action increaseAction, Func<int> controlFunction)
        {
            while(controlFunction.Invoke() < numberToIncreaseTo)
            {
                increaseAction.Invoke();
            }
            Assert.AreEqual(numberToIncreaseTo, controlFunction.Invoke());
        }

        [TestMethod]
        public void IncreaseMinuteTest()
        {
            Time time = new Time();
            int currentMinute = time.Minute;
            time.IncreaseMinute();
            Assert.AreEqual(currentMinute + 1, time.Minute);
        }

        [TestMethod]
        public void IncreaseMinuteTest_NextHour()
        {
            Time time = new Time();
            int currentHour = time.Hour;
            IncreaseMinuteToOneBeforeNextHour(time);
            Assert.AreEqual(59, time.Minute);
            time.IncreaseMinute();
            Assert.AreEqual(0, time.Minute);
            Assert.AreEqual(currentHour + 1, time.Hour);
        }

        private void IncreaseMinuteToOneBeforeNextHour(Time time)
        {
            const int MinuteBeforeNextHour = 59;
            IncreaseToValue(MinuteBeforeNextHour,
                time.IncreaseMinute,
                () => time.Minute);
            Assert.AreEqual(MinuteBeforeNextHour, time.Minute);
        }

        [TestMethod]
        public void IncreaseMinuteTest_NextDay()
        {
            Time time = new Time();
            int currentDay = time.Day;
            IncreaseHourToOneBeforeNextDay(time);
            IncreaseMinuteToOneBeforeNextHour(time);
            time.IncreaseMinute();
            Assert.AreEqual(currentDay + 1, time.Day);
        }
    }
}
