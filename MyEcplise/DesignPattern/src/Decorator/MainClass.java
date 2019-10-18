package Decorator;

public class MainClass {

	public static void main(String[] args) {
		Car car = new RunCar();
		CarDecorator flycar = new FlyCarDecorator(car);
		flycar.show();
		System.out.println("-----------------------");
		SwimCarDecorator swimcar = new SwimCarDecorator(flycar);
		swimcar.show();
	}
}