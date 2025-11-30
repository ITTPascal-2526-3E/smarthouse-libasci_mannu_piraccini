using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Lighting;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class LampTests
    {
        [Fact]
        public void TurnOnOrOff_WhenTheLightIsOff_TurnsItOn()
        {
            var lamp = new Lamp("Test", "LED", 10, 500, true, "E27");
            lamp.TurnOnOrOff();
            Assert.True(lamp.IsOn());
        }

        [Fact]
        public void TurnOnOrOff_WhenTheLightIsOn_TurnsItOff()
        {
            var lamp = new Lamp("Test", "LED", 10, 500, true, "E27");
            lamp.TurnOnOrOff(); // on
            lamp.TurnOnOrOff(); // off
            Assert.False(lamp.IsOn());
        }

        [Fact]
        public void DimmableControl_validValueAndDimmable_DoesNotThrow()
        {
            var lamp = new Lamp("Test", "LED", 10, 500, true, "E27");
            var brightnessLevel = 50.0;
            lamp.DimmableControl(brightnessLevel);
            // no Assert: test fallirà solo se viene lanciata un'eccezione
        }

        [Fact]
        public void DimmableControl_NotDimmable_ThrowsInvalidOperationException()
        {
            var lamp = new Lamp("Test", "LED", 10, 500, false, "E27");
            Assert.Throws<InvalidOperationException>(() => lamp.DimmableControl(50.0));
        }

        [Fact]
        public void DimmableControl_InvalidValue_ThrowsArgumentOutOfRange()
        {
            var lamp = new Lamp("Test", "LED", 10, 500, true, "E27");
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.DimmableControl(150.0));
        }

        [Fact]
        public void ChangeColor_lampIsLED_doesNotThrow()
        {
            var lamp = new Lamp("Test", "LED", 10, 500, true, "E27");
            lamp.ChangeColor(colors_of_lamp.blue);
        }

        [Fact]
        public void ChangeColor_lampIsNotLED_ThrowsInvalidOperationException()
        {
            var lamp = new Lamp("Test", "Incandescent", 10, 500, false, "E27");
            Assert.Throws<InvalidOperationException>(() => lamp.ChangeColor(colors_of_lamp.blue));
        }

        [Fact]
        public void Constructor_validParameters_createsObject()
        {
            string brand = "Philips";
            string type = "LED";
            double power = 10;
            double maxBrightness = 800;
            bool isDimmable = true;
            string socket = "E27";

            var lamp = new Lamp(brand, type, power, maxBrightness, isDimmable, socket);

            Assert.NotNull(lamp);
        }
    }
}