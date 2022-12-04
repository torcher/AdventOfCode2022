using System.IO;
int totalOverlap = 0;
using var sr = new StreamReader("../input.txt");
while(!sr.EndOfStream){
  var line = (await sr.ReadLineAsync()) ?? "";
  var ranges = line.Split(",").Select(x => new Range(x)).ToArray();
  if(ranges[0].Overlap(ranges[1])) totalOverlap++;
}
sr.Close();

Console.WriteLine("Total overlapping: " + totalOverlap);