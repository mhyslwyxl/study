package FactoryPattern.FactoryDemo;

public class CattleFarm implements AnimalFarm {

	@Override
	public Animal newAnimal() {
		return new Cattle();
	}
}
