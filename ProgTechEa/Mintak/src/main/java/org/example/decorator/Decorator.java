package org.example.decorator;

public abstract class Decorator extends Text {
    protected Text txt;
    public Decorator(Text text) {
        super(text.getText());
        this.txt = text;
    }
}
