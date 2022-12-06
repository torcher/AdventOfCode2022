//A,X => Rock => 1
//B,Y => Paper => 2
//C,Z => Scissors => 3
var scoreLookup = new Dictionary<string,int>{
    {"A X", 1+3},
    {"B X", 1+0},
    {"C X", 1+6},
    {"A Y", 2+6},
    {"B Y", 2+3},
    {"C Y", 2+0},
    {"A Z", 3+0},
    {"B Z", 3+6},
    {"C Z", 3+3},
};

using var sr = new StreamReader("../input.txt");
var myScore = 0;
while(!sr.EndOfStream){
    var line = await sr.ReadLineAsync();
    if(line != string.Empty){
        myScore += scoreLookup[line];
    }
}

Console.WriteLine("My score is " + myScore);