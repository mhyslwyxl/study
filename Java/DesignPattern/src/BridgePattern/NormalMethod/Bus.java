package BridgePattern.NormalMethod;

public class Bus extends Car {

    public Bus(Engine engine) {
        super(engine);
    }


    public void installEngine() {
        System.out.println("Bus:");
        this.getEngine().installEngine();
    }
}
