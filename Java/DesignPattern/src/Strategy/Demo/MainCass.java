package Strategy.Demo;

import java.util.Scanner;

public class MainCass {
    public static void main(String[] args) {
        System.out.println("策略模式demo");
        System.out.println("请输入购物金额");
        Scanner scanner = new Scanner(System.in);
        double num = scanner.nextDouble();
        StrategyFactory sf = new StrategyFactory();
        Strategy strategy = sf.getStrategy(num);
        double cost = strategy.cost(num);
        System.out.println(cost);
    }
}
