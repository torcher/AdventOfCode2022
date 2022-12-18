var keyPart1 = new Packet("[[2]]");
var keyPart2 = new Packet("[[6]]");
var packets = new List<Packet>(){
  keyPart1,
  keyPart2
};

using var sr = new StreamReader("../input.txt");
while(!sr.EndOfStream){
  var line = (await sr.ReadLineAsync()) ?? "";
  if(line != string.Empty)
    packets.Add(new Packet(line));
}
sr.Close();

packets.Sort((x,y) => Packet.Compare(y.Values,x.Values));

int key1 = 0, key2=0;
for(int i=0; i<packets.Count; i++){
  if(packets[i].Hash == keyPart1.Hash)
    key1 = i+1;
  else if(packets[i].Hash == keyPart2.Hash)
    key2 = i+1;
  
  if(key1 != 0 && key2 != 0) break;
}

Console.WriteLine("The decoder key is " + (key1*key2));
