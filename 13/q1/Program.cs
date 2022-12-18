﻿
int pairIndex = 1;
int correctOrderPairSum = 0;
using var sr = new StreamReader("../input.txt");
while(!sr.EndOfStream){
  var leftLine = (await sr.ReadLineAsync()) ?? "";
  var rightLine = (await sr.ReadLineAsync()) ?? "";
  if(!sr.EndOfStream)
    _ = await sr.ReadLineAsync(); //Throw away extra line
  
  var leftPacket = new Packets(leftLine);
  var rightPacket = new Packets(rightLine);

  var isRightOrder = Packets.Compare(leftPacket.Values, rightPacket.Values) > 0;
  if(isRightOrder == true)
    correctOrderPairSum += pairIndex;
  pairIndex++;
}

Console.WriteLine("The sum of the indicies of the correctly ordered pairs is: " + correctOrderPairSum);