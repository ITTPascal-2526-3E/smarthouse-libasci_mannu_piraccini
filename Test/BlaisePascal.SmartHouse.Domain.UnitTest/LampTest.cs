namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void TurnOnOrOff_WhenTheLightIsOff_TurnsItOn()
        {
            // Arrange
            var lamp = new Lamp("Test", "LED", 10, 500, true, "E27");

            // Act
            lamp.TurnOnOrOff();

            // Assert
            Assert.True(lamp.IsOn());
        }

        [Fact]
        public void TurnOnOrOff_WhenTheLightIsOn_TurnsItOff()
        {   
            var lamp = new Lamp("Test", "LED", 10, 500, true, "E27");
            lamp.TurnOnOrOff(); // First turn it on
           
            lamp.TurnOnOrOff(); // Now turn it off
            
            Assert.False(lamp.IsOn());
        }

        [Fact]
        public void DimmableControl_validValueAndDimmable_DoesNotThrow()
        {             
            var lamp = new Lamp("Test", "LED", 10, 500, true, "E27");
            
          
        }


    }
}

