package org.example.template;

public abstract class Model {

    public Model(){
        onInit();
    }

    public final void save(){
        beforeSave();
        System.out.println("SaveToDatabase");
        afterSave();
    }
    public void onInit(){

    }
    public void beforeSave(){

    }
    public void afterSave(){

    }
    public void onDestroy(){

    }
    public void delete(){
        onDestroy();
    }

}
