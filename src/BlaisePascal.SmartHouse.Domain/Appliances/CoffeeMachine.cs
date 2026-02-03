using BlaisePascal.SmartHouse.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Appliances
{
    public class CoffeeMachine : ISwitchable
    {
        public Guid Id = Guid.NewGuid();
        public bool IsOn { get; set; } = false;
        public bool IsBrewing { get; private set; } = false;
        public bool IsCupPresent { get; private set; } = false;

        public int WaterLevel { get; private set; } = 0;

        // Turn Coffee Machine ON or OFF
        public void TurnOnOrOff()
        {
            IsOn = !IsOn;
        }

        // Add water (0–100)
        public void AddWater(int amount)
        {
            if (IsOn == true)
                throw new InvalidOperationException("Turn the machine off before adding water.");

            if (amount <= 0)
                throw new ArgumentException("Amount of water must be greater than zero.");

            if (amount > 100 - WaterLevel)
                throw new ArgumentException("Cannot add that much water. It would exceed the maximum capacity of 100%.");

            else
                WaterLevel += amount;
        }

        // Remove water
        public void RemoveWater(int amount)
        {
            if (IsOn == true) 
                throw new InvalidOperationException("Turn the machine off before removing water.");

            if (amount <= 0)
                throw new ArgumentException("Amount of water must be greater than zero.");

            if (amount > WaterLevel)
                throw new ArgumentException("Cannot remove that much water. Not enough water in the machine.");
            else
                WaterLevel -= amount;

        }

        // Place cup
        public void PlaceCup()
        {
            if (IsCupPresent == true)
                throw new InvalidOperationException("A cup is already present.");

            IsCupPresent = true;
        }

        // Remove cup
        public void RemoveCup()
        {
            if (IsBrewing == true)
                throw new InvalidOperationException("Cannot remove the cup while brewing coffee.");

            if (IsCupPresent == false)
                throw new InvalidOperationException("There is no cup to remove.");

            IsCupPresent = false;
        }

        // Make a coffee
        public void MakeCoffee()
        {
            if (IsOn == false)
                throw new InvalidOperationException("The machine must be on to make coffee.");

            if (IsCupPresent == false)
                throw new InvalidOperationException("You must place a cup before making coffee.");

            if (IsBrewing == true)
                throw new InvalidOperationException("The machine is already brewing.");

            if (WaterLevel < 20)
                throw new InvalidOperationException("Not enough water to make coffee.");

            else

                IsBrewing = true;

            WaterLevel -= 20;

            // The coffee is ready, the machine stops working
            IsBrewing = false;

            // The cup is removed automatically
            IsCupPresent = false;
        }

    }

}
