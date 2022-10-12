using ChargingBox.Implementation2;
using System;

KeyReader mykey = new KeyReader();
something myklass = new something(mykey);
mykey.OnKeyRead(new ChargingBox.KeyReaderKeyReadEventArgs() { Key = 2 });