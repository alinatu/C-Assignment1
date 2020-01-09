using System;
using System.IO;
using System.Diagnostics;
//Added to by Taylor Laan
namespace Assignment1 {
public class Logger
    {
        // Define a delegate named LogHandler, which will encapsulate
        // any method that takes a string as the parameter and returns no value
        public delegate void LogHandler(string message);

        // Define an Event based on the above Delegate
        public event LogHandler Log;

        // Instead of having the Process() function take a delegate
        // as a parameter, we've declared a Log event. Call the Event,
        // using the OnXXXX Method, where XXXX is the name of the Event.
        public void Error(string message)
        {
            OnLog("Logging Error: \n" + message);
        }
		
		public void Connection(string message) 
		{
			OnLog("Connection made at: \n" + DateTime.Now.ToString("yyyy-MM-dd, HH:mm:ss tt"));
		}

        // By Default, create an OnXXXX Method, to call the Event
        protected void OnLog(string message)
        {
            if (Log != null)
            {
                Log(message);
            }
        }
    }
}