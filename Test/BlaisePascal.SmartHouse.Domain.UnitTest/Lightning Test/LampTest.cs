using BlaisePascal.SmartHouse.Domain.Lighting;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class UnitTest1
    {
        // Test 1: The light of lamp starts off, then it is turned on

        [Fact]
        public void TurnOnOrOff_WhenTheLightIsOff_TurnsItOn()
        {
            var lamp = new Lamp(new BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects.Brand("Philips"), "LED", 10, 500, true, "E27");

            lamp.TurnOnOrOff();

            Assert.True(lamp.IsOn);
        }

        // Test 2: The light of lamp starts off, then it is turned on, and then turned off again

        [Fact]
        public void TurnOnOrOff_WhenTheLightIsOn_TurnsItOff()
        {   
            var lamp = new Lamp(new BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects.Brand("Philips"), "LED", 10, 500, true, "E27");
            lamp.TurnOnOrOff(); // First turn it on
           
            lamp.TurnOnOrOff(); // Now turn it off
            
            Assert.False(lamp.IsOn);
        }

        // Test 3: The lamp is dimmable, and a valid brightness level is provided (between 1 and 100)
       
        [Fact]
        public void DimmableControl_validValueAndDimmable_DoesNotThrow()
        {             
            var lamp = new Lamp(new BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects.Brand("Philips"), "LED", 10, 500, true, "E27");
            var brightnessLevel = 50.0;

            lamp.DimmableControl(brightnessLevel);
        }

        // Test 4: The lamp is not dimmable, and a message is printed

        [Fact]
        public void DimmableControl_NotDimmable_ThrowsException()
        {
            var lamp = new Lamp(new BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects.Brand("Philips"), "LED", 10, 500, true, "E27");

            Assert.Throws<InvalidOperationException>(() => lamp.DimmableControl(50.0));
        }

        // Test 5: The lamp is dimmable but the value is ivalidad, and a message is printed

        [Fact]
        public void DimmableControl_InvalidValue_ThrowsArgumentOutOfRangeException()
        {
            var lamp = new Lamp(new BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects.Brand("Philips"), "LED", 10, 500, true, "E27");

            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.DimmableControl(150.0));
        }


        // Test 6: ChangeColor method works correctly for LED lamps

        [Fact]
        public void ChangeColor_lampIsLED_doesNotThrow()
        {
            var lamp = new Lamp(new BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects.Brand("Philips"), "LED", 10, 500, true, "E27");

            lamp.ChangeColor(colors_of_lamp.blue);
        }

        // Test 7: ChangeColor method prints an error message for non-LED lamps

        [Fact]
        public void ChangeColor_LampIsNotLED_ThrowsException()
        {
            var lamp = new Lamp(new BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects.Brand("Philips"), "LED", 10, 500, true, "E27");

            Assert.Throws<InvalidOperationException>(() => lamp.ChangeColor(colors_of_lamp.blue));
        }

        // Test del costruttore: Constructor_validParameters_createsObject

        [Fact]
        public void Constructor_validParameters_createsObject()
        {
     
            string brand = "Philips";
            string type = "LED";
            double power = 10;
            double maxBrightness = 800;
            bool isDimmable = true;
            string socket = "E27";
          
            var lamp = new Lamp(new BlaisePascal.SmartHouse.Domain.Lighting.ValueObjects.Brand(brand), type, power, maxBrightness, isDimmable, socket);

            Assert.NotNull(lamp);
        }

    }
}


