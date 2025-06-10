package org.example.mediator;

public class Text extends Component implements OnStateChangeEvent{

    public Text(Mediator mediator) {
        super(mediator);
    }

    @Override
    public void onStateChangeEvent() {
        mediator.notify(this);
    }
}
