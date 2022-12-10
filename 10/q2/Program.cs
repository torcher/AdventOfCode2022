using System.IO;
var x = 1;
int cycle = 1;
int? addToRegister = null;

using var sr = new StreamReader("../input.txt");
while(!sr.EndOfStream){
  var pos = (cycle-1)%40;
  if(x <= pos+1 && x >= pos-1) Console.Write("#");
  else Console.Write(".");

  if(addToRegister != null){
    x += addToRegister ?? 0;
    addToRegister = null;
  }
  else{
    var line = (await sr.ReadLineAsync()) ?? "";
    if(line != "noop"){
      var lineSplit = line.Split(" ");
      addToRegister = Convert.ToInt32(lineSplit[1]);
    }
  }

  cycle++;
  if((cycle-1)%40 == 0) Console.WriteLine();
}