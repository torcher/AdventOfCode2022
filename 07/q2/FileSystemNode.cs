public class FileSystemNode{
  public FileSystemNodeType Type { get; set; }
}

public enum FileSystemNodeType{
  FILE,
  DIRECTORY
}