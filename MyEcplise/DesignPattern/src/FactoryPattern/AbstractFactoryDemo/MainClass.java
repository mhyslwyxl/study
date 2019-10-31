package FactoryPattern.AbstractFactoryDemo;

public class MainClass {
	public static void main(String[] args) {
		Farm f1 = new HongxingFarm();
		Animal a1 = f1.newAnimal();
		Plant p1 = f1.newPlant();
		System.out.println(f1.getName());
		a1.show();
		p1.show();

		Farm f2 = new JianjunFarm();
		Animal a2 = f2.newAnimal();
		Plant p2 = f2.newPlant();
		System.out.println(f2.getName());
		a2.show();
		p2.show();
	}
}
