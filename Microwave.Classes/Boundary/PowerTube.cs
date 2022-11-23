using System;
using Microwave.Classes.Interfaces;

//power feature

namespace Microwave.Classes.Boundary
{
    public class PowerTube : IPowerTube
    {
        private IOutput myOutput;

        private bool IsOn = false;

        private int MaxPowerInWatts { get; set; } = 700;

        public PowerTube(IOutput output)
        {
            myOutput = output;
        }

        public void TurnOn(int power)
        {
            if (power < 1 || MaxPowerInWatts < power)
            {
                throw new ArgumentOutOfRangeException("power", power, $"Must be between 1 and {MaxPowerInWatts}  (incl.)");
            }

            if (IsOn)
            {
                throw new ApplicationException("PowerTube.TurnOn: is already on");
            }

            myOutput.OutputLine($"PowerTube works with {power}");
            IsOn = true;
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                myOutput.OutputLine($"PowerTube turned off");
            }

            IsOn = false;
        }

        public int GetMaxPowerInWatts()
        {
            return MaxPowerInWatts;
        }

        public void SetMaxPowerInWatts(int maxPowerInWatts)
        {
            if (maxPowerInWatts < 1 || 2400 < maxPowerInWatts)
                throw new ArgumentOutOfRangeException("power", MaxPowerInWatts, $"Must be between 1 and 2400  (incl.)");
            MaxPowerInWatts = maxPowerInWatts;
        }
       
    }
}