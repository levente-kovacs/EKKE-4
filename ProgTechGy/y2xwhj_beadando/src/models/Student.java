package models;

public class Student extends Person {

    private String school;

    public String getSchool() {
        return this.school;
    }

    public void setSchool(String school) {
        this.school = school;
    }

    public Student(String firstName, String lastName, int age, String school) {
        super(firstName, lastName, age);
        this.school = school;
    }
    
}
