package org.example.abstractFactory;

public abstract class Processor {
    String name;
    public Processor(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }
}
