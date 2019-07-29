package com.example.vdandroid.Model;

public class StartDateModel {
    private String Week;
    private String StartDate;

    public StartDateModel(){

    }

    public StartDateModel(String week, String startDate) {
        Week = week;
        StartDate = startDate;
    }

    public String getWeek() {
        return Week;
    }

    public void setWeek(String week) {
        Week = week;
    }

    public String getStartDate() {
        return StartDate;
    }

    public void setStartDate(String startDate) {
        StartDate = startDate;
    }
}
