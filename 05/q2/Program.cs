using System.Linq;
using System.IO;
using System.Collections;

List<string> initialCrateLines = new List<string>();
var columnsLine = "";
using var sr = new StreamReader("../input.txt");
while(!sr.EndOfStream && columnsLine == string.Empty){
  var line = (await sr.ReadLineAsync()) ?? "";
  if(line.StartsWith(" 1 ")){
    columnsLine = line;
  }
  else{
    initialCrateLines.Add(line);
  }
}

Stack<char>[] columns;
if(int.TryParse(columnsLine.Trim().Split(" ").Last(), out int columnCount)){
  columns = Enumerable.Range(0,columnCount).Select(x => new Stack<char>()).ToArray();
}
else{
  throw new Exception("Columns input invalid! Cannot parse '" + columnsLine + "'");
}

for(int i = initialCrateLines.Count()-1; i>=0; i--){
  for(int c=0; c<columnCount; c++){
    char crateId = initialCrateLines[i][(c*4)+1];
    if(crateId != ' '){
      columns[c].Push(crateId);
    }
  }
}

Stack<char> crateMover = new Stack<char>();
while(!sr.EndOfStream){
  var line = (await sr.ReadLineAsync()) ?? "0 0 0 0 0 0";
  if(line != string.Empty){
    var lineSplit = line.Split(" ");
      var count = int.Parse(lineSplit[1]);
      var from = int.Parse(lineSplit[3])-1;
      var to = int.Parse(lineSplit[5])-1;
      for(int i=0; i<count; i++) {
        if(columns[from].Count() > 0){
          crateMover.Push(columns[from].Pop()); 
        }
      }
      while(crateMover.Count()>0)
        columns[to].Push(crateMover.Pop());
  }
}

for(int i=0; i<columnCount; i++) if(columns[i].Count > 0) Console.Write(columns[i].Peek());
Console.WriteLine();
