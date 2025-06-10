package org.example.builder;

public class Profile {
    String name;
    String description;
    String address;
    public Profile(ProfileBuilder builder) {
        this.name = builder.name;
        this.description = builder.description;
        this.address = builder.address;
    }
}
