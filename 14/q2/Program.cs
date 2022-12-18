var rockLines = new List<Line>();

using var sr = new StreamReader("../input.txt");
Position maxBounds = new Position(0,0), minBounds = new Position(int.MaxValue, int.MaxValue);
while(!sr.EndOfStream){
  var stringLine = (await sr.ReadLineAsync()) ?? "";
  var positionSplit = stringLine.Split(" -> ");
  if(positionSplit.Length < 2)
    throw new Exception("Input line is invalid: " + stringLine);

  for(int i=1; i<positionSplit.Length; i++){
    int[] start = positionSplit[i-1].Split(",").Select(x => int.Parse(x)).ToArray();
    int[] end = positionSplit[i].Split(",").Select(x => int.Parse(x)).ToArray();
    var line = new Line();
    line.SetPoints(new Position(start[0],start[1]),new Position(end[0],end[1]));
    rockLines.Add(line);
    maxBounds.X = (new int[]{ maxBounds.X, start[0], end[0] }).Max();
    maxBounds.Y = (new int[]{ maxBounds.Y, start[1], end[1] }).Max();
    minBounds.X = (new int[]{ maxBounds.X, start[0], end[0] }).Min();
    minBounds.Y = (new int[]{ maxBounds.Y, start[1], end[1] }).Min();
  }
}
sr.Close();

//Make a floor
maxBounds.Y++;

var grid = new Grid(maxBounds.Y);
foreach(var line in rockLines){
  if(line.Direction == LineDirection.HORIZONTAL){
    for(int x=line.Start.X; x<=line.End.X; x++){
      grid.BlockAt(new Position(x,line.Start.Y));
    }
  }
  else{
    for(int y=line.Start.Y; y<=line.End.Y; y++){
      grid.BlockAt(new Position(line.Start.X,y));
    }
  }
}

int sandIndex = 0;
var sandStartPosition = new Position(500,0);
while(true){
  var sand = new Position(sandStartPosition.X, sandStartPosition.Y);
  while(true){
    if(!grid.isBlockedAt(sand.X,sand.Y+1)){
      sand.Y++;
      continue;
    }

    if(!grid.isBlockedAt(sand.X-1,sand.Y+1)){
      sand.X--;
      sand.Y++;
      continue;
    }

    if(!grid.isBlockedAt(sand.X+1,sand.Y+1)){
      sand.X++;
      sand.Y++;
      continue;
    }

    grid.BlockAt(sand);
    break;
  }

  sandIndex++;
  if(sand.Equals(sandStartPosition)){
    break;
  }
}

Console.WriteLine(sandIndex + " units of sand fell before it was blocked.");
