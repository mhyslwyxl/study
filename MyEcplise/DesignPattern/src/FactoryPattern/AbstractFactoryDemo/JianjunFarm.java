package FactoryPattern.AbstractFactoryDemo;

public class JianjunFarm implements Farm {

	@Override
	public Animal newAnimal() {
		return new Cattle();
	}

	@Override
	public Plant newPlant() {
		return new Banana();
	}

	public String getName() {
		return "建军农场";
	}
}
