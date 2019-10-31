package CompositeAttern.Demo;

import java.util.ArrayList;
import java.util.List;

public class Bags implements Articles {
    private List<Articles> articlesList;
    private String name;
    private double unitPrice; //单价

    public Bags(String name, double unitPrice) {
        this.name = name;
        this.unitPrice = unitPrice;
        this.articlesList = new ArrayList<Articles>();
    }


    @Override
    public double calc() {
        double amount = unitPrice;
        if (articlesList == null)
            return amount;
        for (Articles articles : articlesList)
            amount += articles.calc();

        return amount;
    }

    @Override
    public void display() {
        System.out.printf("%s(价值：%f元, 总价%f元)%n", name, unitPrice, calc());
        if (articlesList != null)
            for (Articles articles : articlesList)
                articles.display();
    }

    @Override
    public boolean add(Articles articles) {
        return articlesList.add(articles);
    }

    @Override
    public boolean remove(Articles articles) {
        return articlesList.remove(articles);
    }

    @Override
    public List<Articles> getChild() {
        return articlesList;
    }
}
