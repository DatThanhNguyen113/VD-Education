package com.example.vdandroid.API;

import android.app.Application;

public class UserInfoBuffer extends Application {
    private String ID;
    private String Session;
    private int Role_ID;
    private String Role_Code;
    private String Role_Name;

    public String getRole_Code() {
        return Role_Code;
    }

    public void setRole_Code(String role_Code) {
        Role_Code = role_Code;
    }

    public String getRole_Name() {
        return Role_Name;
    }

    public void setRole_Name(String role_Name) {
        Role_Name = role_Name;
    }

    public int getRole_ID() {
        return Role_ID;
    }

    public void setRole_ID(int role_ID) {
        Role_ID = role_ID;
    }

    public String getID() {
        return ID;
    }

    public String getSession() {
        return Session;
    }

    public void setID(String ID) {
        this.ID = ID;
    }

    public void setSession(String session) {
        Session = session;
    }

    public UserInfoBuffer(){
        this.setSession("");
    }
}
