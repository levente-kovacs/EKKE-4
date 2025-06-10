package org.example.state;

public class DoorOpenState implements State {
    private Door door;
    public DoorOpenState(Door door) {
        this.door = door;
    }

    @Override
    public void open() {
        System.out.println("Door already open");
    }

    @Override
    public void close() {
        door.setState(new DoorCloseState(door));
    }
}
