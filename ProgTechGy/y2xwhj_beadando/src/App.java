import models.Person;
import models.Student;

public class App {
    public static void main(String[] args) throws Exception {
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
