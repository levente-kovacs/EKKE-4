package org.example.proxy;

public abstract class Model {
    private Integer id;
    Model(Integer id) {
        this.id = id;
    }

    public Integer getId() {
        return id;
    }
}
