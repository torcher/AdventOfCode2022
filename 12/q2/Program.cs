
var grid = new List<Square[]>();
var allSquare = new List<Square>();
using var sr = new StreamReader("../input.txt");

var y = 0;
while(!sr.EndOfStream){
  var x = 0;
  var line = (await sr.ReadLineAsync()) ?? "";
  grid.Add(line.ToCharArray().Select(s => {
    var ret = new Square(x++, y, s);
    if(s == 'S'){
      ret.Elevation = 'a';
    }
    else if(s == 'E'){
      ret.Elevation = 'z';
      ret.Distance = 0;
    }
    allSquare.Add(ret);
    return ret;
  }).ToArray());
  y++;
}

var highestGridSquare = grid.Count-1;
var widestGridSquare = grid.First().Length-1;
var totalSquares = allSquare.Count;
var closestA = new Square(-1,-1,' ');
closestA.Distance = int.MaxValue;
while(allSquare.Any(x => x.Elevation == 'a') && allSquare.Any(x => x.Distance != int.MaxValue)){
  var closest = allSquare.Where(x => x.Distance != int.MaxValue).OrderBy(x => x.Distance).First();
  if(closest.Elevation == 'a' && closest.Distance < closestA.Distance) closestA = closest;
  closest.setFinal();
  allSquare.Remove(closest);

  //Set up distance
  if(closest.Y != 0){
    var up = grid[closest.Y-1][closest.X];
    if(!up.Final && up.canClimbFrom(closest)){
      up.Distance = closest.Distance+1;
    }
  }

  //Set down distance
  if(closest.Y != highestGridSquare){
    var down = grid[closest.Y+1][closest.X];
    if(!down.Final && down.canClimbFrom(closest)){
      down.Distance = closest.Distance+1;
    }
  }

  //Set left distance
  if(closest.X != 0){
    var left = grid[closest.Y][closest.X-1];
    if(!left.Final && left.canClimbFrom(closest)){
      left.Distance = closest.Distance+1;
    }
  }
  //Set right distance
  if(closest.X != widestGridSquare){
    var right = grid[closest.Y][closest.X+1];
    if(!right.Final && right.canClimbFrom(closest)){
      right.Distance = closest.Distance+1;
    }
  }
}

Console.WriteLine("The minimum distance is to an a is " + closestA.Distance + $" at {closestA.X},{closestA.Y}");