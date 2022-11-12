using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
    public class Buzzer : IBuzzer
    {
        private IOutput output;

        public void BuzzOnButtonPress()
        {
            output.OutputLine("Buzzer sound: Beep!");
        }

        public void BuzzOnCookingDone()
        {
            output.OutputLine(
                "Buzzer sound: Beep!...Beep!...Beep!");
        }
    }
}