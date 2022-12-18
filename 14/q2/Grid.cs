using System.Collections.Generic;
public class Grid{
  Dictionary<Position, bool> blockedPositions = new Dictionary<Position, bool>();
  public int MaxDepth { get; }

  public Grid(int maxDepth)
  {
    MaxDepth = maxDepth;
  }

  public bool isBlockedAt(int x,int y){
    return y > MaxDepth || blockedPositions.ContainsKey(new Position(x,y));
  }

  public void BlockAt(Position pos){
    blockedPositions[pos] = true;
  }
}