package CompositeAttern.Demo;

import java.util.List;

public interface Articles {
    public double calc();

    public void display();

    public boolean add(Articles articles);

    public boolean remove(Articles articles);

    public List<Articles> getChild();

}
