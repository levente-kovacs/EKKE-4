package org.example.adapter;

public class Model {
    DatabaseService ds;
    public Model(DatabaseService ds){
        this.ds = ds;
    }
    public void save(){
        ds.save(this);
    }
}
