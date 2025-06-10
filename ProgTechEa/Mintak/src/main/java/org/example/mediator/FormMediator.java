package org.example.mediator;

public class FormMediator implements  Mediator {
    private Button button;
    private Text text;

    public FormMediator(Button button, Text text) {
        this.button = button;
        this.text = text;
    }

    @Override
    public void notify(Component sender) {
        if(text.state != null && sender instanceof Button) {
            System.out.println("Form was send with state " + sender.state);
        }
        else if(text.state == null && sender instanceof Button) {
            System.out.println("Error");
        }
    }
}
