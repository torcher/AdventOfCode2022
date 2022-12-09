using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var directories = new List<Directory>();

using var sr = new StreamReader("../input.txt");
if(sr.EndOfStream)
  throw new Exception("Input file is empty!");

_ = await sr.ReadLineAsync(); //This assumes first line is to set default root

var root = new Directory("/");
directories.Add(root);
Directory currentDir = root;
while(!sr.EndOfStream){
  var line = (await sr.ReadLineAsync()) ?? "";
  if(line.StartsWith("$")){
    if(line.StartsWith("$ cd")){
      var nodeName = line.Split(" ").Last();//This assumes directory and file names can't contain spaces
      if(line.Split(" ").Length != 3)
        throw new Exception("cd cannot be more than 3 words: " + line);
      switch(nodeName){
        case "/":
          currentDir = root;
          break;
        case "..":
          currentDir = currentDir?.Parent ?? throw new Exception("Trying to navigate higher than root directory!");
          break;
        default:
          currentDir = currentDir?.GetChild(nodeName) ?? throw new Exception("Trying to navigate to directory that doesn't exist!");
          break;
      }
    }
  }
  else{
    var node = ParseLsLine(line);
    currentDir?.AddChild(node);
    if(node.Type == FileSystemNodeType.DIRECTORY){
      var dir = (Directory)node;
      directories.Add(dir);
    }
  }
}

long SPACE_NEEDED = 30000000;
long SPACE_TOTAL = 70000000;

long spaceToClear = SPACE_NEEDED - (SPACE_TOTAL - root.Size);
long sizeOfSmallestDirToMakeEnoughSpace = int.MaxValue;
foreach(var d in directories){
  var s = d.Size;
  if(s >= spaceToClear && s < sizeOfSmallestDirToMakeEnoughSpace){
    sizeOfSmallestDirToMakeEnoughSpace = s;
  }
}

Console.WriteLine("Total size: " + root.Size);
Console.WriteLine("Space to clear: " + spaceToClear);
Console.WriteLine("Size of smallest directory to make room: " + sizeOfSmallestDirToMakeEnoughSpace);

FileSystemNode ParseLsLine(string line){
  if(line.StartsWith("dir")){
    return new Directory(string.Join(" ", line.Split(" ").Skip(1)));
  }
  
  var split = line.Split(" ");
  return new File(split[1], int.Parse(split[0]));
}

