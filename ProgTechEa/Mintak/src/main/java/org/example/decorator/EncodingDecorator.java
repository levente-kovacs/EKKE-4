package org.example.decorator;

public class EncodingDecorator extends Decorator {

    public EncodingDecorator(Text text) {
        super(text);
    }
    @Override
    public String getText() {
        String encodedText = "";
        for (Character character : this.text.toCharArray()) {
            encodedText += "#";
        }
        return encodedText;
    }
}
