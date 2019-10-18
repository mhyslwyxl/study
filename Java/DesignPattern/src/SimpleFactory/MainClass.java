package SimpleFactory;

public class MainClass {
    public static void main(String args[]) {
        System.out.println("Simple Factory");
        Fruit apple = FruitFactory.getApple();
        apple.get();
    }
}
