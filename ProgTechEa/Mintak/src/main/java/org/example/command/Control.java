package org.example.command;

public class Control {
    private Command onCommand;
    private Command offCommand;
    private Command undoCommand;
    public Control(Command onCommand, Command offCommand){
        this.onCommand = onCommand;
        this.offCommand = offCommand;
    }
    public void on(){
        onCommand.execute();
        undoCommand =  onCommand;
    }
    public void off(){
        offCommand.execute();
        undoCommand =  offCommand;
    }
    public void undo(){
        undoCommand.undo();
    }
}
