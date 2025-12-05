using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Appliances;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class CoffeeMachineTest

    {
        // Test 1: Test turning the machine on when it is off
        [Fact]
        public void TurnOnOrOff_WhenMachineIsOff_TurnsOn()
        {
            var machine = new CoffeeMachine();
            machine.TurnOnOrOff();

            Assert.True(machine.IsOn);
        }

        // Test 3: Test turning the machine off when it is on
        [Fact]
        public void TurnOnOrOff_WhenMachineIsOn_TurnsOff()
        {
            var machine = new CoffeeMachine();
            machine.TurnOnOrOff();
            machine.TurnOnOrOff();

            Assert.False(machine.IsOn);
        }

        // Test 5: Test adding water when the machine is off and amount is valid
        [Fact]
        public void AddWater_WhenMachineOffAndValidAmount_AddsWater()
        {
            var machine = new CoffeeMachine();
            machine.AddWater(10);

            Assert.Equal(10, machine.WaterLevel);
        }

        // Test 6: Test adding water when the machine is on
        [Fact]
        public void AddWater_WhenMachineOn_ThrowsException()
        {
            var machine = new CoffeeMachine();
            machine.TurnOnOrOff();

            // Assert.Throws<ArgumentException>(machine.AddWater(20)); // ❌ ERRORE
            // Wrapper necessario perché Assert.Throws richiede un metodo senza parametri

            void AddWaterWrapped() { machine.AddWater(20); }
            Assert.Throws<InvalidOperationException>(AddWaterWrapped);
        }

        // Test 7: Test adding too much water exceeding max capacity
        [Fact]
        public void AddWater_TooMuch_ThrowsException()
        {
            var machine = new CoffeeMachine();
            machine.AddWater(90);

            Assert.Throws<ArgumentException>(() => machine.AddWater(11));
        }

        // Test 8: Test removing water when the machine is on and amount is valid
        [Fact]
        public void RemoveWater_WhenMachineOnAndValidAmount_RemovesWater()
        {
            var machine = new CoffeeMachine();
            machine.TurnOnOrOff();
            machine.AddWater(50);
            machine.RemoveWater(20);

            Assert.Equal(30, machine.WaterLevel);
        }

        // Test 9: rimuovere acqua quando la macchina è spenta
        [Fact]
        public void RemoveWater_WhenMachineOff_ThrowsException()
        {
            var machine = new CoffeeMachine();
            machine.AddWater(50);

            void RemoveWaterWrapped() { machine.RemoveWater(20); }
            Assert.Throws<InvalidOperationException>(RemoveWaterWrapped);
        }

        // Test 10: rimuovere troppa acqua
        [Fact]
        public void RemoveWater_TooMuch_ThrowsException()
        {
            var machine = new CoffeeMachine();
            machine.TurnOnOrOff();
            machine.AddWater(10);

            void RemoveWaterWrapped() { machine.RemoveWater(20); }
            Assert.Throws<ArgumentException>(RemoveWaterWrapped);
        }


        // Test 11: Test placing a cup when no cup is present
        [Fact]
        public void PlaceCup_WhenNoCup_PlacesCup()
        {
            var machine = new CoffeeMachine();
            machine.PlaceCup();

            Assert.True(machine.IsCupPresent);
        }

        // Test 12: Test placing a cup when a cup is already present
        [Fact]
        public void PlaceCup_WhenCupPresent_ThrowsException()
        {
            var machine = new CoffeeMachine();
            machine.PlaceCup();

            Assert.Throws<InvalidOperationException>(machine.PlaceCup);
        }

        // Test 13: Test removing a cup when a cup is present
        [Fact]
        public void RemoveCup_WhenCupPresent_RemovesCup()
        {
            var machine = new CoffeeMachine();
            machine.PlaceCup();
            machine.RemoveCup();

            Assert.False(machine.IsCupPresent);
        }

        // Test 14: Test removing a cup when no cup is present
        [Fact]
        public void RemoveCup_WhenNoCup_ThrowsException()
        {
            var machine = new CoffeeMachine();

            Assert.Throws<InvalidOperationException>(machine.RemoveCup);
        }

        // Test 15: Test making coffee with valid conditions
        [Fact]
        public void MakeCoffee_ValidConditions_MakesCoffee()
        {
            var machine = new CoffeeMachine();
            machine.TurnOnOrOff();
            machine.AddWater(50);
            machine.PlaceCup();
            machine.MakeCoffee();

            Assert.Equal(30, machine.WaterLevel);
            Assert.False(machine.IsCupPresent);
            Assert.False(machine.IsBrewing);
        }

        // Test 16: Test making coffee with not enough water
        [Fact]
        public void MakeCoffee_NotEnoughWater_ThrowsException()
        {
            var machine = new CoffeeMachine();
            machine.TurnOnOrOff();
            machine.AddWater(10);
            machine.PlaceCup();

            Assert.Throws<InvalidOperationException>(machine.MakeCoffee);
        }

        // Test 17: Test making coffee without a cup
        [Fact]
        public void MakeCoffee_NoCup_ThrowsException()
        {
            var machine = new CoffeeMachine();
            machine.TurnOnOrOff();
            machine.AddWater(50);

            Assert.Throws<InvalidOperationException>(machine.MakeCoffee);
        }

        // Test 18: Test making coffee when the machine is off
        [Fact]
        public void MakeCoffee_MachineOff_ThrowsException()
        {
            var machine = new CoffeeMachine();
            machine.AddWater(50);
            machine.PlaceCup();

            Assert.Throws<InvalidOperationException>(machine.MakeCoffee);
        }
    }
}
