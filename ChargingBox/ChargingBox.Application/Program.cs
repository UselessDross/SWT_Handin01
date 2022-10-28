using System;
using System.Reflection;

 string KEY = "key";

ChargerControl charControl = new ChargerControl();
DIsplay dIsplay = new DIsplay();
FileLogger fileLogger = new FileLogger();
KeyReader keyReader = new KeyReader();
ConsoleDoor Door = new ConsoleDoor(false,false);
keyReader.ReadKey(KEY);

ChargingBox.ChargingBox Box = new ChargingBox.ChargingBox(Door,
                                                          charControl,
                                                          keyReader, 
                                                          dIsplay, 
                                                          fileLogger);

Door.Open();

charControl.IsConnected = true;
Console.WriteLine("connecting phone");

Door.Close();

keyReader.ReadKey(KEY);

Console.WriteLine("======================================");
keyReader.ReadKey(KEY);
Door.Open();
charControl.IsConnected = false;


