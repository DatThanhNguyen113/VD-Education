package com.example.vdandroid.Model;

public class FinishDateModel {
    private String Week;
    private String FinishDate;

    public FinishDateModel(){

    }

    public FinishDateModel(String week, String finishDate) {
        Week = week;
        FinishDate = finishDate;
    }

    public String getWeek() {
        return Week;
    }

    public void setWeek(String week) {
        Week = week;
    }

    public String getFinishDate() {
        return FinishDate;
    }

    public void setFinishDate(String finishDate) {
        FinishDate = finishDate;
    }
}
