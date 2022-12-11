public class Monkey{
  public Queue<long> Items { get; set; }
  public OperationType OperationType {get;set;}
  public string OperationValue {get;set;}
  public long TestDivisor {get;set;}
  public int ItemsHandled {get;set;}
  public int TestTrueMonkeyId { get; set; }
  public int TestFalseMonkeyId { get; set; }

  public Monkey(long[] startingItems, string operation, string operationValue, int testDivisor, int testTrueMonkeyId, int testFalseMonkeyId)
  {
    Items = new Queue<long>();
    foreach(var i in startingItems){
      Items.Enqueue(i);
    }

    switch(operation){
      case "+":
        OperationType = OperationType.ADD;
        break;
      case "*":
        OperationType = OperationType.MULTIPLY;
        break;
    }
    OperationValue = operationValue;
    TestDivisor = testDivisor;
    TestTrueMonkeyId = testTrueMonkeyId;
    TestFalseMonkeyId = testFalseMonkeyId;
  }

  public List<(int,long)> InspectItems(){
    var ret = new List<(int id,long val)>();
    while(Items.Any()){
      var item = Items.Dequeue();
      ItemsHandled++;
      var wl = item;

      switch(OperationType){
        case OperationType.ADD:
          wl = wl + Convert.ToInt64(OperationValue);
          break;
        case OperationType.MULTIPLY:
          wl *= OperationValue == "old" ? wl : Convert.ToInt64(OperationValue);
          break;
      }

      wl = (int)Math.Floor(Convert.ToDouble(wl)/3.0d);

      if(wl%TestDivisor == 0){
        ret.Add((TestTrueMonkeyId, wl));
      }
      else{
        ret.Add((TestFalseMonkeyId, wl));
      }
    }
    return ret;
  }

  public void CatchItem(long i){
    Items.Enqueue(i);
  }
}

public enum OperationType{
  MULTIPLY,
  ADD
}