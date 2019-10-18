package FactoryDemo;

public abstract  class Operation {
    private double num1;
    private double num2;

    public double getNum1() {
        return num1;
    }

    public void setNum1(double value) {
        this.num1 = value;
    }

    public double getNum2() {
        return num2;
    }

    public void setNum2(double value) {
        this.num2 = value;
    }

    public abstract double getResult();
}
