package y2xwhj_pt_beadando;

import y2xwhj_pt_beadando.models.Person;
import y2xwhj_pt_beadando.models.Student;

public class Main {
    public static void main(String[] args) {
        System.out.println("Hello, World!");
        Person person = new Person("John", "Doe", 30);
        System.out.println(person.toString());
        System.out.println(person.greet());
        System.out.println(person.tellFullName());
        System.out.println(person.tellAge());
        Student student = new Student("Hazel", "Nutt", 16, "Northwood Academy");
        System.out.println(student.toString());
    }
}