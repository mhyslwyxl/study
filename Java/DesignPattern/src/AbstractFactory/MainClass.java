package AbstractFactory;

public class MainClass {
    public static void main(String args[]) {
        System.out.println("Abstract Factory");
        FruitFactory ff = new NorthFruitFactory();
        Fruit north_apple = ff.getApple();
        north_apple.get();
        Fruit north_banana = ff.getBanana();
        north_banana.get();

        FruitFactory ff3 = new SouthFruitFactory();
        Fruit south_apple = ff3.getApple();
        south_apple.get();
        Fruit south_banana = ff3.getBanana();
        south_banana.get();


        FruitFactory ff2 = new WenshiFruitFactory();
        Fruit wenshi_apple = ff2.getApple();
        wenshi_apple.get();
        Fruit wenshi_banana = ff2.getBanana();
        wenshi_banana.get();
    }
}
