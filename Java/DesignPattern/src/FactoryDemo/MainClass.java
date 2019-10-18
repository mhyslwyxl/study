package FactoryDemo;

import java.util.Scanner;

public class MainClass {
    public static void main(String[] args) {
        /*
        calc
        1、get console input
        2、compute
        3、return result
        */
        //1 get input
        System.out.println("---计算器---");
        System.out.println("输入第一个操作数");
        Scanner scanner = new Scanner(System.in);
        String strNum1 = scanner.nextLine();

        System.out.println("输入运算符");
        String oper = scanner.nextLine();

        System.out.println("输入第二个操作数");
        String strNum2 = scanner.nextLine();
        double result = 0;
        //2 compute
//        switch (oper) {
//            case "+":
//                result = Double.parseDouble((strNum1)) + Double.parseDouble((strNum2));
//                break;
//            case "-":
//                result = Double.parseDouble((strNum1)) - Double.parseDouble((strNum2));
//                break;
//            case "*":
//                result = Double.parseDouble((strNum1)) * Double.parseDouble((strNum2));
//                break;
//            case "/":
//                result = Double.parseDouble((strNum1)) / Double.parseDouble((strNum2));
//                break;
//            default:
//                System.out.println("操作符错误");
//                return;
//        }

//        OperationFactory of = new OperationFactory();
//        Operation op = of.getOperation(oper);
//        op.setNum1(Double.parseDouble(strNum1));
//        op.setNum2(Double.parseDouble(strNum2));
//        result = op.getResult();

        OperationFactory of;
        if (oper.equalsIgnoreCase("+"))
            of = new AddOperationFactory();
        else if (oper.equalsIgnoreCase("-"))
            of = new ReduceOperationFactory();
        else if (oper.equalsIgnoreCase("*"))
            of = new MultiOperationFactory();
        else
            of = new SubOperationFactory();

        Operation op = of.getOperation();
        op.setNum1(Double.parseDouble(strNum1));
        op.setNum2(Double.parseDouble(strNum2));
        result = op.getResult();
        //3 output
        System.out.println(strNum1 + oper + strNum2 + " = " + result);
    }
}
