package Decorator;

public class SwimCarDecorator extends CarDecorator {

	public SwimCarDecorator(Car car) {
		super(car);
	}

	public void swim() {
		System.out.println("---������---");
	}

	public void show() {
		this.getCar().show();
		this.swim();
	}

	public void run() {

	}
}
