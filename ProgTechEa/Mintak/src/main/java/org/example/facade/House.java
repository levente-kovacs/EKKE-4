package org.example.facade;

import java.util.List;

public class House {
    List<Room> rooms;
    Door door;
    public House(Door door, List<Room> rooms) {
        this.door = door;
        this.rooms = rooms;
    }
}
