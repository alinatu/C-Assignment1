using System;
using System.Text;
using System.Net;
using System.Net.Sockets;


namespace Assignment1
{
    public class HTTPRequest
    {
        private Socket socket;

        public HTTPRequest(Socket socket)
        {
            this.socket = socket;
        }

        public void Write()
        {
            string message = "";
            byte[] bytesStored = new byte[socket.ReceiveBufferSize];
            int k1 = socket.Receive(bytesStored);
            for (int i = 0; i < k1; i++)
            {
                message += Convert.ToChar(bytesStored[i]).ToString();
            }
            Console.WriteLine(message); // PRINT THE RESPONSE
        }
    }

    
}
