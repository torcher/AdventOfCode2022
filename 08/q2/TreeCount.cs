public class TreeCount{
  public int Left { get; set; }
  public int Right { get; set; }
  public int Up { get; set; }
  public int Down { get; set; }

  public int Score { get => Left*Right*Up*Down; }

  public TreeCount()
  {
    Left = 0;
    Right = 0;
    Up = 0;
    Down = 0;
  }
}