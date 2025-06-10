package org.example.factory;

public class UserFactory extends Factory {
    @Override
    public BaseUser createUser() {
        return new GuestUser("guest");
    }
}
