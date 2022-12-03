using System.IO;

var totalPriorities = 0;
using var sr = new StreamReader("../input.txt");
var groupLines = new List<string>();
while(!sr.EndOfStream || groupLines.Count() == 3){
  var line = (await sr.ReadLineAsync()) ?? " ";
  if(groupLines.Count() < 3){
    groupLines.Add(line);
  }
  else{
    var commonChar = findCommonChar(groupLines[0].ToCharArray(),groupLines[1].ToCharArray(),groupLines[2].ToCharArray());
    var commonCharValue = (int)commonChar;
    if(commonCharValue > 90){
      totalPriorities += commonCharValue-96;
    }
    else{
      totalPriorities += commonCharValue-38;
    }

    groupLines = new List<string>(){ line };
  }
}
sr.Close();
Console.WriteLine("The total priority of the common items is: " + totalPriorities);

char findCommonChar(char[] one, char[] two, char[] three){
  Dictionary<char,bool> checkedChars = new Dictionary<char, bool>();
  for(int i=0; i<one.Length; i++){
    if(!checkedChars.ContainsKey(one[i])){
      checkedChars[one[i]] = true;
      for(int j=0; j<two.Length; j++){
        if(one[i] == two[j]){
          for(int k=0; k<three.Length; k++){
            if(one[i] == three[k])
              return one[i];
          }
        }
      }
    }
    
  }
  
  throw new Exception("There should be at least one matching char!");
}