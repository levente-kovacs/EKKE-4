package org.example.mediator;

public abstract class Component {
    String state;
    protected Mediator mediator;
    public Component(Mediator mediator) {
        this.mediator = mediator;
    }

    public String getState() {
        return state;
    }
    public void setState(String state) {
        this.state = state;
    }
}
