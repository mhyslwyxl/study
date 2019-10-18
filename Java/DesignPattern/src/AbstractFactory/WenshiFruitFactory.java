package AbstractFactory;

public class WenshiFruitFactory implements FruitFactory {

    public Fruit getApple() {
        return new WeishiApple();
    }

    public Fruit getBanana() {
        return new WenshiBanana();
    }
}
