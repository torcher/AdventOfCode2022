
List<Monkey> monkies = new List<Monkey>();
using var sr = new StreamReader("../input.txt");
while(!sr.EndOfStream){
  var idLine = (await sr.ReadLineAsync()) ?? "";
  var itemsLine = (await sr.ReadLineAsync()) ?? "";
  var OperationLine = (await sr.ReadLineAsync()) ?? "";
  var testLine = (await sr.ReadLineAsync()) ?? "";
  var testTrueLine = (await sr.ReadLineAsync()) ?? "";
  var testFalseLine = (await sr.ReadLineAsync()) ?? "";
  _ = (await sr.ReadLineAsync()) ?? ""; //Throw away empty line

  var items = string.Join("", itemsLine.Split(" ").Skip(4)).Split(",").Select(x => Convert.ToInt64(x)).ToArray();
  
  var operationSplit = OperationLine.Split(" ");
  var operation = operationSplit[operationSplit.Length-2];
  var operationValue = operationSplit.Last();

  var testDivisor = Convert.ToInt32(testLine.Split(" ").Last());
  var testTrue = Convert.ToInt32(testTrueLine.Split(" ").Last());
  var testFalse = Convert.ToInt32(testFalseLine.Split(" ").Last());

  monkies.Add(new Monkey(items, operation, operationValue, testDivisor, testTrue, testFalse));
}
sr.Close();

for(int i=0; i<20; i++){
  for(int m=0; m<monkies.Count; m++){
    List<(int monkey, long item)> throws = monkies[m].InspectItems();
    foreach(var t in throws){
      monkies[t.monkey].CatchItem(t.item);
    }
  }
}

var topTwoMonkies = monkies.OrderByDescending(x => x.ItemsHandled).Take(2).ToArray();
Console.WriteLine("Monkiness: " + topTwoMonkies[0].ItemsHandled*topTwoMonkies[1].ItemsHandled);