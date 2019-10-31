package FactoryPattern.AbstractFactoryDemo;

public class HongxingFarm implements Farm {

	@Override
	public Animal newAnimal() {
		return new Horse();
	}

	@Override
	public Plant newPlant() {
		return new Apple();
	}

	public String getName() {
		return "∫Ï–«≈©≥°";
	}
}
