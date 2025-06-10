package org.example.observer;

public class ConcreteObserver implements Observer {
    Observerable observerable;
    public ConcreteObserver(Observerable observerable) {
        this.observerable = observerable;
    }

    @Override
    public void update() {
        System.out.println("observer update "+ observerable.getState());
    }

}
