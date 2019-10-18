package Strategy;

public class MainCass {
    public static void main(String[] args) {
        System.out.println("策略模式");

        Strategy strategy = new Strategy(new Md5Encrypt());
        strategy.encrypt();
    }
}
