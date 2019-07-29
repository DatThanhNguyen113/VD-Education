package com.example.vdandroid.Model;

public class TeacherModel {
    private String id;
    private String name;
    private String email;
    private String birth_date;
    private String work_unit;

    public String getWork_unit() {
        return work_unit;
    }

    public void setWork_unit(String work_unit) {
        this.work_unit = work_unit;
    }

    private String graduating;
    private String diploma;
    private String bank_account_number;
    private int bank_id;
    private String description;
    private int role;

    public TeacherModel(){

    }

    public TeacherModel(String id, String name, String email, String birth_date, String graduating, String diploma, String bank_account_number, int bank_id, String description, int role) {
        this.id = id;
        this.name = name;
        this.email = email;
        this.birth_date = birth_date;
        this.graduating = graduating;
        this.diploma = diploma;
        this.bank_account_number = bank_account_number;
        this.bank_id = bank_id;
        this.description = description;
        this.role = role;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getBirth_date() {
        return birth_date;
    }

    public void setBirth_date(String birth_date) {
        this.birth_date = birth_date;
    }

    public String getGraduating() {
        return graduating;
    }

    public void setGraduating(String graduating) {
        this.graduating = graduating;
    }

    public String getDiploma() {
        return diploma;
    }

    public void setDiploma(String diploma) {
        this.diploma = diploma;
    }

    public String getBank_account_number() {
        return bank_account_number;
    }

    public void setBank_account_number(String bank_account_number) {
        this.bank_account_number = bank_account_number;
    }

    public int getBank_id() {
        return bank_id;
    }

    public void setBank_id(int bank_id) {
        this.bank_id = bank_id;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public int getRole() {
        return role;
    }

    public void setRole(int role) {
        this.role = role;
    }
}
