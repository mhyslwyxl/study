package Facade;

public class Facade {
    private SystemA systemA;
    private SystemB systemB;
    private SystemC systemC;

    public Facade() {
        systemA = new SystemA();
        systemB = new SystemB();
        systemC = new SystemC();
    }

    public void doABC() {
        systemA.doSomething();
        systemB.doSomething();
        systemC.doSomething();
    }

    public void doBC() {
        systemB.doSomething();
        systemC.doSomething();
    }
}
