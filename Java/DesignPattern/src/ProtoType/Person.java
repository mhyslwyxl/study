package ProtoType;

import javax.swing.plaf.PanelUI;
import java.util.ArrayList;
import java.util.List;

public class Person implements Cloneable {
    private String name;
    private int age;
    private String sex;
    private List<String> friends = new ArrayList<>();

    public void addFriend(String friend) {
        this.friends.add(friend);
    }

    public List<String> getFriends() {
        return this.friends;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    public String getSex() {
        return sex;
    }

    public void setSex(String sex) {
        this.sex = sex;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Person clone() {
        try {
            return (Person) super.clone();
        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
            return null;
        }
    }

    public void printInfo() {
        System.out.println(this.name + " is " + this.sex + ", today is " + this.age);
        System.out.println("the friends of " + name + " are:");
        for (String s : this.friends) {
            System.out.println(s);
        }
    }
}
