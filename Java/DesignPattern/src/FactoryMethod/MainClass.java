package FactoryMethod;

public class MainClass {
    public static void main(String args[]) throws InstantiationException, IllegalAccessException {
        System.out.println("Factory Method:");
        FruitFactory ff = new AppleFactory();
        Fruit apple = ff.getFruit();
        apple.get();
        FruitFactory ff2 = new BananaFactory();
        Fruit banana = ff2.getFruit();
        banana.get();
    }
}
