package org.example.proxy;

public interface DatabaseService {
    void insert(Model model);
    void update(Integer id, Model model);
    void delete(Integer id);
}
