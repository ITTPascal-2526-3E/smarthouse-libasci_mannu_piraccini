using Xunit;
using BlaisePascal.SmartHouse.Domain.TemperatureRegulation;
using System;

public class RadiatorTests
{
    [Fact]
    public void SetTemperature_TrowErrorWhenOff_InvalidOperationException()
    {
        var radiator = new Radiator("Test", 1500, 5);

        // We used the lambda expression because calling the SetTemperature() function directly would execute it 
        // immediately, before it is passed to Assert.Throws. 
        // The lambda is a concise way to write an anonymous function, and this way the method is executed only 
        // when the lambda is invoked, allowing Assert.Throws to intercept the exceptions.


        Assert.Throws<InvalidOperationException>(() => radiator.SetTemperature(30));
    }

    [Fact]
    public void SetTemperature_TrowErrorWhenTheTemperatureIsLowered_InvalidOperationException()
    {
        var radiator = new Radiator("Test", 1500, 5);

        radiator.TurnOnOrOff(); 

        Assert.Throws<InvalidOperationException>(() => radiator.SetTemperature(15));
    }

    [Fact]
    public void SetTemperature_ChangeTemperature_ChangeTemperatureCorrectly()
    {
        var radiator = new Radiator("Test", 1500, 5);

        radiator.TurnOnOrOff();
        radiator.SetTemperature(25);

        Assert.Equal(25, radiator.TargetTemperature);
    }

    [Fact]
    public void Radiator_NumberOfElementSettedIsRight_CorrectNumberOfElement()
    {
        var radiator = new Radiator("Test", 1500, 7);

        Assert.Equal(7, radiator.NumberOfElements);
    }
}
