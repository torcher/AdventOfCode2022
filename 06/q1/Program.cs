char[]? inputChars = null;
using var sr = new StreamReader("../input.txt");
if(!sr.EndOfStream) inputChars = ((await sr.ReadLineAsync()) ?? "").ToCharArray();

if(inputChars == null) throw new Exception("No input provided");

int pos = 0;
for(int i=0; i<inputChars.Length-3; i++){
    var charsCount = new Dictionary<char, bool>();
    for(int j=i; j<inputChars.Length && j < i+4; j++){
        if(charsCount.ContainsKey(inputChars[j]))
            break;
        else
            charsCount[inputChars[j]] = true;
    }
    if(charsCount.Keys.Count == 4)
    {
        pos = i+4;
        break;
    }
}

Console.WriteLine("The position of the last char of start-code is " + pos);