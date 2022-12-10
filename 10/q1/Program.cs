using System;
using System.IO;
var cyclesToCheck = new int[]{ 20,60,100,140,180,220 };
var cycle = 0;
var checkIndex = 0;
var x = 1;
var lastX = x;
long signalSum = 0;

using var sr = new StreamReader("../input.txt");
while(!sr.EndOfStream){  
  if(cycle >= cyclesToCheck[checkIndex]){
    signalSum += cyclesToCheck[checkIndex]*lastX;
    checkIndex++;
    if(checkIndex == cyclesToCheck.Length)
      break;
  }

  var line = (await sr.ReadLineAsync()) ?? "";
  var lineSplit = line.Split(" ");
  if(lineSplit[0] == "noop")
  {
    cycle++;
    continue;
  }

  if(lineSplit[0] != "addx" | lineSplit.Length != 2)
    throw new System.Exception("Invalid input: " + line);
  
  var v = Convert.ToInt32(lineSplit[1]);
  lastX = x;
  x += v;
  cycle += 2;
}

Console.WriteLine("The sum of the signals is " + signalSum);

