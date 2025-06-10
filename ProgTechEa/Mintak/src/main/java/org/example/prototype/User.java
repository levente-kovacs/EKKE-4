package org.example.prototype;

public class User extends Model {
    protected String name;
    public User(String name){
        this.name = name;
    }
    public User(User u){
        super(u);
        this.name = u.getName();
    }
    @Override
    public Model clone(){
        return new User(this);
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
