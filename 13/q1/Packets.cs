using System.Linq;
public class Packets{
  public List<object> Values { get; set; }

  public Packets(string inline)
  {
    var charQueue = new Queue<char>();
    foreach(var c in inline.ToCharArray())
      charQueue.Enqueue(c);
    Values = ParseList(charQueue);
  }

  private List<object> ParseList(Queue<char> inputQueue){
    List<object> ret = new List<object>();
    _ = inputQueue.Dequeue(); //Throw away [
    while(inputQueue.Peek() != ']'){//Until close, parse values
      switch(inputQueue.Peek()){
        case '[':
          ret.Add(ParseList(inputQueue));
          break;
        case ',':
          _ = inputQueue.Dequeue();//Throw away comma
          break;
        default:
          ret.Add(ParseInteger(inputQueue));
          break;
      }
    }
    _ = inputQueue.Dequeue(); //Throw away ]
    return ret;
  }

  private int ParseInteger(Queue<char> inputQueue){
    string number = "";
    while(char.IsDigit(inputQueue.Peek())) number += inputQueue.Dequeue().ToString();
    return int.Parse(number);
  }

  public static int Compare(List<object> left, List<object> right){
    for(int i=0; i<left.Count && i < right.Count; i++){
      var comparison = CompareValues(left[i], right[i]);
      if(comparison != 0) return comparison;
    }
    return right.Count-left.Count;
  }

  private static int CompareValues(object left, object right){
    return (left,right) switch 
    {
      (int l, int r) => r-l,
      (List<object> l, int r) => Compare(l, new List<object>(){r}),
      (int l, List<object> r) => Compare(new List<object>(){l}, r),
      (List<object> l, List<object> r) => Compare(l,r),
      _ => throw new NotImplementedException("Bad input values!")
    };
  }
}