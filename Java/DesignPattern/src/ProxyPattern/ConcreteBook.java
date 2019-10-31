package ProxyPattern;

import java.util.HashMap;
import java.util.Map;

public class ConcreteBook implements Book {

    @Override
    public void sellBook(String name) {
        System.out.println("买了一本书，" + name);
    }
}
