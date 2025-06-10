package org.example.adapter;

public class DatabaseAdapter implements DatabaseService {
    Orm db;
    public DatabaseAdapter(Orm db){
        this.db = db;
    }

    @Override
    public void save(Model m) {
        db.saveToDatabase(m);
    }
}
