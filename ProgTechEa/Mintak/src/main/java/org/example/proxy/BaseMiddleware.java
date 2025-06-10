package org.example.proxy;

public class BaseMiddleware implements Middleware {

    @Override
    public boolean checkEligibility() {
        return true;
    }
}
