using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Assignment1
{
    public class DirServer
    {
        public static void Main(string[] args)
        {
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
                serverSocket.Listen(100);

                while (true)
                {
                    DirServerThread serverThread = new DirServerThread(serverSocket);
                }
            }

            catch (Exception e)
            {
                Console.Error.WriteLine(e + " Error creating Socket.");
            }

            
        }
    }
}
