package FactoryDemo;

public class SubOperation extends Operation {

    public double getResult() {
        double result;
        if (this.getNum2() != 0) {
            result = this.getNum1() / this.getNum2();
        } else {
            result = 0;
        }
        return result;
    }
}
