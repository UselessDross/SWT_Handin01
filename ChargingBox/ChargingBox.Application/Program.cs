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


//Brugeren åbner lågen på ladeskabet
Door.Open();

//Brugeren tilkobler sin mobiltelefon til ladekablet.
charControl.IsConnected = true;
Console.WriteLine("connecting phone");


//Brugeren lukker lågen på ladeskabet
Door.Close();


//Brugeren holder sit RFID tag op til systemets RFID-læser.
keyReader.ReadKey(KEY);
//Box.State = ChargingBoxState.Locked;

Console.WriteLine("=|the Box state: {0}|=",Box.State);
Console.WriteLine("the IsLocked state: {0}", Door.IsLocked);
Console.WriteLine("the IsOpen state: {0}", Door.IsOpen);
//Systemet aflæser RFID-tagget. Hvis ladekablet er forbundet, låser systemet lågen på ladeskabet, 
//og låsningen logges. Skabet er nu optaget. Opladning påbegyndes





Console.WriteLine("======================================");



Console.WriteLine("=|the Box state: {0}|=",Box.State);
keyReader.ReadKey(KEY);
Console.WriteLine("=|the Box state: {0}|=",Box.State);

Box.Door.Open();
Box.Charger.IsConnected = false;


/*
 Brugeren kommer tilbage til ladeskabet.

Brugeren holder sit RFID tag op til systemets RFID-læser.

Systemet aflæser RFID-tagget. Hvis RFID er identisk med det, der blev brugt til at låse skabet 
med, stoppes opladning, ladeskabets låge låses op og oplåsningen logges.


Brugeren åbner ladeskabet, fjerner ladekablet fra sin telefon og tager telefonen ud af ladeskabet.


Brugeren lukker skabet. Skabet er nu ledigt
 */



