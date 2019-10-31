package ProxyPattern;

import java.util.HashMap;
import java.util.Map;

public class SellLog {

    private static Map<String, Integer> sellList = new HashMap<String, Integer>();

    public static void LogBook(String name) {
        if (!sellList.containsKey(name))
            sellList.put(name, 1);
        else
            sellList.put(name, sellList.get(name) + 1);
    }

    public static void display() {

        for (String key : sellList.keySet()) {
            System.out.println(key + "  " +
                    sellList.get(key));
        }
    }
}
