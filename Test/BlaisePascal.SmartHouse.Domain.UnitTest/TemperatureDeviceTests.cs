using Xunit;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation;
using System;

public class TemperatureDeviceTests
{
    private class TestDevice : TemperatureDevice
    {
        public TestDevice(string brand, double power)
            : base(brand, power) { }
    }

    [Fact]
    public void Device_StartsOff_ByDefault()
    {
        var device = new TestDevice("TestBrand", 100);

        Assert.False(device.IsOn);
        Assert.Equal(20.0, device.TargetTemperature);
    }

    [Fact]
    public void TurnOnOrOf_ChangeTheState_CorrectChangeOfState()
    {
        var device = new TestDevice("TestBrand", 50);

        device.TurnOnOrOff();
        Assert.True(device.IsOn);

        device.TurnOnOrOff();
        Assert.False(device.IsOn);
    }

    [Fact]
    public void SetTemperature_TrowErrorIfIsOf_InvalidOperationExeption()
    {
        var device = new TestDevice("TestBrand", 50);

        Assert.Throws<InvalidOperationException>(() => device.SetTemperature(25));
    }

    [Fact]
    public void SetTemperature_ChangeTemperatureWhenDeviceIsOn_ChangesTemperatureCorrectly()
    {
        var device = new TestDevice("TestBrand", 50);

        device.TurnOnOrOff();
        device.SetTemperature(25);

        Assert.Equal(25, device.TargetTemperature);
    }
}