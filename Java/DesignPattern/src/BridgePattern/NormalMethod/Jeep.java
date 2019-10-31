package BridgePattern.NormalMethod;

public class Jeep extends Car {

    public Jeep(Engine engine) {
        super(engine);
    }

    public void installEngine() {
        System.out.println("Jeep:");
        this.getEngine().installEngine();
    }
}
