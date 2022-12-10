List<int[]> treeSizeMapList = new List<int[]>();

using var sr = new StreamReader("../input.txt");
while(!sr.EndOfStream){
  var line = (await sr.ReadLineAsync()) ?? "";
  treeSizeMapList.Add(line.ToCharArray().Select(x => Convert.ToInt32(x)).ToArray());
}
sr.Close();

var rows = treeSizeMapList.Count;
var columns = treeSizeMapList.First().Length;

bool[][] visibilityMap = new bool[rows][];
for(int i=0; i<rows; i++) visibilityMap[i] = new bool[columns];

var visibleTrees = 0;

//LeftToRight
for(int r=0; r<rows; r++){
  var firstOrLastRow = r == 0 || r == treeSizeMapList.Count-1; 
  int highestInRow = treeSizeMapList[r][0];
  for(int c=0; c<columns; c++){
    if(firstOrLastRow || c == 0 || c == columns-1) {
      visibilityMap[r][c] = true; 
      visibleTrees++;
    }

    if(treeSizeMapList[r][c] > highestInRow){
      highestInRow = treeSizeMapList[r][c];
      if(!visibilityMap[r][c]){
        visibilityMap[r][c] = true;
        visibleTrees++;
      }
    }
  }
}

//RightToLeft
for(int r=0; r<rows; r++){
  int highestInRow = treeSizeMapList[r][columns-1];
  for(int c=columns-1; c>=0; c--){    
    if(treeSizeMapList[r][c] > highestInRow){
      highestInRow = treeSizeMapList[r][c];
      if(!visibilityMap[r][c]){
        visibilityMap[r][c] = true;
        visibleTrees++;
      }
    }
  }
}

//TopDown
for(int c=0; c<columns; c++){
  int highestInColumn = treeSizeMapList[0][c];
  for(int r=0; r<rows; r++){    
    if(treeSizeMapList[r][c] > highestInColumn){
      highestInColumn = treeSizeMapList[r][c];
      if(!visibilityMap[r][c]){
        visibilityMap[r][c] = true;
        visibleTrees++;
      }
    }
  }
}

//BottomUp
for(int c=0; c<columns; c++){
  int highestInColumn = treeSizeMapList[rows-1][c];
  for(int r=rows-1; r>=0; r--){    
    if(treeSizeMapList[r][c] > highestInColumn){
      highestInColumn = treeSizeMapList[r][c];
      if(!visibilityMap[r][c]){
        visibilityMap[r][c] = true;
        visibleTrees++;
      }
    }
  }
}

Console.WriteLine("There are " + visibleTrees + " visible trees");
  