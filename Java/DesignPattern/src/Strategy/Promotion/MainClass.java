package Strategy.Promotion;

public class MainClass {
    private static double total = 0;

    public static void main(String[] args) {
        // TODO Auto-generated method stub

        consume("正常收费", 1, 1000);
        consume("满300返100", 1, 1000);
        consume("打8折", 1, 1000);

        System.out.println("总计:" + total);
    }

    public static void consume(String type, int num, double price) {
        CashContext cashContext = new CashContext(type);

        double totalPrices = cashContext.acceptCash(num * price);
        total += totalPrices;

        System.out.println("单价:" + price + " 数量:" + num + "合计:" + totalPrices);
    }
}
