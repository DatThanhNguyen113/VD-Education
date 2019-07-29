package com.example.vdandroid.Model;

public class TimeTableModel {
    private int subject_id;
    private String subject_name;
    private String teacher_name;
    private String date;
    private String day;
    private String room;
    private String session;
    private String lesson_number;
    private String from_date;
    private int from_week;
    private String to_date;
    private int to_week;

    public int getSubject_id() {
        return subject_id;
    }

    public void setSubject_id(int subject_id) {
        this.subject_id = subject_id;
    }

    public String getSubject_name() {
        return subject_name;
    }

    public void setSubject_name(String subject_name) {
        this.subject_name = subject_name;
    }

    public String getTeacher_name() {
        return teacher_name;
    }

    public void setTeacher_name(String teacher_name) {
        this.teacher_name = teacher_name;
    }

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public String getDay() {
        return day;
    }

    public void setDay(String day) {
        this.day = day;
    }

    public String getRoom() {
        return room;
    }

    public void setRoom(String room) {
        this.room = room;
    }

    public String getSession() {
        return session;
    }

    public void setSession(String session) {
        this.session = session;
    }

    public String getLesson_number() {
        return lesson_number;
    }

    public void setLesson_number(String lesson_number) {
        this.lesson_number = lesson_number;
    }

    public String getFrom_date() {
        return from_date;
    }

    public void setFrom_date(String from_date) {
        this.from_date = from_date;
    }

    public int getFrom_week() {
        return from_week;
    }

    public void setFrom_week(int from_week) {
        this.from_week = from_week;
    }

    public String getTo_date() {
        return to_date;
    }

    public void setTo_date(String to_date) {
        this.to_date = to_date;
    }

    public int getTo_week() {
        return to_week;
    }

    public void setTo_week(int to_week) {
        this.to_week = to_week;
    }
}
