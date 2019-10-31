package BridgePattern.NormalMethod;

public class MainClass {
    public static void main(String[] args) {
        Engine e1 = new Engine2000();
        Car car1 = new Bus(e1);
        car1.installEngine();
    }
}
