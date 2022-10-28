using System;


ChargerControl charControl = new ChargerControl();
DIsplay dIsplay = new DIsplay();
FileLogger fileLogger = new FileLogger();
KeyReader keyReader = new KeyReader();
ConsoleDoor Door = new ConsoleDoor(false,false);

ChargingBox.ChargingBox Box = new ChargingBox.ChargingBox(Door,
                                                          charControl,
                                                          keyReader, 
                                                          dIsplay, 
                                                          fileLogger);


//Brugeren åbner lågen på ladeskabet
Door.Open();

//Brugeren tilkobler sin mobiltelefon til ladekablet.
charControl.IsConnected = true;
Console.WriteLine("connecting phone");


//Brugeren lukker lågen på ladeskabet
Door.Close();


//Brugeren holder sit RFID tag op til systemets RFID-læser.
keyReader.ReadKey("key_");
//Box.State = ChargingBoxState.Locked;

Console.WriteLine("=|the Box state: {0}|=",Box.State);
Console.WriteLine("the IsLocked state: {0}", Door.IsLocked);
Console.WriteLine("the IsOpen state: {0}", Door.IsOpen);
//Systemet aflæser RFID-tagget. Hvis ladekablet er forbundet, låser systemet lågen på ladeskabet, 
//og låsningen logges. Skabet er nu optaget. Opladning påbegyndes


