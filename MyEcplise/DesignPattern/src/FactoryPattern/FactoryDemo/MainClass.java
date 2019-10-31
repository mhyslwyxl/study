package FactoryPattern.FactoryDemo;

public class MainClass {
	public static void main(String[] args) {

		AnimalFarm af = new HorseFarm();
		Animal horse = af.newAnimal();
		horse.show();

	}
}
