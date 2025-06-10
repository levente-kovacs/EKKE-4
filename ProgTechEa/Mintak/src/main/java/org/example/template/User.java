package org.example.template;

public class User extends Model{
    @Override
    public void onInit() {
        System.out.println("onInit");
    }

    @Override
    public void beforeSave() {
        System.out.println("beforeSave");
    }

    @Override
    public void afterSave() {
        System.out.println("afterSave");
    }

    @Override
    public void onDestroy() {
        System.out.println("onDestroy");
    }
}
