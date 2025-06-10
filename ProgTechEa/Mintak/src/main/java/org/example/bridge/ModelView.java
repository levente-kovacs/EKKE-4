package org.example.bridge;

public class ModelView extends View {

    public ModelView(Resource resource) {
        super(resource);
    }
    public String rendet(){
       return  this.resource.getHTML();
    }
}
