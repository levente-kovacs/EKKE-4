package y2xwhj_pt_beadando;

import org.junit.jupiter.api.Test;

import y2xwhj_pt_beadando.models.Person;

import static org.junit.jupiter.api.Assertions.*;

public class PersonTest {

    @Test
    public void testGreet() {
        Person s = new Person("John", "Doe", 21);
        assertEquals("Hi! Nice to meet you!", s.greet());
    }

    @Test
    public void testTellFullName() {
        String firstName = "Jane";
        String lastName = "Doe";

        Person s = new Person(firstName, lastName, 20);
        assertEquals(String.format("I am %s %s.",firstName, lastName), s.tellFullName());
    }

    @Test
    public void testToString() {
        String firstName = "Hazel";
        String lastName = "Doe";
        int age = 16;

        Person s = new Person(firstName, lastName, age);
        String result = s.toString();
        assertTrue(result.contains(String.format("First name:\t%s", firstName)));
        assertTrue(result.contains(String.format("Last name:\t%s", lastName)));
        assertTrue(result.contains(String.format("Age:\t\t%d", age)));
    }

}

//  Mentő kérdés: statégia, gof1, gof2, ocp + test írás