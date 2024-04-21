using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loteria.Tables
{
    public class Result
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        public DateTime LotteryDay { get; set; }
        public string Numbers { get; set; }
        public int NumberOfWinners { get; set; }

        public Result() { }
        public Result(int id, DateTime lotteryDay, string numbers, int numberOfWinners)
        {
            Id = id;
            LotteryDay = lotteryDay;
            Numbers = numbers;
            NumberOfWinners = numberOfWinners;
        }
        public Result(DateTime lotteryDay, string numbers, int numberOfWinners)
        {
            LotteryDay = lotteryDay;
            Numbers = numbers;
            NumberOfWinners = numberOfWinners;
        }
    }
}
