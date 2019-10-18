package Strategy.Demo;


public class PaymentGt500 implements Payment {

    public double cost(double num) {
        return num * 0.9;
    }
}
