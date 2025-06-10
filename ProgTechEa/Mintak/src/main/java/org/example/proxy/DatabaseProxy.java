package org.example.proxy;

import java.util.ArrayList;
import java.util.List;

public class DatabaseProxy implements DatabaseService {
    DatabaseService db;
    private List<Middleware> m;
    public DatabaseProxy(DatabaseService db) {
        this.db = db;
        m = new ArrayList<>();
        m.add(new BaseMiddleware() {});
    }

    @Override
    public void insert(Model model) {

    }

    @Override
    public void update(Integer id, Model model) {

    }

    @Override
    public void delete(Integer id) {

    }
    boolean checkEligibility() {
        for (Middleware m : m) {
            if(!m.checkEligibility())
               return false;
        }
        return true;
    }
}
