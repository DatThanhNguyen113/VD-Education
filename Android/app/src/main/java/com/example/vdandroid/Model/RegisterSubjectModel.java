package com.example.vdandroid.Model;

public class RegisterSubjectModel {
    private int master_timetable_id;
    private int subject_id;
    private String teacher_name;
    private String code;
    private String name;
    private int total_credits;
    private int practice_credit;
    private int theory_credit;
    private int lession_number;
    private int final_evaluation_percent;
    private int semi_final_evaluation_percent;
    private String diligence_percent;
    private int status;

    public int getStatus() {
        return status;
    }

    public void setStatus(int status) {
        this.status = status;
    }

    public int getMaster_timetable_id() {
        return master_timetable_id;
    }

    public void setMaster_timetable_id(int master_timetable_id) {
        this.master_timetable_id = master_timetable_id;
    }

    public int getSubject_id() {
        return subject_id;
    }

    public void setSubject_id(int subject_id) {
        this.subject_id = subject_id;
    }

    public String getTeacher_name() {
        return teacher_name;
    }

    public void setTeacher_name(String teacher_name) {
        this.teacher_name = teacher_name;
    }

    public String getCode() {
        return code;
    }

    public void setCode(String code) {
        this.code = code;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getTotal_credits() {
        return total_credits;
    }

    public void setTotal_credits(int total_credits) {
        this.total_credits = total_credits;
    }

    public int getPractice_credit() {
        return practice_credit;
    }

    public void setPractice_credit(int practice_credit) {
        this.practice_credit = practice_credit;
    }

    public int getTheory_credit() {
        return theory_credit;
    }

    public void setTheory_credit(int theory_credit) {
        this.theory_credit = theory_credit;
    }

    public int getLession_number() {
        return lession_number;
    }

    public void setLession_number(int lession_number) {
        this.lession_number = lession_number;
    }

    public int getFinal_evaluation_percent() {
        return final_evaluation_percent;
    }

    public void setFinal_evaluation_percent(int final_evaluation_percent) {
        this.final_evaluation_percent = final_evaluation_percent;
    }

    public int getSemi_final_evaluation_percent() {
        return semi_final_evaluation_percent;
    }

    public void setSemi_final_evaluation_percent(int semi_final_evaluation_percent) {
        this.semi_final_evaluation_percent = semi_final_evaluation_percent;
    }

    public String getDiligence_percent() {
        return diligence_percent;
    }

    public void setDiligence_percent(String diligence_percent) {
        this.diligence_percent = diligence_percent;
    }

    public RegisterSubjectModel(){

    }
}
