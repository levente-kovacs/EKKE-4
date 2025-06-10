package org.example;

import org.example.decorator.EncodingDecorator;
import org.example.decorator.PlainText;
import org.example.decorator.Text;
import org.example.observer.ConcreteObserver;
import org.example.observer.ConcreteObserverable;
import org.example.observer.Observerable;
import org.example.observer.Observer;
//import org.example.prototype.User;
import org.example.strategy.DriverBehaviour;
import org.example.strategy.Driver;
import org.example.strategy.FormulaOneDriver;
import org.example.strategy.RaceDriverBehaviour;
import org.example.template.User;


//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        /*Text text = new PlainText("46546asdasd");
        Text encoded = new EncodingDecorator(text);
        System.out.println(encoded.getText());

        DriverBehaviour driverBehaviour = new RaceDriverBehaviour();
        Driver d = new FormulaOneDriver("Occon");
        d.setDriverBehaviour(driverBehaviour);
        System.out.println(d.drive());

        User u = new User("Juan");
        User u2 = (User)u.clone();
        System.out.println(u.getName());
        System.out.println(u2.getName());
        System.out.println(u == u2);
        System.out.println(u.getId());
        System.out.println(u2.getId());

        ConcreteObserverable o = new ConcreteObserverable();
        Observer observer = new ConcreteObserver(o);
        o.subscribe(observer);
        o.setState("Szia Ace!");*/

        User u = new User();
        u.save();
        u.delete();

    }
}