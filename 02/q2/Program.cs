/*
X => Lose
Y => Draw
Z => Win

A => Rock => 1
B => Paper => 2
C => Scissors => 3
*/
var scoreLookup = new Dictionary<string,int>{
    {"A X", 3+0},
    {"A Y", 1+3},
    {"A Z", 2+6},
    {"B X", 1+0},
    {"B Y", 2+3},
    {"B Z", 3+6},
    {"C X", 2+0},
    {"C Y", 3+3},
    {"C Z", 1+6},
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