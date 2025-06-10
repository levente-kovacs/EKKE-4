package org.example.visitor;

public interface Visitor {
    void visitUser(User user);
    void visitCv(Cv cv);
}
