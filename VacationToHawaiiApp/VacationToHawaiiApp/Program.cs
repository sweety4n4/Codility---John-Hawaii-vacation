using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;

public class VacationToHawaiiSchedule
{

    private int _day, _month, _year;

    private int _dayOfTheYear;

    private static int[] _numOfDaysInYear = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    public VacationToHawaiiSchedule(int dayOfTheYear, int year)
    {
        _day = 1;
        _month = 0;
        this._year = year;
        this._dayOfTheYear = dayOfTheYear;
    }


    private static bool IsLeapYear(int year)
    {
        bool isLeap = year % 4 == 0 || year % 100 == 0 || year % 400 == 0 ? true : false;

        return isLeap;
    }

    private static int GetTotalDays(int month, int year)
    {
        if (IsLeapYear(year) && month == 1)
        { // Feb
            return _numOfDaysInYear[month] + 1;
        }
        else
        {
            return _numOfDaysInYear[month];
        }
    }

    public void HolidayValidation()
    {
        _dayOfTheYear = (_dayOfTheYear + 1) % 7;
        _day++;
        int TotalDaysInMonth = GetTotalDays(_month, _year);

        if (_day > TotalDaysInMonth)
        {
            _day = 1;
            _month++;

            if (_month > 12)
            {
                _month = 0;
                _year++;
            }
        }
    }

    public int GetMonthPosition()
    {
        return _month;
    }
    public int GetDayOfMonthPosition()
    {
        return _dayOfTheYear;
    }

    public override string ToString()
    {
        return "Day " + _day + "Month " + _month + "Year " + _year + "dayOfYear " + _dayOfTheYear;
    }
}

class Solution
{

    private static string[] _months = {"January","February","March","April",
                        "May","June","July","August","September","October","November","December"};

    private static string[] _days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

    public static int solution(int Y, string A,
                    string B, string W)
    {
        VacationToHawaiiSchedule calendar = new VacationToHawaiiSchedule(Array.IndexOf(_days, W), Y);

        int StartIndex = Array.IndexOf(_months, A);
        int EndIndex = Array.IndexOf(_months, B);

        while ((calendar.GetMonthPosition() != StartIndex)
                                || (_days[calendar.GetDayOfMonthPosition()].ToLower() != ("Monday").ToLower()))
        {


            calendar.HolidayValidation();
        }

        int TotalDays = 0;
        while (calendar.GetMonthPosition() <= EndIndex)
        {
            TotalDays++;
            calendar.HolidayValidation();
        }

        return TotalDays / 7;
    }

}

public class MainClass
{

    public static void Main(String[] args)
    {
        //Console.WriteLine ("Hello World");
        Console.WriteLine(Solution.solution(2014, "April", "May", "Wednesday") + " weeks");
    }


}