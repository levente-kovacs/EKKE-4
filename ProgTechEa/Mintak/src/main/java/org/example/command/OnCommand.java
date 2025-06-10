package org.example.command;

public class OnCommand implements Command {
    Tv tv;
    OnCommand(Tv tv) {
        this.tv = tv;
    }

    @Override
    public void execute() {
        tv.turnOn();
    }

    @Override
    public void undo() {
        tv.turnOff();
    }
}
