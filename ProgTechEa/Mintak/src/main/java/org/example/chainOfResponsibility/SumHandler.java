package org.example.chainOfResponsibility;

public class SumHandler extends OperationHandler {
public SumHandler(Handle handler){
    super(handler);
}

    @Override
    public int handle(int first, String operation, int second) {
        if(operation.equals("+")){
            return first + second;
        }
        return handler.handle(first, operation, second);
    }
}
