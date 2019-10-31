package FactoryPattern.FactoryDemo;

public class HorseFarm implements AnimalFarm {

	@Override
	public Animal newAnimal() {
		return new Horse();
	}

}
