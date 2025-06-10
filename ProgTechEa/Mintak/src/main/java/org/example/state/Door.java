package org.example.state;

public class Door {
    State state;
    public Door() {
        this.state = new DoorCloseState(this);
    }
    public State getState() {
        return state;
    }
    public void setState(State state) {
        this.state = state;
    }
}
