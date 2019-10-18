package Strategy.Demo;

public class StrategyFactory {
    public Strategy getStrategy(double num) {
        if (num >= 1000)
            return new Strategy(new PaymentGt1000());
        else if (num >= 500)
            return new Strategy(new PaymentGt500());
        else if (num >= 300)
            return new Strategy(new PaymentGt300());
        else
            return new Strategy(new PaymentNormal());
    }
}
