package org.example.decorator;

public abstract class Text {
    protected String text;
    public Text(String text) {
        this.text = text;
    }
    public abstract String getText();
}
