using BlaisePascal.SmartHouse.Domain.Lighting;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class UnitTest1
    {
        // Test 1: The light of lamp starts off, then it is turned on

        [Fact]
        public void TurnOnOrOff_WhenTheLightIsOff_TurnsItOn()
        {
            var lamp = new Lamp("Test", "LED", 10, 500, true, "E27");

            lamp.TurnOnOrOff();

            Assert.True(lamp.IsOn());
        }

        // Test 2: The light of lamp starts off, then it is turned on, and then turned off again

        [Fact]
        public void TurnOnOrOff_WhenTheLightIsOn_TurnsItOff()
        {   
            var lamp = new Lamp("Test", "LED", 10, 500, true, "E27");
            lamp.TurnOnOrOff(); // First turn it on
           
            lamp.TurnOnOrOff(); // Now turn it off
            
            Assert.False(lamp.IsOn());
        }

        // Test 3: The lamp is dimmable, and a valid brightness level is provided (between 1 and 100)
       
        [Fact]
        public void DimmableControl_validValueAndDimmable_DoesNotThrow()
        {             
            var lamp = new Lamp("Test", "LED", 10, 500, true, "E27");
            var brightnessLevel = 50.0;

            lamp.DimmableControl(brightnessLevel);
        }

        // Test 4: The lamp is not dimmable, and a message is printed

        // var stringWriter = new StringWrter --> It allows us to "capture" into memory the text that would normally be printed
        // on the screen, making it readable by the automatic test.

        // var expectedMessage = "This lamp is not dimmable." + Environment.NewLine; --> This is the invisible line break character that
        // Console.WriteLine() always adds; we include it in the expected string to ensure an exact match.

        [Fact]
        public void DimmableControl_NotDimmableButValidValue_PrintsMessage()
        { 
            var lamp = new Lamp("Test", "Led", 10, 500, false, "E27");
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);    
            var expectedMessage = "This lamp is not dimmable." + Environment.NewLine;

            lamp.DimmableControl(50.0);

            Assert.Equal(expectedMessage, stringWriter.ToString());

        }

        // Test 5: The lamp is dimmable but the value is ivalidad, and a message is printed

        [Fact]
        public void DimmableControl_invalidValue_showsErrorMessage()
        {
            var lamp = new Lamp("Test", "LED", 10, 500, true, "E27"); // è dimmerabile
            var invalidBrightnessLevel = 150.0;
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var expectedMessage = "This lamp is not dimmable." + Environment.NewLine;

            lamp.DimmableControl(invalidBrightnessLevel);

            Assert.Equal(expectedMessage, stringWriter.ToString());
        }

        // Test 6: ChangeColor method works correctly for LED lamps

        [Fact]
        public void ChangeColor_lampIsLED_doesNotThrow()
        {
            var lamp = new Lamp("Test", "LED", 10, 500, true, "E27");

            lamp.ChangeColor(colors_of_lamp.blue);
        }

        // Test 7: ChangeColor method prints an error message for non-LED lamps

        [Fact]
        public void ChangeColor_lampIsNotLED_showsErrorMessage()
        {
            var lamp = new Lamp("Test", "Incandescent", 10, 500, false, "E27"); 
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var expectedMessage = "Error - The selected lamp type is not led RGB" + Environment.NewLine;

            lamp.ChangeColor(colors_of_lamp.blue);

            Assert.Equal(expectedMessage, stringWriter.ToString());
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
          
            var lamp = new Lamp(brand, type, power, maxBrightness, isDimmable, socket);

            Assert.NotNull(lamp);
        }

    }
}


