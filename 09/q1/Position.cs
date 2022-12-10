public class Position : IEquatable<Position>{
  public int X { get; set; }
  public int Y { get; set; }

  public Position(int x, int y)
  {
    X = x;
    Y = y;
  }

  public Position()
  {
    X = 0;
    Y = 0;
  }

  public bool Equals(Position? other)
  {
    if(other == null) return false;
    return other.X == X && other.Y == Y;
  }

  public override int GetHashCode() {
        return ToString().GetHashCode();
    }

  public override string ToString()
  {
    return $"{X},{Y}";
  }
}