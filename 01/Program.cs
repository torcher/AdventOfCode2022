long largestCalories = 0;
using var sr = new StreamReader("input.txt");
long currentCalories = 0;
while(!sr.EndOfStream){
    var nextLine = await sr.ReadLineAsync();
    if(nextLine == string.Empty){
        if(currentCalories > largestCalories)
            largestCalories = currentCalories;
        currentCalories = 0;
    }
    else{
        if(int.TryParse(nextLine, out int calories)){
            currentCalories += calories;
        }
        else{
            throw new Exception("Invalid integer found in input! Input was: " + nextLine);
        }
    }
}

Console.WriteLine("Largest calories was: " + largestCalories);