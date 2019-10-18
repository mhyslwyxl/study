package FactoryDemo;

public class SubOperationFactory implements OperationFactory {

    public Operation getOperation() {
        return new SubOperation();
    }
}
