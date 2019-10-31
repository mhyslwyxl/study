package ProxyPattern;

import java.util.HashMap;
import java.util.Map;

public class Bookstore {


    private ConcreteBook concreteBook = new ConcreteBook();


    public void sellBook(String name) {
        concreteBook.sellBook(name);
        SellLog.LogBook(name);
    }

    public void display() {
        SellLog.display();
    }
}
