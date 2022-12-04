using System;
public class Range{
  public readonly int Min;
  public readonly int Max;

  public Range(string range)
  {
    var splitRange = range.Split("-");
    try{
      Min = int.Parse(splitRange[0]);
      Max = int.Parse(splitRange[1]);
    }
    catch(Exception){
      throw new Exception("Invalid input! " + range + " could not be converted to a range");
    }
  }

  public bool Contains(Range contains){
    return Min <= contains.Min && Max >= contains.Max;
  }
}