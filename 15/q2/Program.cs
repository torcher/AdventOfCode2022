using System.Numerics;
long maxCoordinates = 4000000;

List<(long x,long y,long r)> sensorAreas = new List<(long x, long y, long d)>();
(long x, long y) distressLocation = (0,0);
using var sr = new StreamReader("../input.txt");
while(!sr.EndOfStream){
  var line = (await sr.ReadLineAsync()) ?? "";
  var lineSplit = line.Split(" ");
  (long x, long y) sensor = (GetLongAtPos(lineSplit,2),GetLongAtPos(lineSplit,3));
  (long x,long y) closestBeacon = (GetLongAtPos(lineSplit,8),GetLongAtPos(lineSplit,9));
  
  long distanceToBeacon = DistanceBetween(sensor,closestBeacon);
  sensorAreas.Add((sensor.x, sensor.y, distanceToBeacon));
}
sr.Close();

for(long y=0; y<=maxCoordinates; y++){
  for(long x=0; x<=maxCoordinates; ){
    bool inThisLine = true;
    for(int a=0; a<sensorAreas.Count; a++){
      var distanceToSensor = DistanceBetween((x,y), (sensorAreas[a].x,sensorAreas[a].y));
      if(distanceToSensor <= sensorAreas[a].r){
        x = sensorAreas[a].r-Math.Abs(sensorAreas[a].y-y)+sensorAreas[a].x+1;
        if(x >= maxCoordinates){
          inThisLine = false;
          break;
        }
        a = -1;
      }
    }
    if(inThisLine){
      distressLocation.x = x;
      distressLocation.y = y;
      y=maxCoordinates+1;
    }
    break;
  }
}

Console.WriteLine($"The distress beacon is coming from ({distressLocation.x},{distressLocation.y})");
BigInteger tuningFrequency = distressLocation.x;
tuningFrequency *= maxCoordinates;
tuningFrequency += distressLocation.y;
Console.WriteLine($"The tuning frequency for this location is {tuningFrequency}");


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