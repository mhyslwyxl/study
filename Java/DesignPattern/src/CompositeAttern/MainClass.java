package CompositeAttern;

import java.util.List;

public class MainClass {
    public static void main(String[] args) {
        Folder root = new Folder("C:");
        Folder study = new Folder("study");
        Folder temp = new Folder("temp");
        Folder tools = new Folder("tools");
        File tomcat = new File("tomcat.exe");
        File navicat = new File("navicat.exe");
        File idea = new File("idea.exe");
        File myecplise = new File("myecplise.exe");
        File python1 = new File("python1.mp4");
        File python2 = new File("python2.mp4");
        File python3 = new File("python3.mp4");
        File python4 = new File("python4.mp4");

        root.add(study);
        root.add(temp);
        root.add(tools);
        root.add(tomcat);
        study.add(python1);
        study.add(python2);
        study.add(python3);
        study.add(python4);
        tools.add(navicat);
        tools.add(idea);
        tools.add(myecplise);

        displayTree(root, "", 0);
    }

    public static void displayTree(IFile root, String path, int deep) {
        for (int i = 0; i < deep; i++)
            System.out.print("--");
        root.display(path);
        List<IFile> children = root.getChild();
        if (children != null) {
            deep++;
            for (IFile file : root.getChild()) {
                displayTree(file, path + root.getName() + "\\", deep);
            }
        }
    }
}
