using System.Collections.Generic;
using System.IO;

var head = new Knot('H');
var tail = new Knot('9');
List<Knot> knotList = new List<Knot>{head, tail};
createKnotLinkedList(head,tail,10, knotList);
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
      case "R": head.Position.X++; break;
      case "L": head.Position.X--; break;
      case "U": head.Position.Y++; break;
      case "D": head.Position.Y--; break;
    }

    var currentKnot = head;
    while(currentKnot.nextKnot != null){
      moveKnotToNext(currentKnot.nextKnot.Position, currentKnot.Position);
      currentKnot = currentKnot.nextKnot;
    }

    tailPositions[tail.Position] = true;
  }
}

void createKnotLinkedList(Knot head, Knot tail, int totalNumberOfKnots, List<Knot> knots){
  var currentKnot = head;
  for(int i=0; i<totalNumberOfKnots-2; i++){
    var nextKnot = new Knot((char)(i + 49));
    currentKnot.setNext(nextKnot);
    knots.Add(nextKnot);
    currentKnot = nextKnot;
  }
  currentKnot.setNext(tail);
}

void moveKnotToNext(Position tail, Position head){
  var xDiff = head.X - tail.X;
  var yDiff = head.Y - tail.Y;

  if(xDiff < -1 || xDiff > 1){
    tail.X += xDiff < 0 ? -1 : 1;
    if(yDiff != 0)
      tail.Y += yDiff < 0 ? -1 : 1;
    return;
  }

  if(yDiff < -1 || yDiff > 1){
    tail.Y += yDiff < 0 ? -1 : 1;
    if(xDiff != 0)
      tail.X += xDiff < 0 ? -1 : 1;
  }
}

Console.WriteLine("The tail was in " + tailPositions.Keys.Count + " different positions.");