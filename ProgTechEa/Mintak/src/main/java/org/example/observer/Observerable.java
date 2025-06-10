package org.example.observer;

public interface Observerable {
    void subscribe(Observer o);
    void unsubscribe(Observer o);
    void notifyObservers();
    String getState();
}
