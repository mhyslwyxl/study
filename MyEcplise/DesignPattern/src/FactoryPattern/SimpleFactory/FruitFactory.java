package FactoryPattern.SimpleFactory;

public class FruitFactory {

	public static Fruit getFruit(String fruitName) {
		if (fruitName.equalsIgnoreCase("apple"))
			return new Apple();
		else if (fruitName.equalsIgnoreCase("banana"))
			return new Banana();
		return null;
	}
}
