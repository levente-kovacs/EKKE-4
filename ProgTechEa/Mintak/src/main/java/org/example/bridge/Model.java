package org.example.bridge;

public class Model implements  Resource {

    @Override
    public String getHTML() {
        return "this model has been loaded";
    }
}
