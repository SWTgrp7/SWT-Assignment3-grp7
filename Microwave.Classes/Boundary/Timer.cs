using System;
using Microwave.Classes.Interfaces;

/* Thea's working on this feature branch */

namespace Microwave.Classes.Boundary
{
    public class Timer : ITimer
    {
        public int TimeRemaining { get; private set; }

        public event EventHandler Expired;
        public event EventHandler TimerTick;

        private System.Timers.Timer timer;

        public Timer()
        {
            timer = new System.Timers.Timer();
            // Bind OnTimerEvent with an object of this, and set up the event
            timer.Elapsed += OnTimerEvent;
            timer.Interval = 1000; // 1 second intervals
            timer.AutoReset = true;  // Repeatable timer
        }


        public void Start(int time)
        {
            TimeRemaining = time;
            timer.Enabled = true;
        }

        public void Stop()
        {
            timer.Enabled = false;
        }

        private void Expire()
        {
            timer.Enabled = false;
            Expired?.Invoke(this, System.EventArgs.Empty);
        }

        private void OnTimerEvent(object sender, System.Timers.ElapsedEventArgs args)
        {
            // One tick has passed
            // Do what I should
            TimeRemaining -= 1;
            TimerTick?.Invoke(this, EventArgs.Empty);

            if (TimeRemaining <= 0)
            {
                Expire();
            }
        }

        // Method to add a set amount of time to the TimeRemaining property - extend cooking time 
        public void AddTime()
        {
            TimeRemaining += 10;
        }

        //In case functionality is implemented - method to remove 10 sec from the cooking time 
        //Should be called when the retract time button is pressed
        public void RemoveTime()
        {
            // If timeRemaining is less than 10 sec, then the cooking should stop. 

            if(TimeRemaining < 10)
            {
                timer.Enabled = false;
                Expired?.Invoke(this, System.EventArgs.Empty);
            }
            else
            {
                TimeRemaining -= 10;
            }
            
        }

    }
}