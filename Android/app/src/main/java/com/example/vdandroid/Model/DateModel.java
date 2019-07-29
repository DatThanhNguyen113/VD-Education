package com.example.vdandroid.Model;

public class DateModel {
    private String Date;
    private String Day;

    public DateModel(String date, String day) {
        Date = date;
        Day = day;
    }

    public String getDate() {
        return Date;
    }

    public void setDate(String date) {
        Date = date;
    }

    public String getDay() {
        return Day;
    }

    public void setDay(String day) {
        Day = day;
    }
}
