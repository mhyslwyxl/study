package SimpleFactory;


public class FruitFactory {

    public static Fruit getApple() {
        return new Apple();
    }

    public static Fruit getBanana() {
        return new Banana();
    }

}
