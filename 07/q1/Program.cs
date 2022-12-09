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


long sizeOfSmallerDirectories = 0;
foreach(var d in directories){
  var s = d.Size;
  if(s <= 100000){
    sizeOfSmallerDirectories += s;
  }
}

Console.WriteLine("Total FS size: " + sizeOfSmallerDirectories);

FileSystemNode ParseLsLine(string line){
  if(line.StartsWith("dir")){
    return new Directory(string.Join(" ", line.Split(" ").Skip(1)));
  }
  
  var split = line.Split(" ");
  return new File(split[1], int.Parse(split[0]));
}

