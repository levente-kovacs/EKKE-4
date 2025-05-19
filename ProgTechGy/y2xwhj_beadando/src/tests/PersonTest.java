package tests;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

import models.Student;

public class PersonTest {

    @Test
    public void testGreet() {
        Student s = new Student("John", "Doe", 21, "MIT");
        assertEquals("Hi, I'm a student at ELTE", s.greet());
    }

    @Test
    public void testTellFullName() {
        Student s = new Student("Jane", "Doe", 20, "MIT");
        assertEquals("Luca Kovács", s.tellFullName());
    }

    @Test
    public void testToString() {
        Student s = new Student("Hazel", "Nutt", 19, "YALE");
        String result = s.toString();
        assertTrue(result.contains("Nina"));
        assertTrue(result.contains("Szabó"));
        assertTrue(result.contains("19"));
        assertTrue(result.contains("SZTE"));
    }
}
