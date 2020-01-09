using System;
using System.Net.Sockets;
using System.Text;


namespace Assignment1
{
    public class HTTPResponse
    {
        private Socket socket;

        public HTTPResponse(Socket socket)
        {
            this.socket = socket;
        }

        public void Write(string response)
        {
            byte[] byResponse = Encoding.ASCII.GetBytes(
                "HTTP/1.0 200\r\nContent-Type: text/html;charset=ISO-8859-1\r\nContent-Length: "
                + Encoding.ASCII.GetByteCount(response)
                + "\r\n\r\nConnection: close\r\n\r\n" + response + "\r\n");
            socket.Send(byResponse);
        }
    }
}
