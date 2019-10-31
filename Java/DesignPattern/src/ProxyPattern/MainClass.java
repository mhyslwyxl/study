package ProxyPattern;

public class MainClass {
    public static void main(String[] args){
        Bookstore bs=new Bookstore();
        bs.sellBook("c#");
        bs.sellBook("c#");
        bs.sellBook("c#");
        bs.sellBook("python");
        bs.sellBook("python");
        bs.sellBook("java");
        bs.display();
    }
}
