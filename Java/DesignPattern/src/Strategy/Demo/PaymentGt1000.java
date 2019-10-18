package Strategy.Demo;

public class PaymentGt1000 implements Payment {

    public double cost(double num) {
        return num * 0.8;
    }
}
