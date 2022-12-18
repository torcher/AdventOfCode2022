public class Line{
  public Position Start { get; set; }
  public Position End { get; set; }
  public LineDirection Direction { get => Start.Y == End.Y ? LineDirection.HORIZONTAL : LineDirection.VERTICAL; }

  public Line()
  {
    Start = new Position(0,0);
    End = new Position(0,0);
  }

  public void SetPoints(Position one, Position two){
    if(one.X == two.X){
      if(one.Y < two.Y){
        Start = one;
        End = two;
      }
      else{
        Start = two;
        End = one;
      }
    }
    else{
      if(one.X < two.X){
        Start = one;
        End = two;
      }
      else{
        Start = two;
        End = one;
      }
    }
  }
}

public enum LineDirection{
  VERTICAL,
  HORIZONTAL
}