using System.Numerics;
public class Square{
  public int X { get; set; }
  public int Y { get; set; }
  public char Elevation { get; set; }
  public int Distance { get; set; } = int.MaxValue;
  private bool _Final = false;
  public bool Final { get => _Final; }

  public Square(int x, int y, char elevation)
  {
    X = x;
    Y = y;
    Elevation = elevation;
  }

  public void setFinal(){
    this._Final = true;
  }

  public bool canClimbFrom(Square pos){
    int from = (int)pos.Elevation;
    int to = (int)Elevation;
    return to-from >= -1;
  }
}