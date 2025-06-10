package org.example.visitor;

public class Cv implements Visitable {
    String content;
    public Cv(String content) {
        this.content = content;
    }

    @Override
    public void accept(Visitor visitor) {
        visitor.visitCv(this);
    }
}
