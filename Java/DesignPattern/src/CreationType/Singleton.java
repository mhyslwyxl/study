package CreationType;

public class Singleton {
    public static void main(String[] args) {
        President p1 = President.getPresident();
        p1.setName("特朗普");
        System.out.println("我是" + p1.getName());
        President p2 = President.getPresident();
        p1.setName("特靠谱");
        System.out.println("我是p1  " + p1.getName());
        System.out.println("我是p2  " + p2.getName());
        if(p1==p2)
        {
            System.out.println("他们是同一人！");
        }
        else
        {
            System.out.println("他们不是同一人！");
        }
    }
}

class President {
    private static volatile President president;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    private String name;

    private President() {
    }

    public static synchronized President getPresident() {
        if (president == null)
            president = new President();
        else {
            System.out.println("已经有一个总统，不能产生新总统！");
        }
        return president;
    }
}