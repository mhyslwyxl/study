package Decorator;

public class FlyCarDecorator extends CarDecorator {

	public FlyCarDecorator(Car car) {
		super(car);
	}

	private void fly() {
		System.out.println("---���Է�---");
	}

	public void show() {
		this.getCar().show();
		this.fly();
	}
	
	public void run() {
		
	}
}
