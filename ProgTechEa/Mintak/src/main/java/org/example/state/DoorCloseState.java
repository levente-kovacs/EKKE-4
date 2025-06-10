package org.example.state;

public class DoorCloseState implements State {
    Door door;
    public DoorCloseState(Door door) {
        this.door = door;
    }

    @Override
    public void open() {
        door.setState(new DoorOpenState(door));
    }

    @Override
    public void close() {
        System.out.println("Door already closed");
    }
}
