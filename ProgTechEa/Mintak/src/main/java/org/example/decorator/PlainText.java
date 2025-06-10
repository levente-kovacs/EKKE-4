package org.example.decorator;

public class PlainText extends Text{
    public PlainText(String text) {super(text);}
    @Override
    public String getText() {
        return this.text;
    }
}
