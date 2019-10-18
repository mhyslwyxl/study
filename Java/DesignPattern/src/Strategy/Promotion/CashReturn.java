package Strategy.Promotion;

public class CashReturn implements CashSuper {
    private double moneyCondition = 0;
    private double moneyReturn = 0;

    public CashReturn(double moneyCondition, double moneyReturn) {
        this.moneyCondition = moneyCondition;
        this.moneyReturn = moneyReturn;
    }

    public double exceptCash(double money) {
        double result = money;
        if (money >= moneyCondition) {
            int temp = (int) (money / moneyCondition);
            result = money - temp * moneyReturn;
        }
        return result;
    }
}
