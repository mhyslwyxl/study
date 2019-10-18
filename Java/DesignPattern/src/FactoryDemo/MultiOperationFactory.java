package FactoryDemo;

public class MultiOperationFactory implements OperationFactory {

    public Operation getOperation() {
        return new MultiOperation();
    }
}
