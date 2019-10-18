package Strategy.Demo;

public class PaymentNormal implements Payment {

    public double cost(double num) {
        return num;
    }
}
