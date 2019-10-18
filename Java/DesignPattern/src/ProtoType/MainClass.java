package ProtoType;

public class MainClass {
    public static void main(String[] args) {
        Person p1 = new Person();
        p1.setName("zhangsan");
        p1.setAge(19);
        p1.setSex("male");

        Person p2 = p1.clone();
        p2.setAge(29);
        p2.setName("lisi");
        p1.addFriend("zhangsan");
        p1.addFriend("lisi");
        p2.addFriend("wangwu");

        p1.printInfo();
        p2.printInfo();
    }
}
