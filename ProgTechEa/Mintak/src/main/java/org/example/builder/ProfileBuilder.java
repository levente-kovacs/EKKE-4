package org.example.builder;

public class ProfileBuilder {
    String name;
    String description;
    String address;
    public ProfileBuilder(String name) {
        this.name = name;
    }
    public ProfileBuilder description(String description) {
        this.description = description;
        return this;
    }
    public ProfileBuilder address(String address) {
        this.address = address;
        return this;
    }
    public Profile build() {
        return new Profile(this);
    }
}
