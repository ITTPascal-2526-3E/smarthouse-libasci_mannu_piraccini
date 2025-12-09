using Xunit;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation;
using System;

public class AirConditionerTests
{
    [Fact]
    public void AirConditioner_InitialState_IsCoolingAndFanSpeed3()
    {
        var ac = new AirConditioner("Test", 2000);

        Assert.Equal(AcMode.Cooling, ac.CurrentMode);
        Assert.Equal(3, ac.FanSpeed);
    }

    [Fact]
    public void AirConditioner_InitialState_AcModeSettedAtCooling()
    {
        var ac = new AirConditioner("Test", 2000);

        Assert.Equal(AcMode.Cooling, ac.CurrentMode);
    }

    [Fact]
    public void SetMode_TrowErrorIfIsOf_InvalidOperationExeption()
    {
        var ac = new AirConditioner("Test", 2000);
        Assert.Throws<InvalidOperationException>(() => ac.SetMode(AcMode.Heating));
    }

    [Fact]
    public void SetMode_ChangeModeWhenOn_ChangeModeCorrecly()
    {
        var ac = new AirConditioner("Test", 2000);

        ac.TurnOnOrOff();
        ac.SetMode(AcMode.Heating);

        Assert.Equal(AcMode.Heating, ac.CurrentMode);
    }

    [Fact]
    public void SetFanSpeed_TrowErrorIfIsOf_InvalidOperationExeption()
    {
        var ac = new AirConditioner("Test", 2000);

        Assert.Throws<InvalidOperationException>(() => ac.SetFanSpeed(4));
    }

    [Fact]
    public void SetFanSpeed_InvalidSpeed_ThrowError()
    {
        var ac = new AirConditioner("Test", 2000);

        ac.TurnOnOrOff();

        Assert.Throws<ArgumentOutOfRangeException>(() => ac.SetFanSpeed(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => ac.SetFanSpeed(6));
    }

    [Fact]
    public void SetFanSpeed_ValidFanSpeed_SetCorrectSpeed()
    {
        var ac = new AirConditioner("Test", 2000);

        ac.TurnOnOrOff();
        ac.SetFanSpeed(5);

        Assert.Equal(5, ac.FanSpeed);
    }
}