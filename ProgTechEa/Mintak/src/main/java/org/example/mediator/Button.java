package org.example.mediator;

public class Button extends Component implements OnClickEvent{
    public Button(Mediator mediator) {
        super(mediator);
    }
    @Override
    public void onClickEvent() {
        mediator.notify(this);
    }
}
