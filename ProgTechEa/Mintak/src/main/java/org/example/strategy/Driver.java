package org.example.strategy;

public abstract class Driver {
    protected String name;
    DriverBehaviour driverBehaviour;
    public Driver(String name) {
        this.name = name;
    }

    public DriverBehaviour getDriverBehaviour() {
        return driverBehaviour;
    }

    public void setDriverBehaviour(DriverBehaviour driverBehaviour) {
        this.driverBehaviour = driverBehaviour;
    }
    public String drive(){
        return this.driverBehaviour.drive();
    }
}
