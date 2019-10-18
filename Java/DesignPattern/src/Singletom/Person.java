package Singletom;

public class Person {
    private String name;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    private Person() {
    }

    private static volatile Person instance = null;

    public static synchronized Person getInstance() {
        if (instance == null)
            instance = new Person();
        return instance;
    }
}
