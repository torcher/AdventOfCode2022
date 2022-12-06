using System.IO;
var totalCount = 0;
using var sr = new StreamReader("../input.txt");
while(!sr.EndOfStream){
  var line = (await sr.ReadLineAsync()) ?? "";
  var ranges = line.Split(",").Select(x => new Range(x)).ToArray();
  if(ranges[0].Contains(ranges[1]) || ranges[1].Contains(ranges[0]))
    totalCount++;  
}
sr.Close();

Console.WriteLine("Total fully contained: " + totalCount);