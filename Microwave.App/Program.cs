using System;
using Microwave.Classes.Boundary;
using Microwave.Classes.Controllers;

namespace Microwave.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Button startCancelButton = new Button();
            Button powerButton = new Button();
            Button timeButton = new Button();
            Button subtractTime = new Button();

            Door door = new Door();

            Output output = new Output();

            Display display = new Display(output);

            Buzzer buzzer = new Buzzer(output);

            PowerTube powerTube = new PowerTube(output);

            powerTube.SetMaxPowerInWatts(700);

            Light light = new Light(output);

            Microwave.Classes.Boundary.Timer timer = new Timer();

            CookController cooker = new CookController(timer, display, powerTube);

            UserInterface ui = new UserInterface(powerButton, timeButton, startCancelButton, subtractTime, door, display, buzzer, light, cooker);

            // Finish the double association
            cooker.UI = ui;

            // Simulate a simple sequence

            powerButton.Press();

            timeButton.Press();

            startCancelButton.Press();

            // The simple sequence should now run


            System.Console.WriteLine("When you press enter, the program will stop");
            // Wait for input

            System.Console.ReadLine();
        }
    }
}
