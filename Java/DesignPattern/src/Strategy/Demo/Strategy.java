package Strategy.Demo;

public class Strategy {

    private Payment payment;

    public Strategy(Payment payment) {
        this.payment = payment;
    }

    public double cost(double num) {
        return this.payment.cost(num);
    }
}
