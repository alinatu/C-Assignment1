using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;

namespace Assignment1
{
    public class DirServer
    {
        // Written by Alina
        public static Logger serverLogger;

        public static EventLog appLog;
        
        //Written by Taylor
        public static void EventLogger(string s)
        {
            appLog.WriteEntry(s);
        }

        public static void Main(string[] args)
        {
            //Written by Taylor
            serverLogger = new Logger();
            FileLogger fl = new FileLogger("dirServer.log");

            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Comp4945");

            //Written by Taylor and Jason
            //Checks if the registry key is set to allow for logging to Windows application logs
            if ( rk != null && rk.GetValue("logEvents").ToString().Equals("true"))
            {
                appLog = new EventLog();

                if (!EventLog.SourceExists("DirServerSource"))
                    EventLog.CreateEventSource("DirServerSource", "DirServerLog");
                appLog.Source = "DirServerSource";
                appLog.Log = "DirServerLog";

                serverLogger = new Logger();

                // Subscribe the Event Logger
                serverLogger.Log += new Logger.LogHandler(EventLogger);
            }

            serverLogger.Log += new Logger.LogHandler(fl.Logger);

            // Establish the local endpoint  
            // for the socket. Dns.GetHostName 
            // returns the name of the host  
            // running the application.
            IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 8888);

            // Creation TCP/IP Socket using  
            // Socket Class Costructor 
            Socket serverSocket = new Socket(ipAddr.AddressFamily,
                         SocketType.Stream, ProtocolType.Tcp);

            try
            {
                serverSocket.Bind(localEndPoint);
                serverSocket.Listen(CoreCount.CoreCounter());

                while (true)
                {
                    DirServerThread serverThread = new DirServerThread(serverSocket.Accept());
                }
            }

            catch (Exception e)
            {
                Console.Error.WriteLine(e + " Error creating Socket.");
                serverLogger.Error(e.ToString());
            }

            serverSocket.Close();
            fl.Close();
        }
    }
}
