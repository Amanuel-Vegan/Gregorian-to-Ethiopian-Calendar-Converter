using Converter.Application.Interface.IConverter;
using System;

namespace Converter.Application.Service
{
    public class ConverterService : IConverter
    {
        private const int EthiopianStartYear = 8;
        private const int EthiopianStartMonth = 9;
        private const int EthiopianStartDay = 11;
        private const int EthiopianMonthLength = 30;

        public string ConvertToEthiopianDate(DateTime gregorianDate)
        {
            int ethiopianYear = GetEthiopianYear(gregorianDate);
            (int ethiopianMonth, int ethiopianDay) = GetEthiopianMonthAndDay(gregorianDate);

            return ($"{ethiopianDay}/{ethiopianMonth}/{ethiopianYear}");
        }

        private int GetEthiopianYear(DateTime gregorianDate)
        {
            int gregorianYear = gregorianDate.Year;
            int ethiopianYear;

            if (gregorianDate < new DateTime(gregorianYear, EthiopianStartMonth, EthiopianStartDay))
            {
                ethiopianYear = gregorianYear - EthiopianStartYear;
            }
            else
            {
                ethiopianYear = gregorianYear - (EthiopianStartYear - 1);
            }

            return ethiopianYear;
        }

        private (int month, int day) GetEthiopianMonthAndDay(DateTime gregorianDate)
        {
            int gregorianYear = gregorianDate.Year;
            int gregorianMonth = gregorianDate.Month;
            int gregorianDay = gregorianDate.Day;

            int ethiopianMonth;
            int ethiopianDay;
            // The Ethiopian calendar has 13 months, with 12 months of 30 days and one month of 5 or 6 days.
            if (gregorianDate < new DateTime(gregorianYear, EthiopianStartMonth, EthiopianStartDay))
            {
                // If the Gregorian date is before the Ethiopian new year, we add the offset to the month and day.
                ethiopianMonth = gregorianMonth + 3;
                ethiopianDay = gregorianDay + (EthiopianMonthLength - EthiopianStartDay + 1);
            }
            else
            {
                // If the Gregorian date is after the Ethiopian new year, we subtract the offset from the month and day.
                ethiopianMonth = gregorianMonth - 9;
                ethiopianDay = gregorianDay - EthiopianStartDay + 1;
            }

            // If the Ethiopian day is negative, it means it is in the previous month.
            if (ethiopianDay <= 0)
            {
                ethiopianMonth--;
                ethiopianDay += EthiopianMonthLength;
            }

            // If the Ethiopian month is greater than 13, it means it is in the next year.
            if (ethiopianMonth > 13)
            {
                ethiopianMonth -= 13;
            }

            return (ethiopianMonth, ethiopianDay);
        }
    }
}
