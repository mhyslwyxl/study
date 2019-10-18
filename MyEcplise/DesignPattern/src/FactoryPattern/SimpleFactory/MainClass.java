package FactoryPattern.SimpleFactory;

public class MainClass {
	public static void main(String[] args) {
		System.out.println("简单工厂模式");
//		Fruit apple  = new Apple();
		
		Fruit apple = FruitFactory.getFruit("apple");
		apple.get();

		Fruit banana = FruitFactory.getFruit("banana");
		banana.get();
	}
}
