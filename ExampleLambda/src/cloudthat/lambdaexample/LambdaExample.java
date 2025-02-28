package cloudthat.lambdaexample;

@FunctionalInterface
interface MathOperation{
    int operation(int a, int b);
}

//public class LambdaExample {
//    public static void main(String[] args) {
//        MathOperation addition = new MathOperation() {
//            @Override
//            public int operation(int a, int b) {
//                return a+b;
//            }
//        };
//        System.out.println(addition.operation(23,45));
//    }
//}

public class LambdaExample {
    public static void main(String[] args) {
        MathOperation addition = (a,b) -> a+b;
//        System.out.println(addition.operation(45,97));
        System.out.println(addition.operation(90,87));
    }
}