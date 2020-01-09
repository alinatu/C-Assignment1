using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace Assignment1

{
    public class DirServerThread
    {
        private Socket socket = null;

        // Written by Alina
        public DirServerThread(Socket socket)
        {
            this.socket = socket;
            var thread = new Thread(new ThreadStart(this.Run));
            thread.Start();
        }

        // Written by Alina
        public void Run()
        {
            HTTPRequest request = new HTTPRequest(socket);
            HTTPResponse response = new HTTPResponse(socket);
            DirServlet myServlet = new DirServlet();
            myServlet.DoGet(request, response);
        }
    }
   
}
