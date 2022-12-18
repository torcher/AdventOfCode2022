var rockLines = new List<Line>();

using var sr = new StreamReader("../input.txt");
Position maxBounds = new Position(0,0);
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
  }
}
sr.Close();

//Give some extra space incase the rocks
//go to the edge
maxBounds.X++;
maxBounds.Y++;

var grid = new GridFill[maxBounds.X][];
for(int x=0; x<grid.Length; x++){ 
  grid[x] = new GridFill[maxBounds.Y];
  for(int y=0; y<maxBounds.Y; y++){
    grid[x][y] = GridFill.AIR;
  }

}

foreach(var line in rockLines){
  if(line.Direction == LineDirection.HORIZONTAL){
    for(int x=line.Start.X; x<=line.End.X; x++){
      grid[x][line.Start.Y] = GridFill.ROCK;
    }
  }
  else{
    for(int y=line.Start.Y; y<=line.End.Y; y++){
      grid[line.Start.X][y] = GridFill.ROCK;
    }
  }
}

bool abyssReached = false;
int sandIndex = 0;
var sandStartPosition = new Position(500,0);
while(!abyssReached){
  var sand = new Position(sandStartPosition.X, sandStartPosition.Y);
  while(true){
    if(sand.Y+1 == grid.First().Length){
      abyssReached = true;
      break;
    }

    if(grid[sand.X][sand.Y+1] == GridFill.AIR){
      sand.Y++;
      continue;
    }

    if(grid[sand.X-1][sand.Y+1] == GridFill.AIR){
      sand.X--;
      sand.Y++;
      continue;
    }

    if(grid[sand.X+1][sand.Y+1] == GridFill.AIR){
      sand.X++;
      sand.Y++;
      continue;
    }

    grid[sand.X][sand.Y] = GridFill.SAND;
    break;
  }
  sandIndex++;
}
sandIndex--;

Console.WriteLine(sandIndex + " units of sand fell before it reached the abyss.");
