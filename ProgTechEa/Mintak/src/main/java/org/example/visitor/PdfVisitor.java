package org.example.visitor;

public class PdfVisitor implements Visitor {
    @Override
    public void visitUser(User user) {
        System.out.println("user data converted to PDF");
    }

    @Override
    public void visitCv(Cv cv) {
        System.out.println("cv data converted to PDF");
    }
}
