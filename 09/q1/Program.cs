using System.Collections.Generic;
using System.IO;
var head = new Position();
var tail = new Position();
Dictionary<Position, bool> tailPositions = new Dictionary<Position, bool>();

using var sr = new StreamReader("../input.txt");
while(!sr.EndOfStream){
  var line = (await sr.ReadLineAsync()) ?? "";
  var lineSplit = line.Split(" ");
  if(lineSplit.Length != 2)
    throw new System.Exception($"Invalid input! '{line}' should be a letter and a number separated by a space");
  
  var headDirection = lineSplit[0];
  var headMoves = int.Parse(lineSplit[1]);
  for(int m=0; m<headMoves; m++){
    switch(headDirection){
      case "R": head.X++; break;
      case "L": head.X--; break;
      case "U": head.Y++; break;
      case "D": head.Y--; break;
    }

    moveTailToHead(tail,head);
    tailPositions[tail] = true;
  }
}

void moveTailToHead(Position tail, Position head){
  var xDiff = head.X - tail.X;
  var yDiff = head.Y - tail.Y;

  if(xDiff < -1 || xDiff > 1){
    tail.X += xDiff < 0 ? -1 : 1;
    tail.Y += yDiff;
    return;
  }

  if(yDiff < -1 || yDiff > 1){
    tail.Y += yDiff < 0 ? -1 : 1;
    tail.X += xDiff;
  }
}


Console.WriteLine("The tail was in " + tailPositions.Keys.Count + " different positions.");