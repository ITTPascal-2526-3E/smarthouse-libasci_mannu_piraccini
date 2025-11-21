using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class EcoLampTest
    {
        [Fact]
        public void TurnOnOrOff_ShouldToggleIsOnState()
        {
            // Arrange
            var ecoLamp = new EcoLamp("Tapo", 60.0, 806.0, true, "E27");
            // Act & Assert
            Assert.False(ecoLamp.IsOn()); // Initially off
            ecoLamp.TurnOnOrOff();
            Assert.True(ecoLamp.IsOn()); // Should be on after first toggle
            ecoLamp.TurnOnOrOff();
            Assert.False(ecoLamp.IsOn()); // Should be off after second toggle
        }




    }
}
