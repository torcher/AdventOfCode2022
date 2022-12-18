using System.Collections.Generic;
long rowOfConcern = 2000000;
var emptyScannedPoisitionsInRow = new Dictionary<long, bool>();

using var sr = new StreamReader("../input.txt");
while(!sr.EndOfStream){
  var line = (await sr.ReadLineAsync()) ?? "";
  var lineSplit = line.Split(" ");
  (long x, long y) sensor = (GetLongAtPos(lineSplit,2),GetLongAtPos(lineSplit,3));
  (long x,long y) closestBeacon = (GetLongAtPos(lineSplit,8),GetLongAtPos(lineSplit,9));
  long distanceToBeacon = DistanceBetween(sensor,closestBeacon);
  long distanceToRow = DistanceBetween(sensor, (sensor.x, rowOfConcern));
  if(distanceToRow > distanceToBeacon)
    continue;
  
  long firstXPosition = sensor.x - (distanceToBeacon-distanceToRow);
  long lastXPosition = sensor.x + (distanceToBeacon-distanceToRow);
  for(long i=firstXPosition; i<=lastXPosition; i++){
    emptyScannedPoisitionsInRow[i] = true;
  }
}

Console.WriteLine($"There are {emptyScannedPoisitionsInRow.Keys.Count-1} positions that beacons can't be in in row {rowOfConcern}");

long GetLongAtPos(string[] input, int pos){
  string l = input[pos];
  int shortenBy = 2;
  if(!char.IsDigit(l.ToCharArray().Last()))
    shortenBy++;
  
  return long.Parse(l.Substring(2, l.Length-shortenBy));
}

long DistanceBetween((long x,long y) one, (long x,long y) two){
  return Math.Abs(one.x - two.x) + Math.Abs(one.y-two.y);
}