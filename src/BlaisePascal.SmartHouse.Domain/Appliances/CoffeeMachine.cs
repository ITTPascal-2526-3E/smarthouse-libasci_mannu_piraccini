using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Appliances
{
    public class CoffeeMachine
    {
        public Guid Id = Guid.NewGuid();
        public bool isOn = false;
        public bool isBrewing = false;
        public bool isCupPresent = false;

        public int waterLevel = 0; // from 0 to 100 percent

        // Turn Coffee Machine ON
        public void TurnOn()
        {
            if (isOn == true)
                throw new InvalidOperationException("The coffee machine is already on.");

            isOn = true;
        }

        // Turn Coffee Machine OFF
        public void TurnOff()
        {
            if (isOn == false)
                throw new InvalidOperationException("The coffee machine is already off.");

            if (isBrewing)
                throw new InvalidOperationException("Cannot turn off the machine while brewing coffee.");

            isOn = false;
        }

        // Add water (0–100)
        public void AddWater(int amount)
        {
            if (isOn == true)
                throw new InvalidOperationException("Turn the machine off before adding water.");

            if (amount <= 0)
                throw new ArgumentException("Amount of water must be greater than zero.");

            if (amount > 100 - waterLevel)
                throw new ArgumentException("Cannot add that much water. It would exceed the maximum capacity of 100%.");

            else
                waterLevel += amount;
        }

        // Remove water
        public void RemoveWater(int amount)
        {
            if (isOn == false)
                throw new InvalidOperationException("Turn the machine on before removing water.");

            if (amount <= 0)
                throw new ArgumentException("Amount of water must be greater than zero.");

            if (amount > waterLevel)
                throw new ArgumentException("Cannot remove that much water. Not enough water in the machine.");
            else
                waterLevel -= amount;

        }

        // Place cup
        public void PlaceCup()
        {
            if (isCupPresent == true)
                throw new InvalidOperationException("A cup is already present.");

            isCupPresent = true;
        }

        // Remove cup
        public void RemoveCup()
        {
            if (isBrewing == true)
                throw new InvalidOperationException("Cannot remove the cup while brewing coffee.");

            if (isCupPresent == false)
                throw new InvalidOperationException("There is no cup to remove.");

            isCupPresent = false;
        }

        // Make a coffee
        public void MakeCoffee()
        {
            if (isOn == false)
                throw new InvalidOperationException("The machine must be on to make coffee.");

            if (isCupPresent == false)
                throw new InvalidOperationException("You must place a cup before making coffee.");

            if (isBrewing == true)
                throw new InvalidOperationException("The machine is already brewing.");

            if (waterLevel < 20)
                throw new InvalidOperationException("Not enough water to make coffee.");

            else

                isBrewing = true;

            waterLevel -= 20;

            // The coffee is ready, the machine stops working
            isBrewing = false;

            // The cup is removed automatically
            isCupPresent = false;
        }

        public bool IsOn()
        {
            return isOn;
        }

        public bool IsBrewing()
        {
            return isBrewing;
        }

        public bool IsCupPresent()
        {
            return isCupPresent;
        }

        public int WaterLevel()
        {
            return waterLevel;
        }
    }

}
