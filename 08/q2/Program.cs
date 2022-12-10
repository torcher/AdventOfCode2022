List<int[]> treeSizeMapList = new List<int[]>();

using var sr = new StreamReader("../input.txt");
while(!sr.EndOfStream){
  var line = (await sr.ReadLineAsync()) ?? "";
  treeSizeMapList.Add(line.ToCharArray().Select(x => Convert.ToInt32(x)).ToArray());
}
sr.Close();

var rows = treeSizeMapList.Count;
var columns = treeSizeMapList.First().Length;

long highest = 0;
for(int r = 1; r<rows-1; r++)
  for(int c = 1; c<columns-1; c++){
    var size = treeSizeMapList[r][c];
    var tc = new TreeCount();

    //Left
    for(int c_prime=c-1; c_prime>=0; c_prime--){
      tc.Left++;
      if(treeSizeMapList[r][c_prime] >= size)
        break;
    }

    //Right
    for(int c_prime=c+1; c_prime<columns; c_prime++){
      tc.Right++;
      if(treeSizeMapList[r][c_prime] >= size)
        break;
    }

    //Down
    for(int r_prime=r+1; r_prime<rows; r_prime++){
      tc.Down++;
      if(treeSizeMapList[r_prime][c] >= size)
        break;
    }

    //Up
    for(int r_prime=r-1; r_prime>=0; r_prime--){
      tc.Up++;
      if(treeSizeMapList[r_prime][c] >= size)
        break;
    }

    if(tc.Score>highest)
      highest=tc.Score;
  }


Console.WriteLine("The highest scenic score is " + highest);