package FactoryPattern.AbstractFactoryDemo;

public interface Farm {
	public Animal newAnimal();

	public Plant newPlant();

	public String getName();
}
