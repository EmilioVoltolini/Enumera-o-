using System;

namespace Project_050922.Entities
{
    class HourContract
    {
        public DateTime Date { get; set; }
        public Double ValuePerHour { get; set; }
        public int Hour { get; set; }

        public HourContract()
        {
        }
        public HourContract(DateTime date, double valuePerHour, int hour)
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hour = hour;
        }
        public double TotalValue()
        {
            return ValuePerHour * Hour;
        }
    }
}
