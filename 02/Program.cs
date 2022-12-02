var size = 3;
SortedLongArray arr = new SortedLongArray(size);
using var sr = new StreamReader("../01/input.txt");
long currentCalories = 0;
while(!sr.EndOfStream){
    var nextLine = await sr.ReadLineAsync();
    if(nextLine == string.Empty){
        arr.Add(currentCalories);
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

Console.WriteLine("Largest calories are: ");
long totalOfAll = 0;
for(int i=0; i<size; i++){
    long calories = arr.GetAtIndex(i) ?? 0;
    Console.WriteLine($"{i}: {calories}");
    totalOfAll += calories;
}
Console.WriteLine("Total: " + totalOfAll);