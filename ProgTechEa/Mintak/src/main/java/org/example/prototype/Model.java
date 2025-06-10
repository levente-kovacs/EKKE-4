package org.example.prototype;

public abstract class Model implements Prototype {
    private static int id = 0;
    protected int currentId = id;
    public Model(){this.currentId = id++;}
    protected Model(Model m){
        this.currentId = id++;
    }
    @Override
    public abstract Model clone();
    public int getId(){return currentId;}
}
