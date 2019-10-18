package FactoryDemo;

public class ReduceOperationFactory implements OperationFactory {

    public Operation getOperation() {
        return new ReduceOperation();
    }
}
