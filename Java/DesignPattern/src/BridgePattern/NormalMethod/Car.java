package BridgePattern.NormalMethod;

public abstract class Car {
    private Engine engine;

    public Car(Engine engine) {
        this.engine = engine;
    }

    public abstract void installEngine();

    public Engine getEngine() {
        return engine;
    }
}
