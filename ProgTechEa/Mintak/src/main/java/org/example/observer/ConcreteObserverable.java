package org.example.observer;

import java.util.ArrayList;
import java.util.List;

public class ConcreteObserverable implements Observerable {
    private List<Observer> observers;
    private String state;
    public ConcreteObserverable() {
        this.observers = new ArrayList<Observer>();
        this.state = "";
    }

    @Override
    public void subscribe(Observer o) {
        observers.add(o);
    }

    @Override
    public void unsubscribe(Observer o) {
        observers.remove(o);
    }

    @Override
    public void notifyObservers() {
        for (Observer o : observers) {
            o.update();
        }
    }

    public void setState(String state) {
        this.state = state;
        notifyObservers();
    }
    @Override
    public String getState() {
        return state;
    }
}
