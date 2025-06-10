package org.example.chainOfResponsibility;

public abstract class OperationHandler implements Handle{
    Handle handler;
    public OperationHandler(Handle handler){
        this.handler = handler;
    }
}
