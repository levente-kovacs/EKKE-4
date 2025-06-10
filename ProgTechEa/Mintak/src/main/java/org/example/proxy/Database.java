package org.example.proxy;

import java.util.HashMap;

public class Database implements DatabaseService{
    private static Integer key = 0;
    HashMap<Integer,Model> db;

    @Override
    public void insert(Model model) {
        key++;
        this.db.put(key,model);
    }

    @Override
    public void update(Integer key, Model model) {
        this.db.put(key,model);
    }

    @Override
    public void delete(Integer id) {
        this.db.remove(id);
    }
}
