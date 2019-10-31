package CompositeAttern.Demo;

import java.util.List;

public class Goods implements Articles {

    private String name;
    private int quantity;    //数量
    private float unitPrice; //单价

    public Goods(String name, int quantity, float unitPrice) {
        this.name = name;
        this.quantity = quantity;
        this.unitPrice = unitPrice;
    }

    @Override
    public double calc() {
        return quantity * unitPrice;
    }

    @Override
    public void display() {
        System.out.printf("%s(数量：%d，单价：%f元, 共%f元)%n", name, quantity, unitPrice, calc());
    }

    @Override
    public boolean add(Articles articles) {
        return false;
    }

    @Override
    public boolean remove(Articles articles) {
        return false;
    }

    @Override
    public List<Articles> getChild() {
        return null;
    }
}
