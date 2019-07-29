package com.example.vdandroid.Model;

public class LoginModel {

    private String ID;
    private int Role_ID;
    private String Role_Code;
    private String Role_Name;
    private String Sign_In_Session;

    public LoginModel(){

    }

    public LoginModel(String ID, int role_ID, String role_Code, String role_Name, String sign_In_Session) {
        this.ID = ID;
        Role_ID = role_ID;
        Role_Code = role_Code;
        Role_Name = role_Name;
        Sign_In_Session = sign_In_Session;
    }

    public String getID() {
        return ID;
    }

    public void setID(String ID) {
        this.ID = ID;
    }

    public int getRole_ID() {
        return Role_ID;
    }

    public void setRole_ID(int role_ID) {
        Role_ID = role_ID;
    }

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

    public String getSign_In_Session() {
        return Sign_In_Session;
    }

    public void setSign_In_Session(String sign_In_Session) {
        Sign_In_Session = sign_In_Session;
    }
}
