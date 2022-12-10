public class Knot{
  public char ID { get; set; }
  public Position Position { get; set; }

  public Knot? nextKnot { get; set; } = null;

  public Knot(char id)
  {
    ID = id;
    Position = new Position();
  }

  public Knot(char id, Knot next) : this(id)
  {
    nextKnot = next;
  }

  public void setNext(Knot next){
    nextKnot = next;
  }
}