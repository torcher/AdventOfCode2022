using System.Collections.Generic;
using System.Linq;

public class Directory : FileSystemNode {
  
  public Directory? Parent { get; set; }
  public List<Directory> _subDirectories;
  public List<File> _files;
  private string _name;

  public Directory(Directory? parent, string name) : this(name)
  {
    Parent = parent;
  }

  public Directory(string name)
  {
    _name = name;
    _subDirectories = new List<Directory>();
    _files = new List<File>();
    Type = FileSystemNodeType.DIRECTORY;
  }

  public long Size { get => _subDirectories.Select(x => x.Size ).Sum() + _files.Select(x => x.Size).Sum(); }
  public string Name { get => _name; }

  public Directory? GetChild(string dirName){
    foreach(var d in _subDirectories)
      if(d.Name == dirName)
        return d;
    return null;
  }

  public void AddChild(FileSystemNode node){
    if(node.Type == FileSystemNodeType.FILE)
      this._files.Add((File)node);
    else{
      Directory d = (Directory)node;
      d.Parent = this;
      _subDirectories.Add(d);
    }
  }

}