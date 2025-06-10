package org.example.factory;

public abstract class BaseUser {
    String role;
    public BaseUser(String role) {
        this.role = role;
    }

    public String getRole() {
        return role;
    }
    public void setRole(String role) {
        this.role = role;
    }
}
