package Strategy.Promotion;

public class CashRebate implements CashSuper {
    private double moneyRebate = 1;

    public CashRebate(double moneyRebate) {
        this.moneyRebate = moneyRebate;
    }

    public double exceptCash(double money) {
        // TODO Auto-generated method stub
        return money * moneyRebate;
    }
}
