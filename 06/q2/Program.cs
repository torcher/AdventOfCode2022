char[]? inputChars = null;
using var sr = new StreamReader("../input.txt");
if(!sr.EndOfStream) inputChars = ((await sr.ReadLineAsync()) ?? "").ToCharArray();

if(inputChars == null) throw new Exception("No input provided");

int uniqueCharLength = 14;
int pos = 0;
for(int i=0; i<inputChars.Length-uniqueCharLength+1; i++){
    var charsCount = new Dictionary<char, bool>();
    for(int j=i; j<inputChars.Length && j < i+uniqueCharLength; j++){
        if(charsCount.ContainsKey(inputChars[j]))
            break;
        else
            charsCount[inputChars[j]] = true;
    }
    if(charsCount.Keys.Count == uniqueCharLength)
    {
        pos = i+uniqueCharLength;
        break;
    }
}

Console.WriteLine("The position of the last char of start-message-code is " + pos);