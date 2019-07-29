package com.example.vdandroid.Model;

public class RegistedSubjectModel {
    private String TeacherName;
    private String Code;
    private String Name;
    private int TotalCredits;
    private int TheoryCredit;
    private int PracticeCredit;
    private int LessionNumber;
    private int FinalEvaluationPercent;
    private String DiligencePercent;

    public RegistedSubjectModel() {

    }

    public String getTeacherName() {
        return TeacherName;
    }

    public void setTeacherName(String teacherName) {
        TeacherName = teacherName;
    }

    public String getCode() {
        return Code;
    }

    public void setCode(String code) {
        Code = code;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public int getTotalCredits() {
        return TotalCredits;
    }

    public void setTotalCredits(int totalCredits) {
        TotalCredits = totalCredits;
    }

    public int getTheoryCredit() {
        return TheoryCredit;
    }

    public void setTheoryCredit(int theoryCredit) {
        TheoryCredit = theoryCredit;
    }

    public int getPracticeCredit() {
        return PracticeCredit;
    }

    public void setPracticeCredit(int practiceCredit) {
        PracticeCredit = practiceCredit;
    }

    public int getLessionNumber() {
        return LessionNumber;
    }

    public void setLessionNumber(int lessionNumber) {
        LessionNumber = lessionNumber;
    }

    public int getFinalEvaluationPercent() {
        return FinalEvaluationPercent;
    }

    public void setFinalEvaluationPercent(int finalEvaluationPercent) {
        FinalEvaluationPercent = finalEvaluationPercent;
    }

    public String getDiligencePercent() {
        return DiligencePercent;
    }

    public void setDiligencePercent(String diligencePercent) {
        DiligencePercent = diligencePercent;
    }
}
