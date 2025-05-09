package models;
import interfaces.Talk;

public class Person implements Talk {
    private String firstName;
    private String lastName;
    private int age;
    
    public Person(String firstName, String lastName, int age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public String getFirstName() {
        return this.firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return this.lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public int getAge() {
        return this.age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    @Override
    public String toString() {
        return String.format("First name:\t%s\nLast name:\t%s\nAge:\t\t%d", firstName, lastName, age);
    }

    @Override
    public String greet() {
        return "Hi! Nice to meet you!";
    }

    @Override
    public String tellFullName() {
        return String.format("I am %s %s.", firstName, lastName);
    }

    @Override
    public String tellAge() {
        return String.format("I'm %d years old.", age);
    }

}
