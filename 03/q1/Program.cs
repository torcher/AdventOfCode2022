using System.IO;

var totalPriorities = 0;
using var sr = new StreamReader("../input.txt");
while(!sr.EndOfStream){
  var line = (await sr.ReadLineAsync()) ?? " ";
  if(line.Length%2 != 0)
    throw new System.Exception("Invalid input! '" + line + "' is not even length");
  var rucksackLength = line.Length/2;
  var rucksacks = new char[][]{ line.Substring(0, rucksackLength).ToCharArray(), 
                                line.Substring(rucksackLength, rucksackLength).ToCharArray() };
  
  var commonCharValue = (int)findCommonChar(rucksacks[0], rucksacks[1]);
  if(commonCharValue > 90){
    totalPriorities += commonCharValue-96;
  }
  else{
    totalPriorities += commonCharValue-38;
  }
}
sr.Close();
Console.WriteLine("The total priority of the common items is: " + totalPriorities);

char findCommonChar(char[] one, char[] two){
  Dictionary<char,bool> checkedChars = new Dictionary<char, bool>();
  for(int i=0; i<one.Length; i++){
    if(!checkedChars.ContainsKey(one[i])){
      checkedChars[one[i]] = true;
      for(int j=0; j<two.Length; j++){
        if(one[i] == two[j]){
          return one[i];
        }
      }
    }
    
  }
  throw new Exception("Must be a common character!");
}