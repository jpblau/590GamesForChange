using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateAndTime {

    public int year;
    public int month;
    public int day;
    public int hour;
    public int minute;

    public DateAndTime(int day, int hour, int minute, int month, int year)
    {
        this.day = day;
        this.hour = hour;
        this.minute = minute;
        this.month = month;
        this.year = year;
    }

    public override string ToString()
    {
        //12:45 February 24, 2018
        return hour + ":" + minute + " " + month + " " + day + ", " + year;
    }
}
