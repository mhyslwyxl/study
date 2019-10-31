package CompositeAttern;

import java.util.List;

public interface IFile {
    public void display(String path);

    public boolean add(IFile file);

    public boolean remove(IFile file);

    public List<IFile> getChild();

    public String getName();
}
