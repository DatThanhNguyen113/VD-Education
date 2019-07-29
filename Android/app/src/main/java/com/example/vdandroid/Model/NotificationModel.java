package com.example.vdandroid.Model;

public class NotificationModel {
    private String body;
    private String create_date;
    private int id;
    private String path;
    private String receiver_name;
    private String subject;
    private int type;

    public NotificationModel(String body, String create_date, int id, String path, String receiver_name, String subject, int type) {
        this.body = body;
        this.create_date = create_date;
        this.id = id;
        this.path = path;
        this.receiver_name = receiver_name;
        this.subject = subject;
        this.type = type;
    }

    public NotificationModel(){

    }

    public String getBody() {
        return body;
    }

    public void setBody(String body) {
        this.body = body;
    }

    public String getCreate_date() {
        return create_date;
    }

    public void setCreate_date(String create_date) {
        this.create_date = create_date;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getPath() {
        return path;
    }

    public void setPath(String path) {
        this.path = path;
    }

    public String getReceiver_name() {
        return receiver_name;
    }

    public void setReceiver_name(String receiver_name) {
        this.receiver_name = receiver_name;
    }

    public String getSubject() {
        return subject;
    }

    public void setSubject(String subject) {
        this.subject = subject;
    }

    public int getType() {
        return type;
    }

    public void setType(int type) {
        this.type = type;
    }
}
