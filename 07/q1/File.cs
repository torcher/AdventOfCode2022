public class File : FileSystemNode{
  public string Name { get; }
  public int Size { get; }

  public File(string name, int size)
  {
    Type = FileSystemNodeType.FILE;
    Name = name;
    Size = size;
  }
}