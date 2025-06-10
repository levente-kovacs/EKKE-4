package org.example.visitor;

public class User  implements Visitable {
    String name;
    String email;
    public User(String name, String email) {
        this.name = name;
        this.email = email;
    }

    @Override
    public void accept(Visitor visitor) {
        visitor.visitUser(this);
    }
}
