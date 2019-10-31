package CompositeAttern.Demo;

public class MainClass {
    public static void main(String[] args) {
        double s = 0;
        Bags BigBag, mediumBag, smallRedBag, smallWhiteBag;
        Goods sp;
        BigBag = new Bags("大袋子", 1);
        mediumBag = new Bags("中袋子", 0.8);
        smallRedBag = new Bags("红色小袋子", 0.3);
        smallWhiteBag = new Bags("白色小袋子", 0.3);
        sp = new Goods("婺源特产", 2, 7.9f);
        smallRedBag.add(sp);
        sp = new Goods("婺源地图", 1, 9.9f);
        smallRedBag.add(sp);
        sp = new Goods("韶关香菇", 2, 68);
        smallWhiteBag.add(sp);
        sp = new Goods("韶关红茶", 3, 180);
        smallWhiteBag.add(sp);
        sp = new Goods("景德镇瓷器", 1, 380);
        mediumBag.add(sp);
        mediumBag.add(smallRedBag);
        sp = new Goods("李宁牌运动鞋", 1, 198);
        BigBag.add(sp);
        BigBag.add(smallWhiteBag);
        BigBag.add(mediumBag);
        System.out.println("您选购的商品有：");
        BigBag.display();
        s = BigBag.calc();
        System.out.println("要支付的总价是：" + s + "元");
    }
}
