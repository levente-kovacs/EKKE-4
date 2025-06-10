package org.example.facade;

import java.util.ArrayList;
import java.util.List;

public class HouseFacade {
    public House buildHouse(int numberOfRooms){
        List<Room> rooms = new ArrayList<Room>();
        for (int i = 0; i < numberOfRooms; i++) {
            rooms.add(new Room());
        }
        return new House(new Door(),rooms);
    }
}
