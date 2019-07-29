package com.example.vdandroid.Model;

public class MusterModel {

    private int id;
    private String subject_name;
    private String student_name;
    private String student_id;
    private int join_status;
    private int timetable_id;
    private String title;

    public MusterModel(){

    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getSubject_name() {
        return subject_name;
    }

    public void setSubject_name(String subject_name) {
        this.subject_name = subject_name;
    }

    public String getStudent_name() {
        return student_name;
    }

    public void setStudent_name(String student_name) {
        this.student_name = student_name;
    }

    public String getStudent_id() {
        return student_id;
    }

    public void setStudent_id(String student_id) {
        this.student_id = student_id;
    }

    public int getJoin_status() {
        return join_status;
    }

    public void setJoin_status(int join_status) {
        this.join_status = join_status;
    }

    public int getTimetable_id() {
        return timetable_id;
    }

    public void setTimetable_id(int timetable_id) {
        this.timetable_id = timetable_id;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public MusterModel(int id, String subject_name, String student_name, String student_id, int join_status, int timetable_id, String title) {
        this.id = id;
        this.subject_name = subject_name;
        this.student_name = student_name;
        this.student_id = student_id;
        this.join_status = join_status;
        this.timetable_id = timetable_id;
        this.title = title;
    }
}
