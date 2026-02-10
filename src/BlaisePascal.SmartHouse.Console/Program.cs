using BlaisePascal.SmartHouse.Domain.Appliances;
using BlaisePascal.SmartHouse.Domain.CCTV;
using BlaisePascal.SmartHouse.Domain.Fixutures;
using BlaisePascal.SmartHouse.Domain.Lighting;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation;


class Program
{
    static void Main(string[] args)
    {
        Lamp lamp = new Lamp("Philips", "LED", 60.0, 800.0, true, "E27");
        Lamp lamp2 = new Lamp("Philips", "LED", 60.0, 800.0, true, "E27");
        lamp.TurnOnOrOff();
        lamp.TurnOnOrOff();
        Console.WriteLine("Lamp is on: " + lamp.IsOn);
        Console.WriteLine("Lamp is off: "  + lamp.IsOn);
        Console.WriteLine("Lamp power: " + lamp.Power + " Watt");
        Console.WriteLine("Lamp brand: " + lamp.brand);
        Console.WriteLine("Lamp max brightness: " + lamp.max_brightness + " Lumen");
        lamp.ChangeColor(colors_of_lamp.white);
        Console.WriteLine("LampColor: " + lamp.actualColor);
        lamp.ChangeColor(colors_of_lamp.red);
        Console.WriteLine("LampColor after the change: " + lamp.actualColor);
        lamp.DimmableControl(23);
        Console.WriteLine("Lamp brightness after dimming to 23%:" + lamp.current_brightness_percentage);
        Console.WriteLine("The id of lamp is:" + lamp.id_lamp);
        Console.WriteLine("The id of lamp2 is:" + lamp2.id_lamp);

        Console.WriteLine();

        EcoLamp ecoLamp = new EcoLamp("Osram", 15.0, 1000.0, true, "E27");
        EcoLamp ecoLamp2 = new EcoLamp("Osram", 15.0, 1000.0, true, "E27");
        ecoLamp.TurnOnOrOff();
        Console.WriteLine("EcoLamp is on: " + ecoLamp.IsOn);
        ecoLamp.TurnOnOrOff();
        Console.WriteLine("EcoLamp is off: " + ecoLamp.IsOn);
        Console.WriteLine("EcoLamp power: " + ecoLamp.Power + " Watt");
        Console.WriteLine("EcoLamp brand: " + ecoLamp.brand);
        ecoLamp.DimmableControl(50);
        Console.WriteLine("EcoLamp time on: " + ecoLamp.AllTimeLampOn);
        Console.WriteLine("EcoLamp consumed energy: " + ecoLamp.ConsumedEnergyInWH());
        Console.WriteLine(ecoLamp.id_lamp);
        Console.WriteLine(ecoLamp2.id_lamp);

        Console.WriteLine();

        Lamp l1 = new Lamp("Generic", "LED", 10, 100, true, "E14");
        EcoLamp l2 = new EcoLamp("EcoGen", 10, 100, true, "E14");
        TwoLampDevice device = new TwoLampDevice(l1, l2);
        TwoLampDevice device2 = new TwoLampDevice(l1, l2);
        device.TurnOnOrOff();
        Console.WriteLine("Device MainLamp is on: " + device.MainLamp.IsOn);
        device.TurnOnOrOff();
        Console.WriteLine("Device EcoLamp is on: " + device.EnergySaverLamp.IsOn);
        Console.WriteLine("Device Eco Stats: " + device.GetEcoStats());
        Console.WriteLine(device.DeviceId);
        Console.WriteLine(device2.DeviceId);

        Console.WriteLine();

        AirConditioner ac = new AirConditioner("Samsung", 2000.0);
        AirConditioner ac2 = new AirConditioner("Samsung", 2000.0);
        Console.WriteLine("AC is off: " + ac.IsOn);
        ac.TurnOnOrOff();
        Console.WriteLine("AC is on: " + ac.IsOn);
        Console.WriteLine("AC brand: " + ac.Brand);
        ac.SetMode(AcMode.Heating);
        Console.WriteLine("AC Mode: " + ac.CurrentMode);
        ac.SetMode(AcMode.Cooling);
        Console.WriteLine("AC Mode: " + ac.CurrentMode);
        ac.SetFanSpeed(4);
        Console.WriteLine("AC Fan Speed: " + ac.FanSpeed);
        ac.SetFanSpeed(2);
        Console.WriteLine("AC Fan Speed: " + ac.FanSpeed);
        ac.SetTemperature(22.5);
        Console.WriteLine("AC Target Temp: " + ac.TargetTemperature);
        ac.SetTemperature(20.0);
        Console.WriteLine("AC Target Temp: " + ac.TargetTemperature);
        Console.WriteLine(ac.Id);
        Console.WriteLine(ac2.Id);

        Console.WriteLine();

        Radiator radiator = new Radiator("DeLonghi", 1500.0, 10);
        Radiator radiator2 = new Radiator("DeLonghi", 1500.0, 10);
        Console.WriteLine("Radiator brand: " + radiator.Brand);
        Console.WriteLine("Radiator elements: " + radiator.NumberOfElements);
        Console.WriteLine("Radiator is off: " + radiator.IsOn);
        radiator.TurnOnOrOff();
        Console.WriteLine("Radiator is on: " + radiator.IsOn);
        radiator.SetTemperature(25.0);
        Console.WriteLine("Radiator Target Temp: " + radiator.TargetTemperature);
        radiator.SetTemperature(35.0);
        Console.WriteLine("Radiator Target Temp: " + radiator.TargetTemperature);
        Console.WriteLine(radiator.Id);
        Console.WriteLine(radiator2.Id);

        Console.WriteLine();

        Door door = new Door();
        Door door2 = new Door();
        door.OpenOrClose();
        Console.WriteLine("Door is close: " + door.IsOpen());
        door.OpenOrClose();
        Console.WriteLine("Door is close: " + door.IsOpen());
        Console.WriteLine("Door is locked: " + door.IsLocked());
        door.LockOrUnlock();
        Console.WriteLine("Door is locked: " + door.IsLocked());

        Console.WriteLine();

        CCTV cam = new CCTV("Garden Cam");
        CCTV cam2 = new CCTV("Garden Cam");
        Console.WriteLine("CCTV Name: " + cam.Name);
        cam.TurnOnOrOff();
        Console.WriteLine("CCTV Status: " + cam.Status);
        cam.TurnOnOrOff();
        Console.WriteLine("CCTV Status: " + cam.Status);
        cam.TurnOnOrOff();
        cam.StartRecording();
        Console.WriteLine("CCTV State: " + cam.CCTVState);
        cam.StopRecording();
        Console.WriteLine("CCTV State after stop: " + cam.CCTVState);
        Console.WriteLine(cam.Id);
        Console.WriteLine(cam2.Id);

        Console.WriteLine();

        CoffeeMachine cm = new CoffeeMachine();
        CoffeeMachine cm2 = new CoffeeMachine();

        Console.WriteLine("CoffeeMachine is ON: " + cm.IsOn);
        cm.TurnOnOrOff();
        Console.WriteLine("CoffeeMachine is ON after turning on: " + cm.IsOn);

        cm.TurnOnOrOff();
        Console.WriteLine("CoffeeMachine is OFF: " + cm.IsOn);

        cm.AddWater(50);
        Console.WriteLine("Water Level: " + cm.WaterLevel + "%");

        cm.AddWater(30);
        Console.WriteLine("Water Level After Adding 30%: " + cm.WaterLevel + "%");

        cm.TurnOnOrOff();
        cm.PlaceCup();
        cm.MakeCoffee();

        Console.WriteLine("Water Level after coffee: " + cm.WaterLevel + "%");
        Console.WriteLine("Cup present after coffee: " + cm.IsCupPresent);
        Console.WriteLine("Machine brewing: " + cm.IsBrewing);

        Console.WriteLine("CoffeeMachine ID: " + cm.Id);
        Console.WriteLine("CoffeeMachine2 ID: " + cm2.Id);

        Console.ReadLine();
    }
}
