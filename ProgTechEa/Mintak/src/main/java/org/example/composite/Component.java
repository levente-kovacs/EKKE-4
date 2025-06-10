package org.example.composite;

import java.util.ArrayList;
import java.util.List;

public abstract class Component {
    List<Component> childComponents;
    String html;
    public Component(String html) {
        this.html = html;
        this.childComponents = new ArrayList<>();
    }
    public void addChild(Component child) {
        childComponents.add(child);
    }
    public void removeChild(Component child) {
        childComponents.remove(child);
    }
    public String render(){
        String content = "";
        for(Component child : childComponents){
            content += child.render();
        }
        return content;
    }
}
