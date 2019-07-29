package com.example.vdandroid.Model;

public class LessonModel {
    private String LessonName;
    private String Description;

    public LessonModel(String lessonName, String description) {
        LessonName = lessonName;
        Description = description;
    }

    public String getLessonName() {
        return LessonName;
    }

    public void setLessonName(String lessonName) {
        LessonName = lessonName;
    }

    public String getDescription() {
        return Description;
    }

    public void setDescription(String description) {
        Description = description;
    }
}
